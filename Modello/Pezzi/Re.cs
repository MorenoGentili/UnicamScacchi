
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
            int differenzaTraverse = Math.Abs((int)traversaArrivo - (int)traversaPartenza);
            int differenzaColonne = Math.Abs((int)colonnaArrivo - (int)colonnaPartenza);

            //implemento il movimento verticale
            if (differenzaColonne==0 && differenzaTraverse==1) {
                return true;
            }
            //il movimento orizzontale
            else if(differenzaTraverse==0 && differenzaColonne==1){
                return true;
            }
            //movimento diagonale
            else if(differenzaColonne==1 && differenzaTraverse==1){
                return true;
            }
            return false;
        }
    }
}