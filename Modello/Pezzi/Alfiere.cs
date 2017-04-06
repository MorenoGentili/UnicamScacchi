using System;

namespace Scacchi.Modello.Pezzi{
    public class Alfiere : IPezzo
    {
        public Alfiere(Colore colore){
            this.colore=colore;
        }
        private readonly Colore colore;
        public Colore Colore {
            get{
                return this.colore;
            }
        }

        public bool PuòMuovere(Colonna colonnaPartenza, Traversa traversaPartenza, Colonna colonnaArrivo, Traversa traversaArrivo)
        {
            return false;
        }
    }
}