using DevInBank.App.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevInBank.App.Menu
{
    public class MenuMinhaConta
    {
        public static void MinhaConta()
        {
            Console.Clear();

            string seletor = "0";
            while (seletor != "4")
            {
                int i = 0;
                Console.WriteLine($"{++i}. Conta Corrente");
                Console.WriteLine($"{++i}. Conta Poupança");
                Console.WriteLine($"{++i}. Conta Investimento");
                Console.WriteLine($"{++i}. Voltar para o menu principal");
                Console.WriteLine($"{++i}. Encerrar sessão");

                seletor = Console.ReadLine();

                switch (seletor)
                {
                    case "1":
                        Console.Clear();
                        MinhaContaCorrente();
                        break;
                    case "2":
                        Console.Clear();
                        MinhaContaPoupanca();
                        break;
                    case "3":
                        Console.Clear();
                        MinhaContaInvestimento();
                        break;
                    case "4":
                        Console.Clear();
                        MenuPrincipal.MenuInicial();
                        break;
                    case "5":
                        Console.WriteLine("Encerrando aplicação...");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine($"{seletor} não é uma opção válida");
                        break;
                }
            }
        }

        public static void MinhaContaCorrente()
        {
            string numConta;
            Console.WriteLine("Informe o número da conta:");
            numConta = Console.ReadLine();
            var minhaConta = ContaCorrente.ListaContasCorrente.Find(e => e.NumConta == Convert.ToInt32(numConta));

            while (minhaConta == null)
            {
                numConta = ContaInválida();
                minhaConta = ContaCorrente.ListaContasCorrente.Find(e => e.NumConta == Convert.ToInt32(numConta));

            }

            string seletor = "0";
            while (seletor != "1" || seletor != "5")
            {
                int i = 0;
                Console.WriteLine($"{++i}. Saldo");
                Console.WriteLine($"{++i}. Saque");
                Console.WriteLine($"{++i}. Depósito");
                Console.WriteLine($"{++i}. Transferência");
                Console.WriteLine($"{++i}. Extrato");
                Console.WriteLine($"{++i}. Saldo Cheque Especial");
                Console.WriteLine($"{++i}. Alterar dados cadastrais");
                Console.WriteLine($"{++i}. Voltar para o menu principal");
                Console.WriteLine($"{++i}. Encerrar sessão");

                seletor = Console.ReadLine();

                switch (seletor)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine($"Saldo: R${minhaConta.GetSaldo()}");
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("Insira o valor que deseja sacar:");
                        string valor = Console.ReadLine();
                        minhaConta.Saque(Convert.ToDecimal(valor));
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("Insira o valor que deseja depositar:");
                        valor = Console.ReadLine();
                        minhaConta.Deposito(Convert.ToDecimal(valor));
                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine("Insira o valor que deseja depositar:");
                        valor = Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine("Insira o número da conta destino:");
                        string numContaDestino = Console.ReadLine();
                        var contaDestino = Conta.ListaContas.Find(e => e.NumConta == Convert.ToInt32(numContaDestino));
                        minhaConta.Transferencia(Convert.ToDecimal(valor), contaDestino);
                        break;
                    case "5":
                        Console.Clear();
                        minhaConta.GetExtrato();
                        break;
                    case "6":
                        Console.Clear();
                        MenuPrincipal.MenuInicial();
                        break;
                    case "7":
                        Console.Clear();
                        MenuPrincipal.MenuInicial();
                        break;
                    case "8":
                        Console.WriteLine("Encerrando aplicação...");
                        Environment.Exit(0);
                        break;
                    case "9":
                        Console.WriteLine("Encerrando aplicação...");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine($"{seletor} não é uma opção válida");
                        break;
                }
            }
        }

        public static void MinhaContaPoupanca()
        {
            string numConta;
            Console.WriteLine("Informe o número da conta:");
            numConta = Console.ReadLine();
            var minhaConta = ContaPoupanca.ListaContasPoupanca.Find(e => e.NumConta == Convert.ToInt32(numConta));

            while (minhaConta == null)
            {
                numConta = ContaInválida();
                minhaConta = ContaPoupanca.ListaContasPoupanca.Find(e => e.NumConta == Convert.ToInt32(numConta));

            }

            string seletor = "0";
            while (seletor != "1" || seletor != "5")
            {
                int i = 0;
                Console.WriteLine($"{++i}. Saldo");
                Console.WriteLine($"{++i}. Saque");
                Console.WriteLine($"{++i}. Depósito");
                Console.WriteLine($"{++i}. Transferência");
                Console.WriteLine($"{++i}. Extrato");
                Console.WriteLine($"{++i}. Simular Rendimento");
                Console.WriteLine($"{++i}. Alterar dados cadastrais");
                Console.WriteLine($"{++i}. Voltar para o menu principal");
                Console.WriteLine($"{++i}. Encerrar sessão");

                seletor = Console.ReadLine();

                switch (seletor)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine($"Saldo: R${minhaConta.GetSaldo()}");
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine($"Saldo em conta: R${minhaConta.GetSaldo()}");
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("Criando conta poupança");
                        break;
                    case "4":
                        Console.Clear();
                        MenuPrincipal.MenuInicial();
                        break;
                    case "5":
                        Console.Clear();
                        MenuPrincipal.MenuInicial();
                        break;
                    case "6":
                        Console.Clear();
                        MenuPrincipal.MenuInicial();
                        break;
                    case "7":
                        Console.Clear();
                        MenuPrincipal.MenuInicial();
                        break;
                    case "8":
                        Console.WriteLine("Encerrando aplicação...");
                        Environment.Exit(0);
                        break;
                    case "9":
                        Console.WriteLine("Encerrando aplicação...");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine($"{seletor} não é uma opção válida");
                        break;
                }
            }

        }

        public static void MinhaContaInvestimento()
        {
            string numConta;
            Console.WriteLine("Informe o número da conta:");
            numConta = Console.ReadLine();
            var minhaConta = ContaInvestimento.ListaContasInvestimento.Find(e => e.NumConta == Convert.ToInt32(numConta));

            while (minhaConta == null)
            {
                numConta = ContaInválida();
                minhaConta = ContaInvestimento.ListaContasInvestimento.Find(e => e.NumConta == Convert.ToInt32(numConta));

            }

            string seletor = "0";
            while (seletor != "1" || seletor != "5")
            {
                int i = 0;
                Console.WriteLine($"{++i}. Saldo");
                Console.WriteLine($"{++i}. Saque");
                Console.WriteLine($"{++i}. Depósito");
                Console.WriteLine($"{++i}. Transferência");
                Console.WriteLine($"{++i}. Extrato");
                Console.WriteLine($"{++i}. Simular Aplicação");
                Console.WriteLine($"{++i}. Alterar dados cadastrais");
                Console.WriteLine($"{++i}. Voltar para o menu principal");
                Console.WriteLine($"{++i}. Encerrar sessão");

                seletor = Console.ReadLine();

                switch (seletor)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine($"Saldo: R${minhaConta.GetSaldo()}");
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine($"Saldo em conta: R${minhaConta.GetSaldo()}");
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("Criando conta poupança");
                        break;
                    case "4":
                        Console.Clear();
                        MenuPrincipal.MenuInicial();
                        break;
                    case "5":
                        Console.Clear();
                        MenuPrincipal.MenuInicial();
                        break;
                    case "6":
                        Console.Clear();
                        MenuPrincipal.MenuInicial();
                        break;
                    case "7":
                        Console.Clear();
                        MenuPrincipal.MenuInicial();
                        break;
                    case "8":
                        Console.WriteLine("Encerrando aplicação...");
                        Environment.Exit(0);
                        break;
                    case "9":
                        Console.WriteLine("Encerrando aplicação...");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine($"{seletor} não é uma opção válida");
                        break;
                }
            }
        }

        static string ContaInválida()
        {
            Console.Clear();
            Console.WriteLine("Conta inválida!");
            Console.WriteLine("Informe o número da conta ou 'x' para voltar ao menu principal:");
            string numConta = Console.ReadLine();

            if (numConta == "x" || numConta == "X")
            {
                Console.Clear();
                MenuPrincipal.MenuInicial();
            }

            return numConta;
        }

    }
}
