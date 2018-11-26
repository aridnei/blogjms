#!/usr/bin/env sh

KUBE_CONTEXT=docker-for-desktop
NAMESPACE=default #bluegreen
CIRCLE_BUILD_DOCKER="142"
AWS_REPO=$(cat deploy-definitions.json | jq --raw-output '.aws_repo')
AWS_REGION=$(cat deploy-definitions.json | jq --raw-output '.aws_region')
GITHUB_VERSION=$(cat deploy-definitions.json | jq --raw-output '.github_version')

ECR_IMAGE=$AWS_REPO:$GITHUB_VERSION-ci$CIRCLE_BUILD_DOCKER

echo "Starting commands"
kubectl config use-context ${KUBE_CONTEXT}

# Get deployment versions
BlueVersion=$(kubectl get service jmblog-api -o=jsonpath='{.spec.selector.version}' --namespace=${NAMESPACE}) #find deployed version
echo "Blue version... $BlueVersion"
GreenVersion=$GITHUB_VERSION-ci$CIRCLE_BUILD_DOCKER
echo "Green version... $GreenVersion"

# Deploy Blue version 
echo "Deploying Green version... $GreenVersion"
kubectl get deployment jmblog-api-$BlueVersion -o=yaml --namespace=${NAMESPACE} | sed -e "s/$BlueVersion/$GreenVersion/g" | kubectl apply --namespace=${NAMESPACE} -f -

# Update service to Blue version
echo "Updating service to Green version... $GreenVersion"
kubectl patch service jmblog-api -p '{"spec":{"selector":{"version":"'$GreenVersion'"}}}'

# Test deployment Green version health
echo "Testing Green version deployment health ... jmblog-api-$GreenVersion"
kubectl rollout status "deployment/jmblog-api-$GreenVersion"

# Delete Blue version deployment
#echo "Deleting Blue deployment version ... jmblog-api-$BlueVersion"
# kubectl delete deploy "jmblog-api-$BlueVersion"

sleep 20

# Rollback service to Blue version
echo "Rollback Blue service ... jmblog-api-$BlueVersion"
kubectl patch service jmblog-api -p '{"spec":{"selector":{"version":"'$BlueVersion'"}}}'

# Delete Green version deployment
echo "Deleting Green deployment version ... jmblog-api-$GreenVersion"
kubectl delete deploy "jmblog-api-$GreenVersion"
