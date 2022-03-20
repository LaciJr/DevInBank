using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevInBank.App.Entities
{
    public class HistoricoTransferencia : Transacao
    {
        public Conta ContaOrigem { get; private set; }
        public Conta ContaDestino { get; private set; }
        public static List<HistoricoTransferencia> ListaHistoricoTransferencia { get; private set; } = new List<HistoricoTransferencia>();

        public HistoricoTransferencia(string tipo, decimal valor, Conta contaOrigem, Conta contaDestino) : base(tipo, valor)
        {
            ContaOrigem = contaOrigem;
            ContaDestino = contaDestino;
        }

        public static void GetHistoricoTransferencia()
        {
            foreach (var item in ListaHistoricoTransferencia)
            {
                Console.WriteLine("CONTA DE ORIGEM");
                Console.WriteLine(item.ContaOrigem.TipoConta);
                Console.WriteLine($"Número da conta: {item.ContaOrigem.NumConta}");
                Console.WriteLine($"titular: {item.ContaOrigem.Nome}");
                Console.WriteLine("CONTA DESTINO");
                Console.WriteLine(item.ContaDestino.TipoConta);
                Console.WriteLine($"Número da conta: {item.ContaDestino.NumConta}");
                Console.WriteLine($"titular: {item.ContaDestino.Nome}");
                Console.WriteLine("");
                Console.WriteLine($"Valor: R${item.Valor}");
                Console.WriteLine($"Data da transferência: {item.Data}");
                Console.WriteLine("-----------------------------");
            }
        }
    }
}
