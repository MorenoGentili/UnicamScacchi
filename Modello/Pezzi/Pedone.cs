using System;

namespace Scacchi.Modello.Pezzi {
    public class Pedone : IPezzo
    {
        private readonly Colore colore;
        public Pedone(Colore colore)
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
            // nel caos il pedone si vuole muovere nella stessa colonna
            var stessaColonna = colonnaPartenza == colonnaArrivo;
            var distanzaTraLeTraverse = (int)(traversaArrivo - traversaPartenza);

            if(this.colore == Colore.Nero){
                if(stessaColonna && distanzaTraLeTraverse == -2 && traversaPartenza == Traversa.Settima){
                    return true;
                }
                if(stessaColonna && distanzaTraLeTraverse == -1){
                    return true;
                }else{
                    return false;
                }
            }
            if(this.colore == Colore.Bianco){
                if(stessaColonna && distanzaTraLeTraverse == 2 && traversaPartenza == Traversa.Seconda){
                    return true;
                }
                if(stessaColonna && distanzaTraLeTraverse == 1){
                    return true;
                } else {
                    return false;
                }
            }
            else{
                return false;
            }
        }
    }
}