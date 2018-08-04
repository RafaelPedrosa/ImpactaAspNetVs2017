using System;
using System.Collections.Generic;

namespace Oficina.Dominio
{
    //Abstract - não pode ser instanciada (new)
    public abstract class Veiculo
    {
        //public Veiculo()
        //{
        //    Id = Guid.NewGuid();
        //}

        public Guid Id { get; set; } = Guid.NewGuid();

        private string _placa;
        
        //ToDo: OO - encapsulamento
        public string Placa
        {
            get { return _placa.ToUpper(); }
            set { _placa = value.ToUpper(); }
        }
        
        //public string Placa
        //{
        //    get //Get = Obter
        //    {
        //        return Placa.ToUpper();
        //    }
        //    set //Set = Atribuir
        //    {
        //        _placa = value.ToUpper();

        //    }
        //}

        public int Ano { get; set; }
        public string Observacao { get; set; }

        public Modelo Modelo { get; set; }
        public Cor Cor { get; set; }

        public Combustivel Combustivel { get; set; }
        public Cambio Cambio { get; set; }

        public abstract List<String> Validar();

        public List<string> ValidarBase()
        {
            var erros = new List<string>();

            if (Ano <= 1940 || (Ano - DateTime.Now.Year >= 2))
            {
                erros.Add($"O ano informado {Ano} é inválido");
            }

            return erros;
        }

    }
}
