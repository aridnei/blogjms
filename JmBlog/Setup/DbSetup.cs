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

                 var p0 = new PostCreateViewModel
                {
                    Title = "Festa de Trabalho ainda é ambiente corporativo!",
                    Text = "<p>2 - É comum que nessa época do ano as empresas organizem festas de confraternização para comemorar mais um ano de trabalho realizado. Essa é a ocasião ideal para que os limites sejam observados, pois o ambiente descontraído pode passar a impressão de que não existem limites corporativos naquele momento. Porém, as consequências de ações indevidas podem ser várias, desde virar um meme entre os colegas, até uma possível advertência e o pior, uma demissão.</p><br><br><p>Não erre, aproveite para se divertir e interagir com todos os colegas, mas lembrando de manter uma postura equilibrada. Com moderação, a festa da empresa pode ser uma oportunidade única de ampliar contatos, quebrar o gelo e melhorar as relações entre os colaboradores.</p><br>",
                    ImageBase64 = urlImage,
                    DatePublished = DateTime.Now.AddMinutes(-6)
                };

                var p1 = new PostCreateViewModel
                {
                    Title = "Festa de Trabalho ainda é ambiente corporativo!",
                    Text = "<p>É comum que nessa época do ano as empresas organizem festas de confraternização para comemorar mais um ano de trabalho realizado. Essa é a ocasião ideal para que os limites sejam observados, pois o ambiente descontraído pode passar a impressão de que não existem limites corporativos naquele momento. Porém, as consequências de ações indevidas podem ser várias, desde virar um meme entre os colegas, até uma possível advertência e o pior, uma demissão.</p><br><br><p>Não erre, aproveite para se divertir e interagir com todos os colegas, mas lembrando de manter uma postura equilibrada. Com moderação, a festa da empresa pode ser uma oportunidade única de ampliar contatos, quebrar o gelo e melhorar as relações entre os colaboradores.</p><br>",
                    ImageBase64 = urlImage,
                    DatePublished = DateTime.Now.AddMinutes(-5)
                };

                var p2 = new PostCreateViewModel
                {
                    Title = "Método Ágil.",
                    Text = "<p>O Scrum é uma metodologia ágil para o planejamento e a gestão de projetos de tecnologia. Nele, os projetos são divididos em ciclos, os ‘famosos’ Sprints, que são períodos em que um conjunto de atividades deve ser executado. O método ágil para desenvolver um projeto é muito interativo e eficaz. Foi esse método que permitiu ao novo Squad criar um blog em apenas dois dias.</p><br/><br/><p>O Scrum, além de garantir agilidade, faz com que todos os participantes tenham papel importante no projeto e distribui as atividades de forma clara e lógica. A partir de agora, a nova JOTA é ágil!</p>",
                    ImageBase64 = urlImage2,
                    DatePublished = DateTime.Now.AddMinutes(-4)
                };

                var p3 = new PostCreateViewModel
                {
                    Title = "Aqui é trabalho, meu Filho!",
                    Text = "<p>Como já dizia o professor Muricy Ramalho “aqui é trabalho, meu filho”. O Novo Squad chegou com tudo e em apenas dois dias conseguiu criar este blog, atingindo com esmero o desafio proposto. Novos desafios virão pela frente, mas a equipe está conectada e com muito foco! Não existe conquista que não seja coletiva! </p><br/><br/><p>Lembrando que os Squads serão uma nova parte da empresa que não exclui nenhuma das atuais áreas. Todas as equipes tradicionais trabalharam em conjunto com as inovações tecnológicas pensadas para a nova JOTA.</p><br/>",
                    ImageBase64 = urlImage3,
                    DatePublished = DateTime.Now.AddMinutes(-3)
                };

                var p4 = new PostCreateViewModel
                {
                    Title = "JOTA cria dois novos Squads.",
                    Text = "<p>Nessa última semana a JOTA criou dois novos Squads. Após o sucesso do primeiro Squad de inovação tecnológica, com foco na jornada dos corretores, a companhia decidiu continuar o processo de inovação com dois novos temas que impactarão o mercado de Seguro Garantia brasileiro.</p><br/><br/><p>Os novos projetos já estão em andamento e prometem revolucionar o jeito em que pensamos e contratamos Seguro Garantia. Aguardem, mais novidades em breve!</p><br/>",
                    ImageBase64 = urlImage4,
                    DatePublished = DateTime.Now.AddMinutes(-2)
                };

                var p5 = new PostCreateViewModel{
                    Title = "Nasce uma Nova JOTA!",
                    Text = "<p>Não existe conquista que não seja coletiva! É um novo momento da JOTA para fazer acontecer. É uma nova JOTA que está surgindo. Mais conectada, mais tecnológica, mais inovadora. São novas formas de quebrar barreiras e conectar pessoas, empresas, projetos!</p><br/><br/><p>Essa transformação vai ser traduzida em grandes projetos e também nas pequenas atitudes. A nova JOTA é mais digital, mas também é mais ágil e ligada a tudo que acontece no mercado, de forma mais rápida e inteligente.</p><br/>",                    
                    ImageBase64 = urlImage5,
                    DatePublished = DateTime.Now.AddMinutes(-1)
                };

                await postService.Create(p0);
                await postService.Create(p1);
                await postService.Create(p2);
                await postService.Create(p3);
                await postService.Create(p4);
                await postService.Create(p5);

            }
        }
    }
}