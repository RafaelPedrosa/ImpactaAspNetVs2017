using System;
using System.Collections.Generic;

namespace Oficina.Dominio
{
    public class Caminhao : Veiculo
    {
        public QuantidadedeEixo QuantidadedeEixo { get; set; }

        public override List<String> Validar()
        {
            throw new System.NotImplementedException();
        }
    }
}
