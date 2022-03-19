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
            var saldo = GetSaldo();
            decimal rentabilidade = (decimal)Math.Pow(1 +(porcentagemDeRentabilidadeAnual / 100),tempoEmMeses);
            return saldo * rentabilidade;
        }

        public override void Saque(decimal valor)
        {
            if(base.GetSaldo() > valor)
            {
                base.Saque(valor);
            }
            else
            {
                Console.WriteLine("Saldo Insuficiente.");
            }
        }

        public override void Transferencia(decimal valor, Conta contaDestino)
        {
            if (base.GetSaldo() > valor)
            {
                base.Transferencia(valor, contaDestino);
            }
            else
            {
                Console.WriteLine("Saldo Insuficiente.");
            }
        }
    }
}
