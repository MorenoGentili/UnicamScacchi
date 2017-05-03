using System;
using System.Collections.Generic;
using System.Linq;
using Scacchi.Modello;
using Scacchi.Modello.Pezzi;

namespace Scacchi.Modello
{
    public class Tavolo : ITavolo
    {


        public Tavolo(IScacchiera scacchiera, IOrologio orologio, IBloccoNote bloccoNote)
        {
            Scacchiera = scacchiera;
            Orologio = orologio;
            BloccoNote = bloccoNote;
        }
        public IReadOnlyDictionary<Colore, IGiocatore> Giocatori { get { return giocatori; } }

        public IBloccoNote BloccoNote{ get; private set;}
        public IScacchiera Scacchiera { get; private set; }
        public IOrologio Orologio { get; private set; }

        public event EventHandler<Colore> Vittoria;

        public void AvviaPartita()
        {
            if (Giocatori == null)
                throw new InvalidOperationException("Attenzione, prima devi indicare i nomi dei giocatori!");

            Orologio.Accendi();
            Orologio.Avvia();
            Orologio.TempoScaduto += (Orologio, colore) => {
                if(colore == Colore.Bianco)
                    Vittoria.Invoke(Orologio, Colore.Nero);
                else
                    Vittoria.Invoke(Orologio, Colore.Bianco);
            };
        }

        public void FinisciPartita() {
            Orologio.Reset();
            Scacchiera = new Scacchiera();
            giocatori = null;
        }

        public void InserisciMossa(string mossa)
        {

            Coordinata partenza = InterpretaCoordinataCasa(mossa.Substring(0, 2));
            Coordinata arrivo = InterpretaCoordinataCasa(mossa.Substring(3, 2));
            ICasa casaPartenza = Scacchiera[partenza.Colonna, partenza.Traversa];
            ICasa casaArrivo = Scacchiera[arrivo.Colonna, arrivo.Traversa];

            if (casaPartenza.PezzoPresente == null ||
                casaPartenza.PezzoPresente?.Colore != Orologio.TurnoAttuale ||
                casaArrivo.PezzoPresente?.Colore == Orologio.TurnoAttuale ||
                casaPartenza.PezzoPresente?.PuòMuovere(partenza.Colonna, partenza.Traversa,
                arrivo.Colonna, arrivo.Traversa, Scacchiera.Case) == false
                )
            {
                throw new InvalidOperationException("Mossa non valida");
            }

            Scacchiera.SpostaPezzo(casaPartenza, casaArrivo);
            BloccoNote.ScriviMossa(mossa);
            //Controllo che il re non sia stato mangiato
            Colore coloreControlloSconfitta;
            if(Orologio.TurnoAttuale == Colore.Bianco) {
                coloreControlloSconfitta = Colore.Nero;
            } else {
                coloreControlloSconfitta = Colore.Bianco;
            }
            bool reInVita = Scacchiera.ReInVita(coloreControlloSconfitta);
            if(!reInVita) {
                Vittoria.Invoke(Scacchiera, Orologio.TurnoAttuale);
            }
            Orologio.FineTurno();
        }

        internal Coordinata InterpretaCoordinataCasa(string casa)
        {
            bool risultatoParseColonna = Enum.TryParse<Colonna>(casa.Substring(0, 1), out Colonna colonna);
            bool risultatoParseTraversa = Enum.TryParse<Traversa>(casa.Substring(1, 1), out Traversa traversa);
            if(!risultatoParseColonna || !risultatoParseTraversa) {
                throw new InvalidOperationException("Input errato");
            }
            return new Coordinata(traversa, colonna);
        }


        private Dictionary<Colore, IGiocatore> giocatori;
        public void RiceviGiocatori(string nomeBianco, string nomeNero)
        {
            giocatori = new Dictionary<Colore, IGiocatore>();
            giocatori.Add(Colore.Bianco, new Giocatore(nomeBianco));
            giocatori.Add(Colore.Nero, new Giocatore(nomeNero));
        }
    }
}
