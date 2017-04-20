using System.Collections.Generic;

namespace Scacchi.Modello.Pezzi
{
    public interface IPezzo
    {
        //Muovi restituisce un bool che rappresenta l'esito della mossa
        //Se true: il pezzo ha potuto muoversi nella casa di destinazione
        //Se false: c'era qualcosa che gli impediva il movimento, come un pezzo "amico" dello stesso colore o un altro pezzo posto in mezzo tra partenza e destinazione
        //oppure la destinazione non era raggiungibile dal pezzo attuale (es. è stato chiesto ad una torre di muoversi in diagonale)
        bool PuòMuovere(
            Colonna colonnaPartenza,
            Traversa traversaPartenza,
            Colonna colonnaArrivo,
            Traversa traversaArrivo,
            IEnumerable<ICasa> listaCase = null);
        Colore Colore { get; }
    }
}