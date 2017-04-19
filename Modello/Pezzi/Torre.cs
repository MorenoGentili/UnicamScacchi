
using System;

namespace Scacchi.Modello.Pezzi
{
    public class Torre : IPezzo
    {
        private readonly Colore colore;
        public Torre(Colore colore)
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

            //se la traversa di partenza è la stessa traversa di arrivo allora la torre e le colonne sono diverse
            //si sta muovendo orizzontalmente
            if (((int)traversaPartenza == (int)traversaArrivo) && (colonnaPartenza != colonnaArrivo))
            {
                return true;
            }
            //Se la traversa di partenza è diversa da quella di fine e la colonna è la stessa
            // la torre si sta muovendo verticalmente
            else if (((int)traversaPartenza != (int)traversaArrivo) && (colonnaPartenza == colonnaArrivo))
            {
                return true;

            }
            //in tutti gli altri casi ritorno false
            else
            {
                return false;

            }
        }

        public bool PuòMuovere(Colonna colonnaPartenza, Traversa traversaPartenza, Colonna colonnaArrivo, Traversa traversaArrivo, IScacchiera scacchiera = null)
        {
            throw new NotImplementedException();
        }
    }
}