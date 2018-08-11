using AspNetVS2017.Capitulo03.Mvc.Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetVS2017.Capitulo03.Mvc.Portfolio.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {        
            return View();
        }

        [HttpPost]
        //public ActionResult Contact(string nome, string email, string mensagem)
        public ActionResult Contact(ContatoViewModel viewModel)
        {
            //Validando se a Model é valida mesmo que já tenha validação no Js
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var portfolioConnectionString = ConfigurationManager.ConnectionStrings["porftolioConnectionString"].ConnectionString;

            using (var conexao = new SqlConnection(portfolioConnectionString))
            {
                conexao.Open(); //Abrindo a conexao

                //Passando a instrução do abanco de daods para uma váriavel 
                const string instrucao = @"
                                            INSERT INTO [dbo].[Contato]
                                                       ([Nome]
                                                       ,[Email]
                                                       ,[Mensagem])
                                                 VALUES
                                                       (@Nome
                                                       ,@Email
                                                       ,@Mensagem)
                                            ";
                //Usando as conexãoes. Primeiro passo o paramentro de instrução e depois a de conexão
                using (var comando = new SqlCommand(instrucao, conexao)) 
                {
                    comando.Parameters.AddWithValue("@Nome", viewModel.Nome); // Aqui faço as referências sobre quais campos do banco representam as minhas váriaveis da pag web
                    comando.Parameters.AddWithValue("Email", viewModel.Email);
                    comando.Parameters.AddWithValue("@Mensagem", viewModel.Mensagem);

                    comando.ExecuteNonQuery(); //Comando apenas para enviar os dados, não esperamos um retorno
                }    
                //conexao.Close();
            }


            return View();
        }
    }
}