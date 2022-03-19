using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevInBank.App.Entities
{
    public class ContaCorrente : Conta
    {
        private decimal ChequeEspecial { get; set; }
        public static List<ContaCorrente> ListaContasCorrente = new List<ContaCorrente>();
        public ContaCorrente(string nome, string cpf, string endereco, decimal rendaMensal, string agencia) : base(nome, cpf, endereco, rendaMensal, agencia)
        {
            ChequeEspecial = rendaMensal * 0.1m;
            base.TipoConta = "Conta Corrente";
        }

        public decimal GetChequeEspecial()
        {
            return ChequeEspecial;
        }

        public void SetChequeEspecial()
        {
            ChequeEspecial = base.RendaMensal * 0.1m;
        }

        public override void Saque(decimal valor)
        {
            if (VerificaSaldoCheque(valor))
            {
                base.Saque(valor);
            }

        }

        public override void Transferencia(decimal valor, int numContaDestino)
        {
            if (VerificaSaldoCheque(valor))
            {
                base.Transferencia(valor, numContaDestino);
            }
        }

        private bool VerificaSaldoCheque(decimal valor)
        {
            if (valor > (base.GetSaldo() + ChequeEspecial))
            {
                Console.WriteLine("Saldo insuficiente.");
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
