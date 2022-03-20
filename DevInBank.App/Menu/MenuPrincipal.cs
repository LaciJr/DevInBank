using DevInBank.App.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevInBank.App.Menu
{
    public class MenuPrincipal
    {
        public static void MenuInicial()
        {
            string seletor = "0";
            while (seletor != "4")
            {
                var i = MenuEnum.i;
                Console.WriteLine("Menu Principal:");
                Console.WriteLine($"{++i}. Criar Conta");
                Console.WriteLine($"{++i}. Minha conta");
                Console.WriteLine($"{++i}. Relatórios");
                Console.WriteLine($"{++i}. Encerrar sessão");

                seletor = Console.ReadLine();

                switch (seletor)
                {
                    case "1":
                        Console.Clear();
                        MenuCriarConta.CriarConta();
                        break;
                    case "2":
                        Console.Clear();
                        MenuMinhaConta.MinhaConta();
                        break;
                    case "3":
                        Console.Clear();
                        MenuRelatorio.Relatorio();
                        break;
                    case "4":
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
