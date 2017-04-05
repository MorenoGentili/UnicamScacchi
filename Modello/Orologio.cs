using System;

namespace Scacchi.Modello
{
    public class Orologio : IOrologio
    {
        private TimeSpan tempoResiduoGiocatore1;
        public TimeSpan TempoResiduoGiocatore1
        {
            get
            {

                if(TurnoGiocatore == TurnoGiocatore.Giocatore1 && !paused)
                    TempoResiduoGiocatore1 = 
                        TimeSpan.FromMinutes(tempoInizialeInMinuti) - (DateTime.Now - partenzaOrologio);
                return tempoResiduoGiocatore1;
            }
            private set
            {
                tempoResiduoGiocatore1 = value;
            }
        }

        private TimeSpan tempoResiduoGiocatore2;
        public TimeSpan TempoResiduoGiocatore2
        {
            get
            {
                if(TurnoGiocatore == TurnoGiocatore.Giocatore2 && !paused)
                    tempoResiduoGiocatore2 = 
                        TimeSpan.FromMinutes(tempoInizialeInMinuti) - (DateTime.Now - partenzaOrologio);
                return tempoResiduoGiocatore2;
            }
            private set
            {
                tempoResiduoGiocatore2 = value;
            }
        }

        private TurnoGiocatore turnoGiocatore = TurnoGiocatore.Giocatore1;
        public TurnoGiocatore TurnoGiocatore
        {
            get
            {
                return turnoGiocatore;
            }
            set
            {
                turnoGiocatore = value;
            }
        }


        public event EventHandler TempoScaduto;

        private const int tempoInizialeInMinuti = 5;
        //Da implementare acceso = false dopo alcuni minuti di inattività
        //probabilmente un tanto decantato evento
        private bool acceso = false;
        public void Accendi()
        {
            acceso = true;
            paused = true;
            Reset();
        }

        private DateTime partenzaOrologio = DateTime.MinValue;
        //boolean variable "paused" is used to keep the state of the system
        //we could also use a property, but boh let's go
        private bool paused = false;
        public void Avvia()
        {
            if(!acceso)
                throw new InvalidOperationException(
                    "L'Orologio deve essere acceso, per poter essere avviato!");
            partenzaOrologio = DateTime.Now;
            paused = false;
        }

        public void Pausa()
        {
            paused = true;
        }

        public void FineTurno() {
            if(TurnoGiocatore == TurnoGiocatore.Giocatore1) {
                tempoResiduoGiocatore1 = TimeSpan.FromMinutes(tempoInizialeInMinuti);
                TurnoGiocatore = TurnoGiocatore.Giocatore2;
            } else {
                TempoResiduoGiocatore2 = TimeSpan.FromMinutes(tempoInizialeInMinuti);
                TurnoGiocatore = TurnoGiocatore.Giocatore1;
            }
            Avvia();
        }

        public void Reset()
        {
            TempoResiduoGiocatore1 = TimeSpan.FromMinutes(tempoInizialeInMinuti);
            TempoResiduoGiocatore2 = TimeSpan.FromMinutes(tempoInizialeInMinuti);
        }
    }
}