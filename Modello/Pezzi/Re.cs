using static Scacchi.Funzioni.Matematica;

namespace Scacchi.Modello.Pezzi{
    public class Re : IPezzo
    {
        private readonly Colore colore;

        public Re(Colore colore)
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
            int spostamentoTraversa = ValoreAssoluto(traversaArrivo - traversaPartenza);
            int spostamentoColonna = ValoreAssoluto(colonnaArrivo - colonnaPartenza);

            if(spostamentoColonna == 1 && (spostamentoTraversa == 0 || spostamentoTraversa == 1)){
                    return true;
            } else if (spostamentoTraversa == 1 && ( spostamentoColonna == 0 || spostamentoColonna == 1)){
                return true;
            } else {
                return false;
            }
            
        }
    }
}