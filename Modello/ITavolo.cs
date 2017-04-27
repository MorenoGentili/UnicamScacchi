
using System.Collections.Generic;

namespace Scacchi.Modello{
    public interface ITavolo {
        void RiceviGiocatori(string nomeBianco, string nomeNero);
        Dictionary<Colore,IGiocatore> Giocatori {get;}
        void AvviaPartita();
        IScacchiera Scacchiera { get; }
        IOrologio Orologio { get; }
        void InserisciMossa(string mossa);

    }
}
