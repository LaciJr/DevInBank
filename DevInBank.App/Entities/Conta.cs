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
        private decimal saldo { get; set; }
        static int GeradorNumConta = 1000;
        public List<Transacao> Extrato { get; private set;}
        public static List<Conta> ListaContas { get; }

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
        }

        public virtual void Deposito(decimal valor)
        {
            saldo += valor;
            var temp = new Transacao("Deposito", valor);
            Extrato.Add(temp);
        }

        public decimal GetSaldo()
        {
            return saldo;
        }

        public string GetExtrato()
        {
            var ExtratoStr = Extrato.ToString();
            return ExtratoStr;
        }

        public virtual void Transferencia(int valor, Conta contaDestino)
        {
            if (VerificaFinalDeSemana())
            {
                Console.WriteLine("Transferência indisponível aos finais de semana.");
            }
            else if (NumConta == contaDestino.NumConta)
            {
                Console.WriteLine("Conta destino inválida.");
            }
            else
            {
                saldo -= valor;
                contaDestino.saldo += valor;
                var temp = new Transacao("Transferencia Enviada.", valor);
                Extrato.Add(temp);
                temp = new Transacao("Transferencia Recebida.", valor);
                contaDestino.Extrato.Add(temp);
            }
        }

        public virtual void AlterarDados(string nome, string endereco, decimal rendaMensal, string agencia)
        {
            Nome = nome;
            Endereco = endereco;
            RendaMensal = rendaMensal;
            Agencia = agencia;
        }

        public virtual void AlterarDados(string nome, string endereco, decimal rendaMensal)
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
