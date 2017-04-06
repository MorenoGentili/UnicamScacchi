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
            //faccio in modo che la regina possa muoversi verticalmente dove vuole
            if (colonnaArrivo == colonnaPartenza && traversaPartenza!=traversaArrivo)
            {
                return true;
            }
            //faccio in modo che la regina possa muoversi lateralmente
            if (colonnaArrivo != colonnaPartenza && (traversaPartenza==traversaArrivo))
            {
                return true;
            }

            return false;
        }
    }
}