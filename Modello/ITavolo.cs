
using System;
using System.Collections.Generic;

namespace Scacchi.Modello{
    public interface ITavolo {
        void RiceviGiocatori(string nomeBianco, string nomeNero);
        IReadOnlyDictionary<Colore,IGiocatore> Giocatori {get;}
        void AvviaPartita();

        void FinisciPartita();
        IScacchiera Scacchiera { get; }
        IOrologio Orologio { get; }
        void InserisciMossa(string mossa);

        event EventHandler<Colore> Vittoria;


    }
}
