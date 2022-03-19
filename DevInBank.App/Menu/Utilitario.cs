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
                int i = 0;
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
    }
}
