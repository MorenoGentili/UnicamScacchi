using System;
using System.Threading;

namespace Scacchi.Modello
{
    public class Orologio : IOrologio
    {

        public Orologio() : this(TimeSpan.FromMinutes(Orologio.TempoInizialeInMinuti))
        {
        }

        public Orologio(TimeSpan tIniziale)
        {
            this.tIniziale = tIniziale;
            timer = new Timer(ControllaTempoResiduo, null, TimeSpan.Zero, TimeSpan.FromSeconds(1));
        }

        private void ControllaTempoResiduo(object state)
        {
            if (TempoResiduoGiocatore1 <= TimeSpan.Zero || TempoResiduoGiocatore2 <= TimeSpan.Zero)
                  TempoScaduto?.Invoke(this, null);
        }

        private TimeSpan tIniziale;

        private Timer timer;

        private TimeSpan tempoResiduoGiocatore1;
        public TimeSpan TempoResiduoGiocatore1
        {
            get
            {

                if(TurnoGiocatore == TurnoGiocatore.Giocatore1 && !paused)
                    TempoResiduoGiocatore1 = 
                        tIniziale - (DateTime.Now - partenzaOrologio);
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
                        tIniziale - (DateTime.Now - partenzaOrologio);
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

        public const int TempoInizialeInMinuti = 5;
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
                tempoResiduoGiocatore1 = tIniziale;//TimeSpan.FromMinutes(TempoInizialeInMinuti);
                TurnoGiocatore = TurnoGiocatore.Giocatore2;
            } else {
                TempoResiduoGiocatore2 = tIniziale;//TimeSpan.FromMinutes(TempoInizialeInMinuti);
                TurnoGiocatore = TurnoGiocatore.Giocatore1;
            }
            Avvia();
        }

        public void Reset()
        {
            Pausa();
            TempoResiduoGiocatore1 = tIniziale;//TimeSpan.FromMinutes(TempoInizialeInMinuti);
            TempoResiduoGiocatore2 = tIniziale;//TimeSpan.FromMinutes(TempoInizialeInMinuti);
        }
    }
}