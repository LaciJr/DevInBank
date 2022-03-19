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

        public Transacao(string tipo, decimal valor)
        {
            Tipo = tipo;
            Valor = valor;
            Data = DateTime.Now;
        }
    }
}
