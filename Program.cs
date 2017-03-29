using System;
using System.Threading;
using Scacchi.Modello;

namespace Scacchi
{
    class Program
    {
        static void Main(string[] args)
        {
            IOrologio orologio = new Orologio();
            orologio.Accendi();
            Console.WriteLine("Avvio il timer e mi metto in attesa per 2 secondi...");
            orologio.Avvia();
            Thread.Sleep(2000); //Il tempo di attesa va indicato in millisecondi
            Console.WriteLine($"Il tempo residuo e' di: {orologio.TempoResiduoGiocatore1}");
            Console.ReadKey();
        }
    }
}
