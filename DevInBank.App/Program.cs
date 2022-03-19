using DevInBank.App.Entities;
using DevInBank.App.Menu;
using System;

namespace DevInBank.App
{
    public class Program
    {
        static void Main()
        {
            var conta = new ContaCorrente("Laci", "09806779983", "Rua tal", 3000, "001");
            Console.WriteLine(conta.NumConta);
            ContaCorrente.ListaContasCorrente.Add(conta);

            MenuPrincipal.MenuInicial();
            
         }

    }
}
