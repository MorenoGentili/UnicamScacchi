using System;
using System.Collections.Generic;
using Scacchi.Modello;
using Scacchi.Modello.Pezzi;

namespace Scacchi.Modello
{
    public class Tavolo : ITavolo
    {


        public Tavolo(IScacchiera scacchiera, IOrologio orologio)
        {
            Scacchiera = scacchiera;
            Orologio = orologio;
        }
        public Dictionary<Colore, IGiocatore> Giocatori { get; private set; }

        public IScacchiera Scacchiera { get; private set; }
        public IOrologio Orologio { get; private set; }

        public void AvviaPartita()
        {
            if (Giocatori == null)
                throw new InvalidOperationException("Attenzione, prima devi indicare i nomi dei giocatori!");

            Orologio.Accendi();
            Orologio.Avvia();
            Orologio.TempoScaduto += FinisciPartita;
            Scacchiera.Vittoria += FinisciPartita;
        }

        public void FinisciPartita(object sender, Colore colore) {
            Orologio.Reset();
            Scacchiera = new Scacchiera();
            Giocatori = null;
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
            casaArrivo.PezzoPresente = casaPartenza.PezzoPresente;
            casaPartenza.PezzoPresente = null;
            //Controllo che il re non sia stato mangiato
            if(Orologio.TurnoAttuale == Colore.Bianco) {
                Scacchiera.ReInVita(Colore.Nero);
            } else {
                Scacchiera.ReInVita(Colore.Bianco);
            }
            Orologio.FineTurno();
        }

        internal Coordinata InterpretaCoordinataCasa(string casa)
        {
            Enum.TryParse<Colonna>(casa.Substring(0, 1), out Colonna colonna);
            int.TryParse(casa.Substring(1, 1), out int traversaInt);
            Traversa traversa = (Traversa)traversaInt;
            return new Coordinata(traversa, colonna);
        }


        public void RiceviGiocatori(string nomeBianco, string nomeNero)
        {
            Giocatori = new Dictionary<Colore, IGiocatore>();
            Giocatori.Add(Colore.Bianco, new Giocatore(nomeBianco));
            Giocatori.Add(Colore.Nero, new Giocatore(nomeNero));
        }
    }
}
