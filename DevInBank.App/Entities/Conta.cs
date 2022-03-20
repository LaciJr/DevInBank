using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevInBank.App.Entities
{
    public class Conta
    {
        public string Nome { get; private set; }
        private string Cpf { get; set; }
        public string Endereco { get; private set; }
        public decimal RendaMensal { get; private set; }
        public int NumConta { get; private set; }
        public string Agencia { get; private set; }
        private protected decimal saldo { get; set; }
        public string TipoConta { get; internal set; }
        static int GeradorNumConta = 1;
        public List<Transacao> Extrato = new List<Transacao>();
        public static List<Conta> ListaContas = new List<Conta>();

        public Conta(string nome, string cpf, string endereco, decimal rendaMensal, string agencia)
        {
            Nome = nome;
            Cpf = cpf;
            Endereco = endereco;
            RendaMensal = rendaMensal;
            NumConta = GeradorNumConta;
            GeradorNumConta++;
            Agencia = agencia;
        }

        public virtual void Saque(decimal valor)
        {
            saldo -= valor;
            var temp = new Transacao("Saque", valor);
            Extrato.Add(temp);
            Console.WriteLine("Saque efetuado com sucesso.");
        }

        public virtual void Deposito(decimal valor)
        {
            saldo += valor;
            var temp = new Transacao("Deposito", valor);
            Extrato.Add(temp);
            Console.WriteLine("Deposito efetuado com sucesso.");
        }

        public decimal GetSaldo()
        {
            return saldo;
        }

        public void GetExtrato()
        {
            foreach (var item in Extrato)
            {
                Console.WriteLine(item.Tipo);
                Console.WriteLine($"R${item.Valor}");
                Console.WriteLine(item.Data);
                Console.WriteLine("---------------");
            }
        }

        public virtual void Transferencia(decimal valor, int numContaDestino, Conta contaOrigem)
        {
            var contaDestino = ListaContas.Find(e => e.NumConta == numContaDestino);
            //if (VerificaFinalDeSemana())
            //{
            //    Console.WriteLine("Transferência indisponível aos finais de semana.");
            //}
            //else if (NumConta == contaDestino.NumConta)
            //{
            //    Console.WriteLine("Conta destino inválida.");
            //}
            //else
            //{
            saldo -= valor;
            contaDestino.saldo += valor;
            var temp = new Transacao("Transferencia Enviada", valor);
            Extrato.Add(temp);
            temp = new Transacao("Transferencia Recebida", valor);
            contaDestino.Extrato.Add(temp);
            var tempHistorico = new HistoricoTransferencia("Transferência", valor, contaOrigem, contaDestino);
            HistoricoTransferencia.ListaHistoricoTransferencia.Add(tempHistorico);
            Console.WriteLine("Transferencia efetuada com sucesso.");
            //}
        }

        public void AlterarDados(string nome, string endereco, decimal rendaMensal, string agencia)
        {
            Nome = nome;
            Endereco = endereco;
            RendaMensal = rendaMensal;
            Agencia = agencia;
        }

        public void AlterarDados(string nome, string endereco, decimal rendaMensal)
        {
            Nome = nome;
            Endereco = endereco;
            RendaMensal = rendaMensal;
        }

        public void AlterarDados(string nome, string endereco)
        {
            Nome = nome;
            Endereco = endereco;
        }

        public void AlterarDados(string nome)
        {
            Nome = nome;
        }

        static bool VerificaFinalDeSemana()
        {
            var data = DateTime.Now;
            if ((data.DayOfWeek == DayOfWeek.Sunday) || (data.DayOfWeek == DayOfWeek.Saturday))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
