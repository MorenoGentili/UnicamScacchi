using System;
using System.Collections.Generic;

namespace Scacchi.Modello.Pezzi {
    public class Re : Pezzo
    {
        private readonly Colore colore;
        public Re(Colore colore) : base(colore)
        {
            this.colore = colore;    
        }
        public override bool PuòMuovere(
            Colonna colonnaPartenza,
            Traversa traversaPartenza,
            Colonna colonnaArrivo,
            Traversa traversaArrivo, 
            IEnumerable<ICasa> listaCase = null)
        {
            bool mossaPossibile = base.PuòMuovere(colonnaPartenza,traversaPartenza,colonnaArrivo,traversaArrivo,listaCase);
            if (!mossaPossibile)
                return false;
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