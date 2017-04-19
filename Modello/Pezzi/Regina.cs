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
            if (colonnaArrivo == colonnaPartenza && traversaPartenza != traversaArrivo)
            {
                return true;
            }
            //faccio in modo che la regina possa muoversi lateralmente
            else if (colonnaArrivo != colonnaPartenza && (traversaPartenza == traversaArrivo))
            {
                return true;
            }
            else if (colonnaArrivo != colonnaPartenza && traversaPartenza != traversaArrivo)
            {
                //per vedere se l'alfiere si sta muovendo nella direzione giusta 
                //basta controllare se la distanza percorsa è "quadrata" 
                //nel senso che la differenza tra le colonne e le traverse in valore assoluto deve essere uguale!
                int distanzaColonne = Math.Abs((int)colonnaPartenza - (int)colonnaArrivo);
                int distanzaTraverse = Math.Abs((int)traversaPartenza - (int)traversaArrivo);
                if (distanzaColonne == distanzaTraverse)
                {
                    return true;
                }
            }
            //Se sono qui la regina si sta spostando in una posizione non ammissibile!
            return false;
        }

        public bool PuòMuovere(Colonna colonnaPartenza, Traversa traversaPartenza, Colonna colonnaArrivo, Traversa traversaArrivo, IScacchiera scacchiera = null)
        {
            throw new NotImplementedException();
        }
    }
}