using System;

namespace Scacchi.Modello.Pezzi {
    public class Donna : IPezzo
    {
        private readonly Colore colore;
        public Donna(Colore colore)
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
            var stessaColonna = colonnaPartenza == colonnaArrivo;
            var stessaTraversa = traversaPartenza == traversaArrivo;
            var distanzaTraLeTraverse = Math.Abs((int)(traversaArrivo - traversaPartenza));
            var distanzaTraLeColonne = Math.Abs((int)(colonnaArrivo - colonnaPartenza));
            if(stessaColonna && !stessaTraversa){
                return true;
            }
            if(stessaTraversa && !stessaColonna){
                return true;
            }
            if(distanzaTraLeColonne == distanzaTraLeTraverse && !stessaColonna && !stessaTraversa){
                return true;
            } else {
                return false;
            }
        }
    }

}