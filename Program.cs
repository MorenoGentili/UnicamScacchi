using System;
using Scacchi.Modello;

namespace Scacchi
{
    class Program
    {
        static void Main(string[] args)
        {
            SimpleXUnitRunner.SimpleXUnit.RunTests();

            Console.ReadKey();

            //La sottoscrizione all'evento TempoScaduto è stata spostata
            //in un test in OrologioTest.cs (vedi in fondo al file, riga 180)
        }

    }
}
