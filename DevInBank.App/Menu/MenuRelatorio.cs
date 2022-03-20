using DevInBank.App.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevInBank.App.Menu
{
    public class MenuRelatorio
    {
        public static void Relatorio()
        {
            string seletor = "0";
            while (seletor != "4")
            {
                int i = 0;
                Console.WriteLine("Relatórios:");
                Console.WriteLine($"{++i}. Histórico de transferências");
                Console.WriteLine($"{++i}. Contas com saldo negativo");
                Console.WriteLine($"{++i}. Total do valor investido");
                Console.WriteLine($"{++i}. Voltar para o menu principal");
                Console.WriteLine($"{++i}. Encerrar sessão");

                seletor = Console.ReadLine();

                switch (seletor)
                {
                    case "1":
                        Console.Clear();
                        HistoricoTransferencia.GetHistoricoTransferencia();
                        Utilitario.OperacaoRealizada();
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
