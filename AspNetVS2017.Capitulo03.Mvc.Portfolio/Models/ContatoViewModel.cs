using System.ComponentModel.DataAnnotations;

namespace AspNetVS2017.Capitulo03.Mvc.Portfolio.Models
{
    public class ContatoViewModel
    {
        //Required é para dizer que o campo é obrigatório
        //Regular Expression é um conceito de verificar se um conteúdo esta reespietando um padrão
        //EmailAddres Verifica se o email digitado está no padrão de um email

        [Required]
        public string Nome { get; set; }

        //[RegularExpression()]
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Mensagem { get; set; }
        //prop + (tab tab) para criar o Modelo (Porpertis)
    }
}