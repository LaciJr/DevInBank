using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevInBank.App.Entities
{
    public class ContaPoupanca : Conta
    {
        public static List<ContaPoupanca> ListaContasPoupanca = new List<ContaPoupanca>();

        public ContaPoupanca(string nome, string cpf, string endereco, decimal rendaMensal, string agencia) : base(nome, cpf, endereco, rendaMensal, agencia)
        {
            base.TipoConta = "Conta Poupança";
        }

        public decimal SimularRendimento(int tempoEmMeses, double porcentagemDeRentabilidadeAnual)
        {
            var saldo = base.Saldo;
            decimal rentabilidade = (decimal)Math.Pow(1 +((porcentagemDeRentabilidadeAnual / 100)/12),tempoEmMeses);
            var saldoFinal = Math.Round(saldo * rentabilidade, 2);
            return saldoFinal;
        }

        public override void Saque(decimal valor)
        {
            if(base.Saldo >= valor)
            {
                base.Saque(valor);
            }
            else
            {
                Console.WriteLine("Saldo Insuficiente.");
            }
        }

        public override void Transferencia(decimal valor, int numContaDestino, Conta conta)
        {
            if (base.Saldo >= valor)
            {
                base.Transferencia(valor, numContaDestino, conta);
            }
            else
            {
                Console.WriteLine("Saldo Insuficiente.");
            }
        }

        public void Render()
        {
            var saldoFinal = SimularRendimento(36, 7);
            base.Saldo = saldoFinal;
        }
    }
}
