using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevInBank.App.Entities
{
    public class ContaCorrente : Conta
    {
        public string TipoConta { get; } = "Conta Corrente";
        private decimal ChequeEspecial { get; set; }
        public ContaCorrente(string nome, string cpf, string endereco, decimal rendaMensal, string agencia) : base(nome, cpf, endereco, rendaMensal, agencia)
        {
            ChequeEspecial = rendaMensal * 0.1m;
        }

        public decimal GetChequeEspecial()
        {
            return ChequeEspecial;
        }

        public override void AlterarDados(string nome, string endereco, decimal rendaMensal, string agencia)
        {
            base.AlterarDados(nome, endereco, rendaMensal, agencia);
            ChequeEspecial = rendaMensal * 0.1m;
        }

        public override void AlterarDados(string nome, string endereco, decimal rendaMensal)
        {
            base.AlterarDados(nome, endereco, rendaMensal);
            ChequeEspecial = rendaMensal * 0.1m;
        }

        public override void Deposito(decimal valor)
        {
            if (VerificaSaldoCheque(valor))
            {
                base.Deposito(valor);
            }
        }

        public override void Saque(decimal valor)
        {
            if (VerificaSaldoCheque(valor))
            {
                base.Saque(valor);
            }

        }

        public override void Transferencia(int valor, Conta contaDestino)
        {
            if (VerificaSaldoCheque(valor))
            {
                base.Transferencia(valor, contaDestino);
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
