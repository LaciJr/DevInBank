using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevInBank.App.Entities
{
    public class Transacao
    {
        public string Tipo { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime Data { get; private set; }
        public DateTime DataRetirada { get; private set; }

        public int TempoMeses { get; private set; }
        public Transacao(string tipo, decimal valor)
        {
            Tipo = tipo;
            Valor = valor;
            Data = DataSistema.Data;
        }

        public Transacao(string tipo, decimal valor, DateTime dataRetirada, int tempo)
        {
            Tipo = tipo;
            Valor = valor;
            Data = DataSistema.Data;
            DataRetirada = dataRetirada;
            TempoMeses = tempo;
        }
    }
}
