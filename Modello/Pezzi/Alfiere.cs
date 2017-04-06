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
            int spostamentoTraversa = ValoreAssoluto(traversaArrivo - traversaPartenza);
            int spostamentoColonna = ValoreAssoluto(colonnaArrivo - colonnaPartenza);

            
            if(spostamentoColonna == 0 && spostamentoTraversa == 0){ // Non può restare fermo
                return false;
            } else {
                if( (spostamentoColonna - spostamentoTraversa) == 0){
                    return true;
                } else {
                    return false;
                }
            }   

        }

        private int ValoreAssoluto(int numero){
            if(numero < 0)
                return -numero;
            
            return numero;
        }
    }
}