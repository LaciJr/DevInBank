using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevInBank.App;

namespace DevInBank.App.Menu
{
    public class MenuCriarConta
    {
        public static void CriarConta()
        {
            Console.Clear();
            string seletor = "0";
            while (seletor != "4" || seletor != "5")
            {
                int i = 0;
                Console.WriteLine($"{++i}. Criar Conta Corrente");
                Console.WriteLine($"{++i}. Criar Conta Poupança");
                Console.WriteLine($"{++i}. Criar Conta Investimento");
                Console.WriteLine($"{++i}. Voltar para o menu principal");
                Console.WriteLine($"{++i}. Encerrar sessão");

                seletor = Console.ReadLine();

                switch (seletor)
                {
                    case "1":
                        Console.Clear();
                        break;
                    case "2":
                        Console.Clear();
                        break;
                    case "3":
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
        }
    }
}
