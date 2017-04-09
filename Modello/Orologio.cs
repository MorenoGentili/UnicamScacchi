using System;
using System.Threading;

namespace Scacchi.Modello
{
    public class Orologio : IOrologio
    {
        private const int tempoInizialeInMinutiDefault = 5;
        private readonly TimeSpan tempoIniziale;

        private readonly Timer timer;

        public Orologio() : this(TimeSpan.FromMinutes(tempoInizialeInMinutiDefault))
        {
        }

        internal Orologio(TimeSpan tIniziale)
        {
            this.tempoIniziale = tIniziale;
            timer = new Timer(ControllaTempoResiduo, null, TimeSpan.Zero, TimeSpan.FromMilliseconds(50));
        }

        private void ControllaTempoResiduo(object state)
        {
            if (!inPausa && TempoResiduoBianco <= TimeSpan.Zero || TempoResiduoNero <= TimeSpan.Zero) {
                inPausa = true;
                TempoScaduto?.Invoke(this, null);
            }
        }

        
        public TimeSpan TempoIniziale {
            get{
                return tempoIniziale;
            }
        }
        private TimeSpan tempoResiduoBianco;
        public TimeSpan TempoResiduoBianco
        {
            get
            {

                if(TurnoAttuale == Colore.Bianco && !inPausa)
                    TempoResiduoBianco = 
                        tempoIniziale - (DateTime.Now - partenzaOrologio);
                return tempoResiduoBianco;
            }
            private set
            {
                tempoResiduoBianco = value;
            }
        }

        private TimeSpan tempoResiduoNero;
        public TimeSpan TempoResiduoNero
        {
            get
            {
                if(TurnoAttuale == Colore.Nero && !inPausa)
                    tempoResiduoNero = 
                        tempoIniziale - (DateTime.Now - partenzaOrologio);
                return tempoResiduoNero;
            }
            private set
            {
                tempoResiduoNero = value;
            }
        }

        private Colore turnoAttuale = Colore.Bianco;
        public Colore TurnoAttuale
        {
            get
            {
                return turnoAttuale;
            }
            set
            {
                turnoAttuale = value;
            }
        }


        public event EventHandler TempoScaduto;

        private bool acceso = false;
        public void Accendi()
        {
            acceso = true;
            inPausa = true;
            Reset();
        }

        private DateTime partenzaOrologio = DateTime.MinValue;
        private bool inPausa = true;
        public void Avvia()
        {
            if(!acceso)
                throw new InvalidOperationException(
                    "L'Orologio deve essere acceso, per poter essere avviato!");
            partenzaOrologio = DateTime.Now;
            inPausa = false;
        }

        public void Pausa()
        {
            inPausa = true;
        }

        public void FineTurno() {
            if(TurnoAttuale == Colore.Bianco) {
                tempoResiduoBianco = tempoIniziale;
                TurnoAttuale = Colore.Nero;
            } else {
                TempoResiduoNero = tempoIniziale;
                TurnoAttuale = Colore.Bianco;
            }
            Avvia();
        }

        public void Reset()
        {
            Pausa();
            TempoResiduoBianco = tempoIniziale;
            TempoResiduoNero = tempoIniziale;
        }
    }
}