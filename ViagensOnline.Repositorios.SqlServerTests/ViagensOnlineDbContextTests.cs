using Microsoft.VisualStudio.TestTools.UnitTesting;
using ViagensOnline.Repositorios.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViagensOnline.Dominio;

namespace ViagensOnline.Repositorios.SqlServer.Tests
{
    [TestClass()]
    public class ViagensOnlineDbContextTests
    {
        //Todo Field é privado
        private ViagensOnlineDbContext _db = new ViagensOnlineDbContext(); 

        [TestMethod()]
        public void InserirTeste()
        {
            //Instaciando uma classe
            var destino = new Destino();

            //Criando Objeto
            destino.Cidade = "São Pailo";
            destino.Nome = "Conheça São Paulo";
            destino.NomeImagem = "Paulista.png";
            destino.Pais = "Brasil";

            //Este é o Insert do Entity
            _db.Destinos.Add(destino);

            //Este é o comando que execulta a tarefa no banco 
            _db.SaveChanges();

        }

        [TestMethod]
        public void AtualizaTeste()
        {
            //Nosso objeto de conexão. Minha tabela. Método(parametro)
            var destino = _db.Destinos.Find(1);

            destino.Pais = "Irlanda";

            _db.SaveChanges();

        }

        [TestMethod]
        public void ExcluuirTeste()
        {
            var destino = _db.Destinos.Find(1);

            //Para Excluir tem que ser o objeto ou seja tudo, Não pode ser apenas um campo específico.
            _db.Destinos.Remove(destino);

            _db.SaveChanges();
        }
    }
}