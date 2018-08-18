using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViagensOnline.Dominio
{
    public class Destino
    {
        //Aqui é a necessidade de informação dentro da minha aplicação
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Pais { get; set; }
        public string Cidade { get; set; }
        public string NomeImagem { get; set; }

    }
}
