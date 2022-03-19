using DevInBank.App.Entities;
using DevInBank.App.Menu;
using System;

namespace DevInBank.App
{
    public class Program
    {
        static void Main()
        {
            var conta = new ContaCorrente("Laci", "09806779983", "Rua tal", 3000, "1");
            Console.WriteLine(conta.NumConta);
            ContaCorrente.ListaContasCorrente.Add(conta);

            var contaPoup = new ContaPoupanca("Eduarda", "10074799908", "Rua fulano", 2000, "1");
            Console.WriteLine(contaPoup.NumConta);
            ContaPoupanca.ListaContasPoupanca.Add(contaPoup);

            var contaInvest = new ContaInvestimento("Snow", "449974545", "Rua a esquerda", 42000, "2", "CDB");
            Console.WriteLine(contaInvest.NumConta);
            ContaInvestimento.ListaContasInvestimento.Add(contaInvest);

            Conta.ListaContas.AddRange(ContaCorrente.ListaContasCorrente);
            Conta.ListaContas.AddRange(ContaPoupanca.ListaContasPoupanca);
            Conta.ListaContas.AddRange(ContaInvestimento.ListaContasInvestimento);


            MenuPrincipal.MenuInicial();
            
         }
    }
}
