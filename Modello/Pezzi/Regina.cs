using System;

namespace Scacchi.Modello.Pezzi
{
    public class Regina : IPezzo
    {
        public Regina(Colore colore)
        {
            this.colore = colore;
        }
        private readonly Colore colore;
        public Colore Colore
        {
            get
            {
                return this.colore;
            }
        }

        public bool PuòMuovere(Colonna colonnaPartenza, Traversa traversaPartenza, Colonna colonnaArrivo, Traversa traversaArrivo)
        {
            //controllo che la regina possa muoversi verticalmente dove vuole
            if (colonnaArrivo == colonnaPartenza)
            {
                return true;
            }

            return false;
        }
    }
}