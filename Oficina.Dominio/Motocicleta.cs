using System;
using System.Collections.Generic;

namespace Oficina.Dominio
{
    public class Motocicleta : Veiculo //Herança Em orientação a Objeto
    {
        public TipoMotocicleta tipo { get; set; }

        public override List<String> Validar()
        {
            throw new System.NotImplementedException();
        }
    }
}
