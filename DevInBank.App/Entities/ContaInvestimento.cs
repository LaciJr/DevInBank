using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevInBank.App.Entities
{
    public class ContaInvestimento : Conta
    {
        public string TipoConta { get; } = "Conta Investimento";
        public string TipoInvest { get; private set; }
        public decimal ValorAplicado { get; private set; }
        public double Rentabilidade { get; private set; }
        public ContaInvestimento(string nome, string cpf, string endereco, decimal rendaMensal, string agencia, string tipoInvest) : base(nome, cpf, endereco, rendaMensal, agencia)
        {
            TipoInvest = tipoInvest;
            SetRentabilidade();
        }

        public decimal SimularValorAplicado(decimal valor, int tempoEmMeses)
        {
            var resultado = (valor * (decimal)Math.Pow(1 + (Rentabilidade/100), tempoEmMeses));
            return resultado;
        }

        public void AplicarValor(decimal valor, int tempoEmMeses)
        {
            ValorAplicado = valor;
            var dataRetirada = DateTime.Now;
            dataRetirada.AddMonths(tempoEmMeses);
            var temp = new Transacao("Aplicar valor", valor, dataRetirada);
            base.Extrato.Add(temp);
        }

        public void AlterarDados(string nome, string endereco, decimal rendaMensal, string agencia, string tipoInvest)
        {
            base.AlterarDados(nome, endereco, rendaMensal, agencia);
            TipoInvest = tipoInvest;
            SetRentabilidade();
        }

        private void SetRentabilidade()
        {
            switch (TipoInvest)
            {
                case "LCI":
                    Rentabilidade = 8;
                    break;
                case "LCA":
                    Rentabilidade = 9;
                    break;
                case "CDB":
                    Rentabilidade = 10;
                    break;
                default:
                    Console.WriteLine("Tipo de conta investimento inválida.");
                    break;
            }
        }

        public override void Saque(decimal valor)
        {
            if (base.GetSaldo() > valor)
            {
                base.Saque(valor);
            }
            else
            {
                Console.WriteLine("Saldo Insuficiente.");
            }
        }
    }
}
