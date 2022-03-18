using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevInBank.App.Entities
{
    public class HistoricoTransferencia
    {
        public Conta ContaOrigem { get; private set; }
        public Conta ContaDestino { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime Data { get; private set; }
        public int IdTransacao { get; private set; }
        static int GeradorIdTransacao = 001;
        public static List<HistoricoTransferencia> ListaHistoricoTransferencia { get; private set; } = new List<HistoricoTransferencia>();

        public HistoricoTransferencia(Conta contaOrigem, Conta contaDestino, decimal valor)
        {
            IdTransacao = GeradorIdTransacao;
            GeradorIdTransacao++;
            ContaOrigem = contaOrigem;
            ContaDestino = contaDestino;
            Valor = valor;
            Data = DateTime.Now;
        }
    }
}
