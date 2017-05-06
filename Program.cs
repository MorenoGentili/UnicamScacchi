using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using Scacchi.Modello;
using Scacchi.Modello.Pezzi;

namespace Scacchi
{
    class Program
    {
        static void Main(string[] args)
        {
<<<<<<< HEAD
            SimpleXUnitRunner.SimpleXUnit.RunTests();

            Console.ReadKey();
         
=======
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            //Console.SetWindowSize(100, 30);
            //SimpleXUnitRunner.SimpleXUnit.RunTests();
            //Console.ReadKey();
            GiocaPartita();
        }

        private static void GiocaPartita() {
            IScacchiera scacchiera = new Scacchiera();
            IOrologio orologio = new Orologio();
            IBloccoNote bloccoNote = new BloccoNote();
            ITavolo tavolo = new Tavolo(scacchiera, orologio, bloccoNote);
            bool partitaInCorso = true;
            tavolo.Vittoria += (sender, colore) => {
                Console.Clear();
                Console.WriteLine($"Vince {tavolo.Giocatori[colore].Nome} ({colore})!");
                partitaInCorso = false;
                tavolo.FinisciPartita();
            };
            Console.Write("Giocatore bianco: ");
            string giocatoreBianco = Console.ReadLine();

            Console.Write("Giocatore nero: ");
            string giocatoreNero = Console.ReadLine();
            tavolo.RiceviGiocatori(giocatoreBianco, giocatoreNero);
            tavolo.AvviaPartita();
            bool errore = false;
            bool automatico = false;
            while (partitaInCorso) {
                Console.Clear();
                Colore coloreDiTurno = orologio.TurnoAttuale;
                Console.WriteLine($"{tavolo.Giocatori[Colore.Bianco].Nome} ({Colore.Bianco}) VS {tavolo.Giocatori[Colore.Nero].Nome} ({Colore.Nero})");
                Console.WriteLine();
                Disegna(scacchiera);
                Console.WriteLine();
                if (errore)
                    Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"Muove {tavolo.Giocatori[coloreDiTurno].Nome} ({coloreDiTurno}): ");
                Console.ForegroundColor = ConsoleColor.White;
                string mossa;
                if (automatico){
                    mossa = DeterminaMossa(scacchiera, orologio.TurnoAttuale);
                    Console.Write(mossa);
                    Thread.Sleep(200);
                 } else {
                    mossa = Console.ReadLine();
                 }
                if (mossa.Equals("auto", StringComparison.OrdinalIgnoreCase)) {
                    automatico = true;
                    mossa = DeterminaMossa(scacchiera, orologio.TurnoAttuale);
                    Console.Write(mossa);
                    Thread.Sleep(200);
                }

                try{
                    errore = false;
                    tavolo.InserisciMossa(mossa);
                } catch (Exception) {
                    errore = true;
                    automatico = false;
                }
            }
            Console.ReadLine();
        }

        private static void Disegna(IScacchiera scacchiera) {
        for (var i = 8; i>=1; i--){
                Console.Write(i);
                Console.Write(" ");
                
                for (var j = 1; j<=8; j++) {
                    Console.BackgroundColor = (i+j) % 2 != 0 ? ConsoleColor.Black : ConsoleColor.DarkGray;
                    var pezzo = scacchiera[(Colonna) j, (Traversa) i].PezzoPresente;
                    var carattere = pezzo != null ? pezzo.Carattere : ' ';
                    Console.Write($" {carattere} ");
                }
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine(" ");
            }
            Console.Write("  ");
            for (var i = 1; i<=8; i++){
                Console.Write($" {(Colonna)i} ");
            }
            Console.WriteLine();
        }

        private static string DeterminaMossa(IScacchiera scacchiera, Colore colore){
            var pezziGiocabili = scacchiera.Case.Where(casa => casa.PezzoPresente?.Colore == colore).OrderBy(casa => Guid.NewGuid()).ToList();
            foreach (var pezzoGiocabile in pezziGiocabili) {
                var destinazioneScelta = scacchiera
                .Case.ToList()
                .Where(casa => casa.PezzoPresente==null || casa.PezzoPresente.Colore != colore)
                .OrderBy(casa => Guid.NewGuid())
                .FirstOrDefault(casa => pezzoGiocabile.PezzoPresente.PuòMuovere(pezzoGiocabile.Colonna, pezzoGiocabile.Traversa, casa.Colonna, casa.Traversa, scacchiera.Case));
                if (destinazioneScelta == null)
                    continue;
                return $"{pezzoGiocabile.Colonna}{(int) pezzoGiocabile.Traversa} {destinazioneScelta.Colonna}{(int) destinazioneScelta.Traversa}";
            }
            return "";
>>>>>>> 61b3805c943602fbd9c12831296fd3405e55d23b
        }

        /*var pedone1 = new Pedone(Colore.Bianco);
            var pedone2 = new Pedone(Colore.Bianco);
            Console.WriteLine(pedone1.Equals(pedone2));

            var dizionario = new Dictionary<Pedone, string>();
            dizionario.Add(pedone1, "Moreno");
            if (!dizionario.ContainsKey(pedone2)) {
              dizionario.Add(pedone2, "Moreno");
            }

            Console.ReadKey();

            /*Dictionary<int, IScacchiera> partite = new Dictionary<int, IScacchiera>();
            int contatore = 1;
            partite.Add(contatore, new Scacchiera());

            //L'utente ha mosso un pezzo
            int chiave = 2;
            if (partite.ContainsKey(chiave)) {
                Console.WriteLine(partite[chiave].Case.Count());
            } else {
                Console.WriteLine("Non riesco a trovare questa partita");
            }*/


            /*IScacchiera scacchiera = new Scacchiera();
            scacchiera
            .Case
            .ConPezzi(Colore.Bianco)
            .DiTipo<Pedone>();*/
<<<<<<< HEAD

=======
        /*
        private static void NotificaSconfitta(object sender, Colore colore)
        {
            Console.WriteLine($"(Dal metodo): Il giocatore {colore} ha perso la partita, secondo l'orologio {sender}!");
        }
        */
>>>>>>> 61b3805c943602fbd9c12831296fd3405e55d23b
    }
}
