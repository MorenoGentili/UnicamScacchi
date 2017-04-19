using System;
namespace Scacchi.Modello.Pezzi
{
    public class Cavallo : IPezzo
    {
        private readonly Colore colore;
        public Cavallo(Colore colore)
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
            //so che il cavallo può muoversi due caselle in orizzontale e una verticale o viceversa
            int differenzaColonne = Math.Abs((int)colonnaArrivo - (int)colonnaPartenza);
            int differenzaTraverse = Math.Abs((int)traversaArrivo - (int)traversaPartenza);
            //controllo che il cavallo si sia mosso di una sola colonna 
            if (differenzaColonne==1 && differenzaTraverse==2){
                return true;
            }
            else if(differenzaColonne==2 && differenzaTraverse==1){
                return true;
            }
            // se sono qui la posizione non è ammissibile
                return false;
        }

        public bool PuòMuovere(Colonna colonnaPartenza, Traversa traversaPartenza, Colonna colonnaArrivo, Traversa traversaArrivo, IScacchiera scacchiera = null)
        {
            throw new NotImplementedException();
        }
    }
}