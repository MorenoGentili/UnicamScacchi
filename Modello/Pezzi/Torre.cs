using System;

namespace Scacchi.Modello.Pezzi{
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

        public bool PuòMuovere(Colonna colonnaPartenza, Traversa traversaPartenza, Colonna colonnaArrivo, Traversa traversaArrivo)
        {
            var stessaColonna = colonnaPartenza == colonnaArrivo;
            var stessaRiga = traversaPartenza == traversaArrivo;

            // Faccio lo XOR
            if (stessaColonna ^ stessaRiga){

            }
            throw new NotImplementedException();
        }
    }
}