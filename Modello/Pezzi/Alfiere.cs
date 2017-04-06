using System;

namespace Scacchi.Modello.Pezzi{
    public class Alfiere : IPezzo
    {
        private readonly Colore colore;

        public Alfiere(Colore colore){
            this.colore = colore;
        }
        
        public Colore Colore{
            get{
                return colore;
            }
        }

        public bool PuòMuovere(Colonna colonnaPartenza, Traversa traversaPartenza, Colonna colonnaArrivo, Traversa traversaArrivo)
        {
            throw new NotImplementedException();
        }
    }
}