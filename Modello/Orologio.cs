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
                TempoResiduoGiocatore1 = TimeSpan.FromMinutes(tempoInizialeInMinuti) - (DateTime.Now - partenzaOrologio);
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
        public void Accendi()
        {
            Reset();
        }

private DateTime partenzaOrologio = DateTime.MinValue;
        public void Avvia()
        {
            partenzaOrologio = DateTime.Now;
        }

        public void Pausa()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            TempoResiduoGiocatore1 = TimeSpan.FromMinutes(tempoInizialeInMinuti);
            TempoResiduoGiocatore2 = TimeSpan.FromMinutes(tempoInizialeInMinuti);
        }
    }
}