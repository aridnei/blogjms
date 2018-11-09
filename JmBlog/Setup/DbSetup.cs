using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using JmBlog.Data.Contracts;
using JmBlog.Interfaces;
using JmBlog.Model;
using JmBlog.ViewModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JmBlog.Setup
{
    [ExcludeFromCodeCoverage]
    public static class DbSetup
    {
        public static async Task InitDB(this IApplicationBuilder app, IConfiguration configuration)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {

                var postService = serviceScope.ServiceProvider.GetService<IPostService>();
                var urlImage = configuration.GetSection("urlImage").Value;
                var urlImage2 = configuration.GetSection("urlImage2").Value;
                var urlImage3 = configuration.GetSection("urlImage3").Value;
                var urlImage4 = configuration.GetSection("urlImage4").Value;
                var urlImage5 = configuration.GetSection("urlImage5").Value;
                var urlImage6 = configuration.GetSection("urlImage6").Value;

                //var p1 = new PostCreateViewModel{
                //    Title = "Neymar",
                //    Text = "<p>Todos as descrições das pessoas são sobre a humanidade do atendimento, a pessoa pega no pulso, examina, olha com carinho. Então eu acho que vai ter outra coisa, que os médicos cubanos trouxeram pro brasil, um alto grau de humanidade.</p><br><p>Eu dou dinheiro pra minha filha. Eu dou dinheiro pra ela viajar, então é... é... Já vivi muito sem dinheiro, já vivi muito com dinheiro. -Jornalista: Coloca esse dinheiro na poupança que a senhora ganha R$10 mil por mês. -Dilma: O que que é R$10 mil?</p><br><p>No meu xinélo da humildade eu gostaria muito de ver o Neymar e o Ganso. Por que eu acho que.... 11 entre 10 brasileiros gostariam. Você veja, eu já vi, parei de ver. Voltei a ver, e acho que o Neymar e o Ganso têm essa capacidade de fazer a gente olhar.</p><br>",
                //    DatePublished = DateTime.Now.AddDays(-1),
                //    ImageBase64 = urlImage
                //};

                //Console.WriteLine("Inclusao p1");

                //var p2 = new PostCreateViewModel{
                //    Title = "Internautas",
                //    Text = "<p>Primeiro eu queria cumprimentar os internautas. -Oi Internautas! Depois dizer que o meio ambiente é sem dúvida nenhuma uma ameaça ao desenvolvimento sustentável. E isso significa que é uma ameaça pro futuro do nosso planeta e dos nossos países. O desemprego beira 20%, ou seja, 1 em cada 4 portugueses.</p><br><p>Eu dou dinheiro pra minha filha. Eu dou dinheiro pra ela viajar, então é... é... Já vivi muito sem dinheiro, já vivi muito com dinheiro. -Jornalista: Coloca esse dinheiro na poupança que a senhora ganha R$10 mil por mês. -Dilma: O que que é R$10 mil?</p><br><p>Se hoje é o dia das crianças... Ontem eu disse: o dia da criança é o dia da mãe, dos pais, das professoras, mas também é o dia dos animais, sempre que você olha uma criança, há sempre uma figura oculta, que é um cachorro atrás. O que é algo muito importante!</p><br><p>Ai você fala o seguinte: \"- Mas vocês acabaram isso?\" Vou te falar: -\"Não, está em andamento!\" Tem obras que \vai\" durar pra depois de 2010. Agora, por isso, nós já não desenham não começamos a fazer projeto do que nós \"podêmo fazê\"? 11, 12, 13, 14... Por que é que não?</p><br><p>No meu xinélo da humildade eu gostaria muito de ver o Neymar e o Ganso. Por que eu acho que.... 11 entre 10 brasileiros gostariam. Você veja, eu já vi, parei de ver. Voltei a ver, e acho que o Neymar e o Ganso têm essa capacidade de fazer a gente olhar.</p>",
                //    ImageBase64 = urlImage2,
                //    DatePublished = DateTime.Now.AddDays(-2)
                //};

                //var p3 = new PostCreateViewModel{
                //    Title = "Em andamento",
                //    Text = "<p>Ai você fala o seguinte: \"- Mas vocês acabaram isso?\" Vou te falar: -\"Não, está em andamento!\" Tem obras que \"vai\" durar pra depois de 2010. Agora, por isso, nós já não desenhamos, não começamos a fazer projeto do que nós \"podêmo fazê\"? 11, 12, 13, 14... Por que é que não?</p><br><p>A população ela precisa da Zona Franca de Manaus, porque na Zona franca de Manaus, não é uma zona de exportação, é uma zona para o Brasil. Portanto ela tem um objetivo, ela evita o desmatamento, que é altamente lucravito. Derrubar arvores da natureza é muito lucrativo!</p>",
                //    ImageBase64 = urlImage3,
                //    DatePublished = DateTime.Now.AddDays(-3)
                //};

                //var p4 = new PostCreateViewModel{
                //    Title = "Dia das crianças",
                //    Text = "<p>Se hoje é o dia das crianças... Ontem eu disse: o dia da criança é o dia da mãe, dos pais, das professoras, mas também é o dia dos animais, sempre que você olha uma criança, há sempre uma figura oculta, que é um cachorro atrás. O que é algo muito importante!</p><br><p>A única área que eu acho, que vai exigir muita atenção nossa, e aí eu já aventei a hipótese de até criar um ministério. É na área de... Na área... Eu diria assim, como uma espécie de analogia com o que acontece na área agrícola.</p><br><p>No meu xinélo da humildade eu gostaria muito de ver o Neymar e o Ganso. Por que eu acho que.... 11 entre 10 brasileiros gostariam. Você veja, eu já vi, parei de ver. Voltei a ver, e acho que o Neymar e o Ganso têm essa capacidade de fazer a gente olhar.</p><br><p>Ai você fala o seguinte: \"- Mas vocês acabaram isso?\" Vou te falar: -\"Não, está em andamento!\" Tem obras que \"vai\" durar pra depois de 2010. Agora, por isso, nós já não desenhamos, não começamos a fazer projeto do que nós \"podêmo fazê\"? 11, 12, 13, 14... Por que é que não?</p><br><p>Primeiro eu queria cumprimentar os internautas. -Oi Internautas! Depois dizer que o meio ambiente é sem dúvida nenhuma uma ameaça ao desenvolvimento sustentável. E isso significa que é uma ameaça pro futuro do nosso planeta e dos nossos países. O desemprego beira 20%, ou seja, 1 em cada 4 portugueses.</p><br><p>Eu dou dinheiro pra minha filha. Eu dou dinheiro pra ela viajar, então é... é... Já vivi muito sem dinheiro, já vivi muito com dinheiro. -Jornalista: Coloca esse dinheiro na poupança que a senhora ganha R$10 mil por mês. -Dilma: O que que é R$10 mil?</p>",
                //    ImageBase64 = urlImage4,
                //    DatePublished = DateTime.Now.AddDays(-4)
                //};

                var p5 = new PostCreateViewModel{
                    Title = "Jackathon, o Hackathon da Jota",
                    Text = "<p>Você já passou pela experiencia de trabalhar com uma equipe completamente nova, criando um produto do zero com tempo bem reduzido e uma metodologia que não é familiar a todos os participantes? Essa experiencia é real e está acontecendo com a equipe dos novos squads de inovação digital da JMalucelli Seguradora.</p><br><p>Neste momento, nós da equipe estamos no segundo de quatro sprints (com quatro horas cada), para a criação de um blog que contará a história do próprio projeto. A equipe é orientada pelo P.O. Mauro e conta com a participação da Scrum Master Flavia, do DevOps Aridnei, dos Desenvolvedores Backend Ernane, Igor e Willian; além do Q.A. Eder, o Designer de UI Rodrigo e o Luciano, Designer de UX.</p><br><p>No primeiro post, resolvemos contar quais foram os pontos positivos e negativos que ocorreram na primeira sprint. Essa análise é resultado da primeira reunião de retrospectiva do projeto, realizada logo após a conclusão da primeira sprint.</p><br><p>A equipe destacou, como pontos positivos, principalmente o entrosamento e a comunicação entre os integrantes da equipe. Todos se reuniram rapidamente em torno do problema a resolver e interagiram para encontrar soluções para solucionar as tarefas da sprint. O alinhamento interno das necessidades técnicas também foi rápido e feito em conjunto.</p><br><p>Porém, dificuldades existem: No início, a demora no setup das máquinas e na criação dos ambientes consumiu boa parte do tempo da primeira srpint. Também foi um ponto negativo a falta de entregas visíveis de Backend. </p><br><p>Será a equipe capaz de resolver os problemas técnicos e avançar no projeto? Os integrantes vão conseguir entregar as tarefas no tempo previsto? Sairão todos em boas condições psicológicas?</p><br><p>Descubra mais no próximo post. Até lá!</p>",                    
                    ImageBase64 = urlImage5,
                    DatePublished = DateTime.Now
                };

                var p6 = new PostCreateViewModel{
                    Title = "Segunda sprint: a primeira melhor.",
                    Text = "<p>Qual é o resultado de uma tarde confusa e problemática de trabalho? Ao invés de nos atrapalharem, as dificuldades técnicas da primeira sprint foram a motivação para a equipe buscar novas saídas e alternativas para tornar o projeto viável. E deu certo.</p><br><p>A segunda sprint foi uma evolução, com melhores resultados na entrega. Temos nosso primeiro post visível! Mesmo que seja apenas estático. Depois do primeiro passo, fica mais fácil caminhar (diria alguém que sabe das tarefas que temos e quer nos animar). As atividades de backend também avançaram bastante, mesmo que não tenham sido totalmente concluídas.</p><br><p>A melhora nos resultados da entrega ficou clara na avaliação que a equipe fez de si mesma na retrospectiva: a comunicação interna da equipe mais uma vez foi o ponto forte, junto com a entrega maior e mais visível de resultados, além da reunião de definição das tarefas (planning), ter sido muito mais clara e com estimativas mais realistas.</p><br><p>Como nem tudo é perfeito, a ótima sprint teve seus problemas: além de algumas (poucas) tarefas incompletas, uma pequena confusão de comunicação com o P.O. nos fez optar por uma mudança em cima da hora que comprometeu a apresentação dos resultados. </p><br><p>A segunda sprint foi o momento de mensagens importantes para a equipe como um todo e para o andamento do projeto. A Flavia, nossa Scrum Master, lembrou que precisamos ajudar um ao outro para melhorar o entendimento dos termos e situações entre todos, já que cada um de nós vem de uma área diferente. Como já vimos, a disposição para ajudar o outro é um ponto forte da equipe!</p><br><p>Com mais fé e menos tempo que nunca, continuamos nossa batalha.</p><br><p>Mais notícias no próximo post, até! </p>",                    
                    ImageBase64 = urlImage6,
                    DatePublished = DateTime.Now
                };

                Console.WriteLine("Inclusao p6");

                //await postService.Create(p1);
                //await postService.Create(p2);
                //await postService.Create(p3);
                //await postService.Create(p4);
                await postService.Create(p5);
                await postService.Create(p6);

            }
        }
    }
}