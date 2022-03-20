using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevInBank.App;
using DevInBank.App.Entities;

namespace DevInBank.App.Menu
{
    public class MenuCriarConta
    {
        public static void CriarConta()
        {
            Console.WriteLine("Selecione o tipo de conta que você quer criar:");
            var tipoConta = Utilitario.SelecionarContas();

            Console.WriteLine("Insira o nome do titular da conta:");
            string nome = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Insira o CPF do titular da conta (utilizando apenas números):");
            string cpf = Console.ReadLine();
            Console.Clear();
            while (!Utilitario.ValidaCPF(cpf))
            {
                Console.WriteLine("CPF inserido inválido!");
                Console.WriteLine("Insira um CPF válido (utilizando apenas números):");
                cpf = Console.ReadLine();
                Console.Clear();
            }

            Console.WriteLine("Insira o endereco do titular da conta:");
            string endereco = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Insira a renda mensal do titular da conta:");
            string rendaMensal = Console.ReadLine();
            Console.Clear();

            string agencia = Utilitario.SetAgencia();
            Console.Clear();

            switch (tipoConta)
            {
                case "1":
                    var contaCorrente = new ContaCorrente(nome, cpf, endereco, Convert.ToDecimal(rendaMensal), agencia);
                    ContaCorrente.ListaContasCorrente.Add(contaCorrente);
                    Conta.ListaContas.AddRange(ContaCorrente.ListaContasCorrente);
                    Console.WriteLine($"Conta criada com sucesso, anote o número da sua conta: {contaCorrente.NumConta} - Agencia: {contaCorrente.Agencia}.");
                    Utilitario.OperacaoRealizada();
                    break;
                case "2":
                    var contaPoupanca = new ContaPoupanca(nome, cpf, endereco, Convert.ToDecimal(rendaMensal), agencia);
                    ContaPoupanca.ListaContasPoupanca.Add(contaPoupanca);
                    Conta.ListaContas.AddRange(ContaPoupanca.ListaContasPoupanca);
                    Console.WriteLine($"Conta criada com sucesso, anote o número da sua conta: {contaPoupanca.NumConta} - Agencia: {contaPoupanca.Agencia}.");
                    Utilitario.OperacaoRealizada();
                    break;
                case "3":
                    CriarContaInvestimento(nome, cpf, endereco, Convert.ToDecimal(rendaMensal), agencia);
                    break;
                default:
                    Console.WriteLine("Tipo de conta inválida");
                    break;
            }

            static void CriarContaInvestimento(string nome, string cpf, string endereco, decimal rendaMensal, string agencia)
            {
                string tipoInvestimento = "";
                string seletor;
                ContaInvestimento contaInvestimento;

                while (tipoInvestimento == "")
                {
                    int i = 0;
                    Console.WriteLine("Selecione o tipo de investimento:");
                    Console.WriteLine($"{++i}. LCI 8% ao ano - Tempo mínimo de aplicação: 6 meses");
                    Console.WriteLine($"{++i}. LCA 9% ao ano - Tempo mínimo de aplicação: 12 meses");
                    Console.WriteLine($"{++i}. CDB 10% ao ano - Tempo mínimo de aplicação: 36 meses");

                    seletor = Console.ReadLine();

                    switch (seletor)
                    {
                        case "1":
                            Console.Clear();
                            tipoInvestimento = "LCI";
                            break;
                        case "2":
                            Console.Clear();
                            tipoInvestimento = "LCA";
                            break;
                        case "3":
                            Console.Clear();
                            tipoInvestimento = "CDB";
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine($"{seletor} não é uma opção válida");
                            break;
                    }
                }

                contaInvestimento = new ContaInvestimento(nome, cpf, endereco, Convert.ToDecimal(rendaMensal), agencia, tipoInvestimento);
                ContaInvestimento.ListaContasInvestimento.Add(contaInvestimento);
                Conta.ListaContas.AddRange(ContaInvestimento.ListaContasInvestimento);
                Console.WriteLine($"Conta criada com sucesso, anote o número da sua conta: {contaInvestimento.NumConta} - Agencia: {contaInvestimento.Agencia}.");
                Utilitario.OperacaoRealizada();
            }
        }
    }
}
