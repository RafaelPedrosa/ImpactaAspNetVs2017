using System;
using System.Collections.Generic;

namespace Oficina.Dominio
{
    //ToDo: OO - Classe ou Abstração
    //ToDo: OO : Veiculo - Herança

    public class VeiculoPasseio : Veiculo 
    {
        public TipoCarroceria Carroceria { get; set; }

        //OO - Polimorfismo por substituição.
        public override List<String> Validar()
        {
            var erros = base.ValidarBase();

            if (!Enum.IsDefined(typeof(TipoCarroceria), Carroceria))
            {
                erros.Add($"A Corroceria informada ({Carroceria})não é válida.");
            }

            return erros;
        }
    }
}
