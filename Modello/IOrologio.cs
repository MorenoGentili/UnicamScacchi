using System;

namespace Scacchi.Modello {
    public interface IOrologio {
        TimeSpan TempoResiduoBianco {get;}
        TimeSpan TempoResiduoNero {get;}
        Colore TurnoAttuale {get;}
        TimeSpan TempoIniziale {get;}

        void Accendi();
        void Avvia();
        void Pausa();
        void Reset();
        void FineTurno();
        event EventHandler<Colore> TempoScaduto;
    }
}