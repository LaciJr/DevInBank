using DevInBank.App.Entities;
using DevInBank.App.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevInBank.App.Menu
{
    public class Utilitario
    {
        public static string SetAgencia()
        {
            string agencia = "";
            string seletor;
            while (agencia == "")
            {
                var i = MenuEnum.i;
                Console.WriteLine("Selecione a agencia desejada:");
                Console.WriteLine($"{++i}. para agencia 001 - Florianopolis");
                Console.WriteLine($"{++i}. para agencia 002 - São José");
                Console.WriteLine($"{++i}. para agencia 003 - Biguaçu");

                seletor = Console.ReadLine();

                switch (seletor)
                {
                    case "1":
                        Console.Clear();
                        agencia = "001 - Florianopolis";
                        break;
                    case "2":
                        Console.Clear();
                        agencia = "002 - São José";
                        break;
                    case "3":
                        Console.Clear();
                        agencia = "003 - Biguaçu";
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine($"{seletor} não é uma opção válida");
                        break;
                }
            }

            return agencia;
        }

        public static void OperacaoRealizada()
        {
            Console.WriteLine("Pressione qualquer tecla para sair.");
            Console.ReadKey();
            Console.Clear();
        }

        public static string ContaInvalida()
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
            Console.Clear();
            return numConta;
        }

        public static string SelecionarContas()
        {
            string seletor = "0";
            string conta = "";
            while (conta == "")
            {
                var i = MenuEnum.i;
                Console.WriteLine($"{++i}. Conta Corrente");
                Console.WriteLine($"{++i}. Conta Poupança");
                Console.WriteLine($"{++i}. Conta Investimento");
                Console.WriteLine($"{++i}. Voltar para o menu principal");
                Console.WriteLine($"{++i}. Encerrar sessão");

                seletor = Console.ReadLine();

                switch (seletor)
                {
                    case "1":
                        conta = "Conta Corrente";
                        Console.Clear();
                        break;
                    case "2":
                        conta = "Conta Poupanca";
                        Console.Clear();
                        break;
                    case "3":
                        conta = "Conta Investimento";
                        Console.Clear();
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
            return seletor;
        }

        public static bool ValidaCPF(string cpf)

        {

            if (cpf.Length != 11)
            {
                return false;
            }

            bool igual = true;

            for (int i = 1; i < 11 && igual; i++) 
            {
                if (cpf[i] != cpf[0]) igual = false;
            }

            if (igual) return false;

            int[] numeros = new int[11];

            for (int i = 0; i < 11; i++)
            {
                numeros[i] = int.Parse(cpf[i].ToString());
            }

            int soma = 0;

            for (int i = 0; i < 9; i++)
            {
                soma += (10 - i) * numeros[i];
            }

            int resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[9] != 0) return false;
            }
            else if (numeros[9] != 11 - resultado) return false;

            soma = 0;

            for (int i = 0; i < 10; i++)
            {
                soma += (11 - i) * numeros[i];
            }

            resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[10] != 0) return false;
            }
            else if (numeros[10] != 11 - resultado) return false;

            return true;

        }

        public static string VerificaExisteConta(int numConta)
        {
            string tipoConta = "";
            if (ContaCorrente.ListaContasCorrente.Find(e => e.NumConta == Convert.ToInt32(numConta)) != null) tipoConta = "Conta Corrente";
            if (ContaPoupanca.ListaContasPoupanca.Find(e => e.NumConta == Convert.ToInt32(numConta)) != null) tipoConta = "Conta Poupança";
            if (ContaInvestimento.ListaContasInvestimento.Find(e => e.NumConta == Convert.ToInt32(numConta)) != null) tipoConta = "Conta Investimento";

            return tipoConta;
        }

        public static void UpdateSaldos()
        {
            foreach (var item in ContaPoupanca.ListaContasPoupanca)
            {
                item.Render();
            }

            foreach (var item in ContaInvestimento.ListaContasInvestimento)
            {
                item.RetirarValorAplicado();
            }
        }
    }
}
