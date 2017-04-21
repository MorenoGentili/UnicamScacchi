using System;
using System.Collections.Generic;

namespace Scacchi.Modello.Pezzi {
    public class Cavallo : IPezzo
    {
        private readonly Colore colore;
        public Cavallo(Colore colore)
        {
            this.colore = colore;    
        }
        public Colore Colore {
            get {
                return colore;
            }
        }
        public bool PuòMuovere(
            Colonna colonnaPartenza,
            Traversa traversaPartenza,
            Colonna colonnaArrivo,
            Traversa traversaArrivo,
            IEnumerable<ICasa> listaCase = null)
        {
            var differenzaColonne = colonnaPartenza - colonnaArrivo;
            var differenzaTraverse = (int) traversaPartenza - (int) traversaArrivo;
            if(differenzaTraverse == 2 || differenzaTraverse == -2){
                if(differenzaColonne == 1 || differenzaColonne == -1){
                    return true;
                } else{
                    return false;
                }
            } else if(differenzaColonne == 2 || differenzaColonne == -2){
                
                if(differenzaTraverse == 1 || differenzaTraverse == -1){
                    return true;
                } else{
                    return false;
                }
            } else{
                return false;
            }
        }
    }
}