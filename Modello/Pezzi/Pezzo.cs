using System;
using System.Collections.Generic;

namespace Scacchi.Modello.Pezzi
{
    public abstract class Pezzo : IPezzo
    {
        public Pezzo(Colore colore)
        {
            Colore = colore;
        }

        public abstract char Carattere {get;}
        private Colore colore;
        public Colore Colore
        {
            get
            {
                return colore;
            }
            private set
            {
                colore = value;
            }
        }

        public override string ToString() {
            return $"{Carattere} {GetType().Name} {Colore}";
        }
        public virtual bool PuòMuovere(Colonna colonnaPartenza, Traversa traversaPartenza, Colonna colonnaArrivo, Traversa traversaArrivo, IEnumerable<ICasa> listaCase = null)
        {
            if (colonnaPartenza == colonnaArrivo && traversaPartenza == traversaArrivo)
                return false;

            return true;
        }
    }
}