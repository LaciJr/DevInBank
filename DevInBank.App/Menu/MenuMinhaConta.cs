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
            Console.WriteLine("Selecione o tipo da sua conta:");

            var tipoConta = Utilitario.SelecionarContas();

            switch (tipoConta)
            {
                case "1":
                    MenuMinhaContaCorrente.MinhaContaCorrente();
                    break;
                case "2":
                    MenuMinhaContaPoupanca.MinhaContaPoupanca();
                    break;
                case "3":
                    MenuMinhaContaInvestimento.MinhaContaInvestimento();
                    break;
                default:
                    Console.WriteLine("Tipo de conta inválida");
                    break;
            }
        }

        public static void AlterarDadosCadastrais(Conta conta)
        {
            Console.Clear();

            string seletor = "0";
            while (seletor != "5")
            {
                int i = 0;
                Console.WriteLine("Qual dado você deseja alterar?");
                Console.WriteLine($"{++i}. Nome");
                Console.WriteLine($"{++i}. Endereço");
                Console.WriteLine($"{++i}. Renda Mensal");
                Console.WriteLine($"{++i}. Agencia");
                Console.WriteLine($"{++i}. Voltar");
                Console.WriteLine($"{++i}. Encerrar sessão");

                seletor = Console.ReadLine();

                var nome = conta.Nome;
                var endereco = conta.Endereco;
                var rendaMensal = conta.RendaMensal;
                var agencia = conta.Agencia;

                switch (seletor)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("Insira o novo nome:");
                        nome = Console.ReadLine();
                        conta.AlterarDados(nome);
                        Console.WriteLine("Nome alterado.");
                        Utilitario.OperacaoRealizada();
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("Insira o novo endereço:");
                        endereco = Console.ReadLine();
                        conta.AlterarDados(nome, endereco);
                        Console.WriteLine("Endereço alterado.");
                        Utilitario.OperacaoRealizada();
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("Insira a nova renda mensal:");
                        rendaMensal = Convert.ToDecimal(Console.ReadLine());
                        Console.WriteLine("Renda mensal alterada.");
                        conta.AlterarDados(nome, endereco, rendaMensal);
                        Utilitario.OperacaoRealizada();
                        break;
                    case "4":
                        Console.Clear();
                        agencia = Utilitario.SetAgencia();
                        conta.AlterarDados(nome, endereco, rendaMensal, agencia);
                        Console.WriteLine("Agencia alterada.");
                        Utilitario.OperacaoRealizada();
                        break;
                    case "5":
                        Console.Clear();
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
    }
}
