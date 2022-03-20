using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevInBank.App.Entities
{
    public class ContaInvestimento : Conta
    {
        public string TipoInvestimento { get; private set; }
        public decimal ValorAplicado { get; private set; }
        public double Rentabilidade { get; private set; }
        public static List<ContaInvestimento> ListaContasInvestimento = new List<ContaInvestimento>();

        public ContaInvestimento(string nome, string cpf, string endereco, decimal rendaMensal, string agencia, string tipoInvest) : base(nome, cpf, endereco, rendaMensal, agencia)
        {
            TipoInvestimento = tipoInvest;
            SetRentabilidade();
            base.TipoConta = "Conta Investimento";
        }

        public decimal SimularValorAplicado(decimal valor, int tempoEmMeses)
        {
            var resultado = (valor * (decimal)Math.Pow(1 + (Rentabilidade/12), tempoEmMeses));
            return resultado - valor;
        }

        public void AplicarValor(decimal valor, int tempoEmMeses)
        {
            if (ValidaTempoAplicacao(tempoEmMeses))
            {
                if (base.Saldo >= valor)
                {
                    base.Saldo -= valor;
                    ValorAplicado += valor;
                    var dataRetirada = DataSistema.Data;
                    dataRetirada.AddMonths(tempoEmMeses);
                    var temp = new Transacao("Valor aplicado", valor, dataRetirada, tempoEmMeses);
                    base.Extrato.Add(temp);
                    Console.WriteLine("Valor aplicado com sucesso.");
                }
                else
                {
                    Console.WriteLine("Saldo Insuficiente.");
                }
            }
            else
            {
                Console.WriteLine("Tempo não correspondente ao seu tipo de investimento (LCI, LCA, CDB)");
            }
        }

        public void RetirarValorAplicado()
        {
            var aplicacoes = base.Extrato.FindAll(e => e.Tipo == "Valor aplicado");
            var aplicacoesDisponiveis = aplicacoes.FindAll(e => DataSistema.Data >= e.DataRetirada);
            if (aplicacoesDisponiveis != null)
            {
                foreach (var item in aplicacoesDisponiveis)
                {
                    base.Extrato.Remove(item);
                    base.Saldo += (item.Valor * (decimal)Math.Pow(1 + (Rentabilidade / 12), item.TempoMeses));
                    ValorAplicado -= item.Valor;
                    var temp = new Transacao("Aplicação retirada", item.Valor);
                    base.Extrato.Add(temp);
                    
                }
            }
        }

        private void SetRentabilidade()
        {
            switch (TipoInvestimento)
            {
                case "LCI":
                    Rentabilidade = 0.08;
                    break;
                case "LCA":
                    Rentabilidade = 0.09;
                    break;
                case "CDB":
                    Rentabilidade = 0.1;
                    break;
                default:
                    Console.WriteLine("Tipo de conta investimento inválida.");
                    break;
            }
        }

        public override void Saque(decimal valor)
        {
            if (base.Saldo >= valor)
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

        private bool ValidaTempoAplicacao(int tempo)
        {
            switch (TipoInvestimento)
            {
                case "LCI":
                    if (tempo >= 6) return true;
                    else return false;
                case "LCA":
                    if (tempo >= 12) return true;
                    else return false;
                case "CDB":
                    if (tempo >= 36) return true;
                    else return false;
                default:
                    return false;
            }
        }
    }
}
