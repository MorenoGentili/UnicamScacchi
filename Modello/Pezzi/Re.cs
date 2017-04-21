using System;
using System.Collections.Generic;

namespace Scacchi.Modello.Pezzi {
    public class Re : IPezzo
    {
        private readonly Colore colore;
        public Re(Colore colore)
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
            var differenzaColonne = colonnaPartenza - colonnaArrivo;
            var differenzaTraverse = (int) traversaPartenza - (int) traversaArrivo;
            if (differenzaColonne == 0 && differenzaTraverse == 0)
                return false;
            if(Math.Abs(differenzaColonne) <= 1 && Math.Abs(differenzaTraverse) <= 1)
            {
            return true;
            }else{
                return false;
            }
        }
    }
}