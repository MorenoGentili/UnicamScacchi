using static Scacchi.Funzioni.Matematica;

namespace Scacchi.Modello.Pezzi{
    public class Donna : IPezzo
    {
        private readonly Colore colore;

        public Donna(Colore colore){
            this.colore = colore;
        }

        public Colore Colore {
            get{
                return this.colore;
            }
        }

        public bool PuòMuovere(Colonna colonnaPartenza, Traversa traversaPartenza, Colonna colonnaArrivo, Traversa traversaArrivo)
        {
            int spostamentoTraversa = ValoreAssoluto(traversaArrivo - traversaPartenza);
            int spostamentoColonna = ValoreAssoluto(colonnaArrivo - colonnaPartenza);

            if (spostamentoColonna == 0 && spostamentoTraversa == 0){ // Non può stare fermo
                return false;
            } else {
                if(spostamentoColonna == spostamentoTraversa){
                    return true; // Si muove in diagonale (qualsiasi)
                } else if (spostamentoColonna == 0 || spostamentoTraversa == 0) { // Si è spostato in orizzontale o in verticale
                    return true;
                    
                }  else {
                    return false;
                } 
            }
        }
    }
}