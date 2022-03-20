using DevInBank.App.Entities;
using DevInBank.App.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevInBank.App.Menu
{
    public class MenuMinhaContaPoupanca
    {
        public static void MinhaContaPoupanca(ContaPoupanca minhaConta)
        {
            string seletor = "0";
            while (seletor != "8")
            {
                Console.WriteLine($"Bem vindo(a)! {minhaConta.Nome}");
                Console.WriteLine("Minha Conta Poupança");
                var i = MenuEnum.i;
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
                        Utilitario.OperacaoRealizada();
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("Insira o valor que deseja sacar:");
                        string valorSaque = Console.ReadLine();
                        minhaConta.Saque(Convert.ToDecimal(valorSaque));
                        Utilitario.OperacaoRealizada(); ;
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("Insira o valor que deseja depositar:");
                        string valorDeposito = Console.ReadLine();
                        minhaConta.Deposito(Convert.ToDecimal(valorDeposito));
                        Utilitario.OperacaoRealizada();
                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine("Insira o valor que deseja transferir:");
                        string valorTransferencia = Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine("Insira o número da conta destino:");
                        string numContaDestino = Console.ReadLine();

                        if (numContaDestino == "") numContaDestino = "0";

                        var verifica = Utilitario.VerificaExisteConta(Convert.ToInt32(numContaDestino));
                        while (verifica == "")
                        {
                            numContaDestino = Utilitario.ContaInvalida();
                            if (numContaDestino == "") numContaDestino = "0";
                            verifica = Utilitario.VerificaExisteConta(Convert.ToInt32(numContaDestino));
                        }

                        minhaConta.Transferencia(Convert.ToDecimal(valorTransferencia), Convert.ToInt32(numContaDestino), minhaConta);
                        Utilitario.OperacaoRealizada();
                        break;
                    case "5":
                        Console.Clear();
                        minhaConta.GetExtrato();
                        Utilitario.OperacaoRealizada();
                        break;
                    case "6":
                        Console.Clear();
                        Console.WriteLine("Insira a quantidade de tempo em meses:");
                        string tempoMeses = Console.ReadLine();
                       
                        Console.Clear();
                        Console.WriteLine("Insira a rentabilidade anual da conta poupança em % (exemplo: 8):");
                        string rentabilidadePoupanca = Console.ReadLine();
                       
                        Console.Clear();
                        Console.WriteLine($"De acordo com seu saldo atual R${minhaConta.GetSaldo()}, no final dos {tempoMeses} meses você terá R${minhaConta.SimularRendimento(Convert.ToInt32(tempoMeses), Convert.ToDouble(rentabilidadePoupanca))}");
                        Utilitario.OperacaoRealizada();
                        break;
                    case "7":
                        Console.Clear();
                        MenuMinhaConta.AlterarDadosCadastrais(minhaConta);
                        break;
                    case "8":
                        Console.Clear();
                        MenuPrincipal.MenuInicial();
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
    }
}
