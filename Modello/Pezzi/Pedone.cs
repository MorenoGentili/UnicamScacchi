
using System;

namespace Scacchi.Modello.Pezzi
{
    public class Pedone : IPezzo
    {
        private readonly Colore colore;
        public Pedone(Colore colore)
        {
            this.colore = colore;
        }
        public Colore Colore
        {
            get
            {
                return colore;
            }
        }
        public bool PuòMuovere(
            Colonna colonnaPartenza,
            Traversa traversaPartenza,
            Colonna colonnaArrivo,
            Traversa traversaArrivo)
        {
            //devo eseguire un if per controllare il colore del pedone
            //se è nero la traversa di arrivo è minore di quella di partenza
            //altrimenti il contrario
            if (this.Colore == Colore.Nero && ((int)traversaArrivo < (int)traversaPartenza))
            {
                //va bene 
                //se sono qui va tutto bene e la partenza 
                var stessaColonna = colonnaPartenza == colonnaArrivo;
                var distanzaTraLeTraverse = Math.Abs((int)traversaPartenza - (int)traversaArrivo);
                var distanzaTraLeColonne = Math.Abs((int)colonnaArrivo - (int)colonnaPartenza);
                //devo controllare la se la traversa di partenza è uguale a 2 perchè se 
                //la par
                if (stessaColonna && distanzaTraLeTraverse == 1)
                {
                    return true;
                }
                //può muoversi diagonalmente solo se c'è una pedina
                else if (distanzaTraLeColonne == 1 && distanzaTraLeTraverse == 1)
                {
                    return true;

                }
                else if (stessaColonna && distanzaTraLeTraverse == 2 && (int)traversaPartenza == 7)
                {
                    //devo controllare il caso in cui sia alla linea di partenza del pedone, in quel caso posso
                    //Avanzare di due
                    return true;
                }
                else
                {
                    return false;
                }
            }
            //ora controllo il bianco
            if (this.Colore == Colore.Bianco && ((int)traversaArrivo > (int)traversaPartenza))
            {
                //va bene 
                //se sono qui va tutto bene e la partenza 
                var stessaColonna = colonnaPartenza == colonnaArrivo;
                var distanzaTraLeTraverse = (int)traversaArrivo - (int)traversaPartenza;
                var distanzaTraLeColonne = Math.Abs((int)colonnaArrivo - (int)colonnaPartenza);
                //devo controllare la se la traversa di partenza è uguale a 2 perchè se 
                //la par
                if (stessaColonna && distanzaTraLeTraverse == 1)
                {
                    return true;
                }
                //può muoversi diagonalmente solo se c'è una pedina
                else if (distanzaTraLeColonne == 1 && distanzaTraLeTraverse == 1)
                {
                    return true;
                }
                else if (stessaColonna && distanzaTraLeTraverse == 2 && (int)traversaPartenza == 2)
                {
                    //devo controllare il caso in cui sia alla linea di partenza del pedone, in quel caso posso
                    //Avanzare di due
                    return true;
                }
                else
                {
                    return false;
                }
            }
            //se sono qui si è sicuramente verificato un errore
            return false;


        }

        public bool PuòMuovere(Colonna colonnaPartenza, Traversa traversaPartenza, Colonna colonnaArrivo, Traversa traversaArrivo, IScacchiera scacchiera = null)
        {
            throw new NotImplementedException();
        }
    }
}