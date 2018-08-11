using Oficina.Dominio;
using Oficina.Repositorios.SistemaDeArquivos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Oficina.WebPages
{
    public class VeiculoAplicacao
    {
        private VeiculoRepositorio _veiculoRepositorio = new VeiculoRepositorio();
        private MarcaRepositorio _marcaRepositorio = new MarcaRepositorio();
        private ModeloRepositorio _modeloRepositorio = new ModeloRepositorio();
        private CorRepositorio _corRepositorio = new CorRepositorio();

        public List<Marca> Marcas { get; set; }
        public string MarcaSelecionada { get; set; }
        public List<Modelo> Modelos { get; set; } = new List<Modelo>();
        public List<Cor> Cores { get; set; }
        public List<Combustivel> Combustiveis { get; set; }
        public List<Cambio> Cambios { get; set; }

        public VeiculoAplicacao()
        {
            PopularControles();
        }

        private void PopularControles()
        {
            Marcas = _marcaRepositorio.Selecionar();

            MarcaSelecionada = HttpContext.Current.Request.QueryString["marcaId"];

            if (!string.IsNullOrEmpty(MarcaSelecionada))
            {
                Modelos = _modeloRepositorio.SelecionarPorMarca(Convert.ToInt32(MarcaSelecionada));
            }

            Cores = _corRepositorio.Selecionar();

            Combustiveis = Enum.GetValues(typeof(Combustivel))
                .Cast<Combustivel>().ToList();

            Cambios = Enum.GetValues(typeof(Cambio))
                .Cast<Cambio>().ToList();

        }

        public void Inserir()
        {
            try
            {
                var veiculo = new VeiculoPasseio();
                var formulario = HttpContext.Current.Request.Form;

                veiculo.Ano = Convert.ToInt32(formulario["ano"]);
                veiculo.Cambio = (Cambio)Convert.ToInt32(formulario["cambio"]);
                veiculo.Combustivel = (Combustivel)Convert.ToInt32(formulario["combustivel"]);
                veiculo.Cor = _corRepositorio.Selecionar(Convert.ToInt32(formulario["cor"]));
                veiculo.Modelo = _modeloRepositorio.Selecionar(Convert.ToInt32(formulario["modelo"]));
                veiculo.Observacao = formulario["observacao"];
                veiculo.Placa = formulario["placa"];
                veiculo.Carroceria = TipoCarroceria.Hatch;

                _veiculoRepositorio.Inserir(veiculo);
            }

            catch(FileNotFoundException ex)
            {
                HttpContext.Current.Items.Add("MensagemErro",$"Arquivo{ex.FileName} não encontrado.");
                throw;
            }

            catch ( UnauthorizedAccessException)
            {
                HttpContext.Current.Items.Add("MensagemErro", "Arquivo sem permissão de gravação.");
                throw;
            }

            catch (DirectoryNotFoundException)
            {
                HttpContext.Current.Items.Add("MensagemErro", "Caminho não encontrado.");
                throw;
            }


            catch (Exception excecao)
            {
                HttpContext.Current.Items.Add("MensagemErro", "Ops! Ocorreu um erro.");
                throw;
                //"Passa o erro para qualquer programa q pode vir depois"
                //throw excecao Mostra o erro apenas nesse Catch, qualquer erro que venha de camadas anteriores não séra mostrado, serve como um filtro de erro; 
                //Logar o objeto excecao.
                //log4net Componente para enviar os log's de erro para o banco de dados

            }
            finally
            {
                //Executado sempre, independente de sucesso ou erro.
                //Executado mesmo se tenha um return 
            }
        }

    }
}