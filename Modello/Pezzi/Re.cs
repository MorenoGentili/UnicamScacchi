
using System;

namespace Scacchi.Modello.Pezzi
{
    public class Re : IPezzo
    {
        private readonly Colore colore;
        public Re(Colore colore)
        {
            this.colore = colore;
        }
        public Colore Colore
        {
            get
            {
                return this.colore;
            }
        }


        public bool PuòMuovere(Colonna colonnaPartenza, Traversa traversaPartenza, Colonna colonnaArrivo, Traversa traversaArrivo)
        {
            return false;
        }
    }
}