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
                Console.WriteLine($"{++i}. Listar todas as contas");
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
                        ListarContas();
                        Utilitario.OperacaoRealizada();
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("HISTÓRICO DE TRANSFERÊNCIAS");
                        HistoricoTransferencia.GetHistoricoTransferencia();
                        Utilitario.OperacaoRealizada();
                        break;
                    case "3":
                        Console.Clear();
                        ListarContasNegativas();
                        Utilitario.OperacaoRealizada();
                        break;
                    case "4":
                        Console.Clear();
                        TotalInvestido();
                        Utilitario.OperacaoRealizada();
                        break;
                    case "5":
                        Console.Clear();
                        MenuPrincipal.MenuInicial();
                        break;
                    case "6":
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

        static void TotalInvestido()
        {
            decimal totalInvestido = 0;

            foreach (var item in ContaPoupanca.ListaContasPoupanca)
            {
                totalInvestido += item.GetSaldo();
            }

            foreach (var item in ContaInvestimento.ListaContasInvestimento)
            {
                totalInvestido += item.ValorAplicado;
            }

            Console.WriteLine($"O valor total Investido no momento é de R${totalInvestido}");
        }

        static void ListarContas()
        {
            Console.WriteLine("CONTAS CADASTRADAS");

            foreach (var item in Conta.ListaContas)
            {
                Console.WriteLine($"Tipo: {item.TipoConta}");
                Console.WriteLine($"Número: {item.NumConta}");
                Console.WriteLine($"Titular: {item.Nome}");
                Console.WriteLine($"Agencia: {item.Agencia}");
                Console.WriteLine("-----------------------------");
            }
        }

        static void ListarContasNegativas()
        {
            Console.WriteLine("CONTAS COM SALDO NEGATIVO");

            var contasNegativas = Conta.ListaContas.FindAll(e => e.GetSaldo() < 0);

            foreach (var item in contasNegativas)
            {
                Console.WriteLine($"Tipo: {item.TipoConta}");
                Console.WriteLine($"Número: {item.NumConta}");
                Console.WriteLine($"Titular: {item.Nome}");
                Console.WriteLine($"Agencia: {item.Agencia}");
                Console.WriteLine("-----------------------------");
            }
        }
    }
}
