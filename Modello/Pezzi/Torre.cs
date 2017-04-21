using System;
using System.Collections.Generic;

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
        public bool PuòMuovere(
            Colonna colonnaPartenza,
            Traversa traversaPartenza,
            Colonna colonnaArrivo,
            Traversa traversaArrivo,
           IEnumerable<ICasa> listaCase = null)
        {
            var stessaColonna = colonnaPartenza == colonnaArrivo;
            var stessaTraversa = traversaPartenza == traversaArrivo;

            if((stessaTraversa && !stessaColonna) || (stessaColonna && !stessaTraversa)){
                return true;
            }else{
                return false;
            }
            
        }
    }
}