using System;

namespace Scacchi.Modello.Pezzi {
    public class Torre : IPezzo
    {
        private readonly Colore colore;
        public Torre(Colore colore)
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
            var distanzaTraLeTraverse = (int)(traversaArrivo - traversaPartenza);
            var distanzaTraLeColonne = (int)(colonnaArrivo - colonnaPartenza);
            if((stessaColonna && !stessaTraversa) || (!stessaColonna && stessaTraversa)){
                return true;
            } else {
                return false;
            }
        }
    }

}