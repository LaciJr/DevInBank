using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevInBank.App.Entities
{
    public class ContaPoupança : Conta
    {
        public string TipoConta { get; } = "Conta Poupança";
        public ContaPoupança(string nome, string cpf, string endereco, decimal rendaMensal, string agencia) : base(nome, cpf, endereco, rendaMensal, agencia)
        {
        }

        public decimal SimularRendimento(int tempoEmMeses, double porcentagemDeRentabilidadeAnual)
        {
            var saldo = GetSaldo();
            decimal rentabilidade = (decimal)Math.Pow(1 +(porcentagemDeRentabilidadeAnual / 100),tempoEmMeses);
            return saldo * rentabilidade;
        }
    }
}
