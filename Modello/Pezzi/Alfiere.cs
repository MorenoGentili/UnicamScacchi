using System;

namespace Scacchi.Modello.Pezzi {
    public class Alfiere : IPezzo
    {
        private readonly Colore colore;
        public Alfiere(Colore colore)
        {
            this.colore = colore;    
        }
        public Colore Colore {
            get {
                return colore;
            }
        }
        public bool PuòMuovere(Colonna colonnaPartenza, Traversa traversaPartenza, Colonna colonnaArrivo, Traversa traversaArrivo)
        {
            // var stessaColonna = colonnaPartenza == colonnaArrivo;
            // var stessaTraversa = traversaPartenza == traversaArrivo;
            var distanzaTraLeTraverse = Math.Abs((int)(traversaArrivo - traversaPartenza));
            var distanzaTraLeColonne = Math.Abs((int)(colonnaArrivo - colonnaPartenza));
            if(distanzaTraLeColonne == distanzaTraLeTraverse){
                return true;
            } else {
                return false;
            }
        }
    }

}