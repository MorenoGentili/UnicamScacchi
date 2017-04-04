using System;
using System.Threading;
using Scacchi.Modello;

namespace Scacchi
{
    class Program
    {
        static void Main(string[] args)
        {
            SimpleXUnitRunner.SimpleXUnit.RunTests();
            Console.ReadKey();
            /*IOrologio orologio = new Orologio();
            try {
                orologio.Avvia();
            } catch (InvalidOperationException ex) {
                Console.WriteLine("Questa eccezione dovrebbe essere lanciata:" +
                    ex.Message);
            }
            orologio.Accendi();
            Console.WriteLine("Avvio il timer e mi metto in attesa per 2 secondi...");
            orologio.Avvia();
            Thread.Sleep(2000); //Il tempo di attesa va indicato in millisecondi
            Console.WriteLine($"Il tempo residuo e' di: {orologio.TempoResiduoGiocatore1}");
            orologio.Pausa();
            Thread.Sleep(2000);
            Console.WriteLine("Non dovrebbe essere cambiato il tempo residuo" +  
                $"perchè messo in pausa: {orologio.TempoResiduoGiocatore1}");
            orologio.FineTurno();
            Thread.Sleep(2000);
            Console.WriteLine($"Tempo giocatore1 (NON E' IL SUO TURNO): {orologio.TempoResiduoGiocatore1} \n" +  
                $"Tempo giocatore2 (DOVREBBE ESSERE INFERIORE): {orologio.TempoResiduoGiocatore2}");
            Console.ReadKey(); */
        }
    }
}
