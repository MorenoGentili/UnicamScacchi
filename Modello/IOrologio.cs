using System;

namespace Scacchi.Modello {
    public interface IOrologio {
        TimeSpan TempoResiduoGiocatore1 {get;}
        TimeSpan TempoResiduoGiocatore2 {get;}
        TurnoGiocatore TurnoGiocatore {get;set;}

        void Accendi();
        void Avvia();
        void Pausa();
        void Reset();
        //This should be placed in the interface? I think yes.
        void FineTurno();

        event EventHandler TempoScaduto;
    }
}