using System;

namespace Scacchi.Modello.Pezzi{
    public class Donna : IPezzo
    {
        private readonly Colore colore;

        public Donna(Colore colore){
            this.colore = colore;
        }

        public Colore Colore {
            get{
                return this.colore;
            }
        }

        public bool PuòMuovere(Colonna colonnaPartenza, Traversa traversaPartenza, Colonna colonnaArrivo, Traversa traversaArrivo)
        {
            throw new NotImplementedException();
        }
    }
}