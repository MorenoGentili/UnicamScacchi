
using System;

namespace Scacchi.Modello.Pezzi
{
    public class Alfiere : IPezzo
    {
        public Alfiere(Colore colore)
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
            //per vedere se l'alfiere si sta muovendo nella direzione giusta 
            //basta controllare se la distanza percorsa è "quadrata" 
            //nel senso che la differenza tra le colonne e le traverse in valore assoluto deve essere uguale!
            int distanzaColonne = Math.Abs((int)colonnaPartenza - (int)colonnaArrivo);
            int distanzaTraverse = Math.Abs((int)traversaPartenza - (int)traversaArrivo);

            if (distanzaColonne == distanzaTraverse)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}