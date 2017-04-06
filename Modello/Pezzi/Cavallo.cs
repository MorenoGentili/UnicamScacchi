using static Scacchi.Funzioni.Matematica;

namespace Scacchi.Modello.Pezzi{
    public class Cavallo : IPezzo
    {
        private readonly Colore colore;

        public Cavallo(Colore colore){
            this.colore = colore;
        }

        public Colore Colore{
            get {
                return this.colore;
            }
        }

        public bool PuòMuovere(Colonna colonnaPartenza, Traversa traversaPartenza, Colonna colonnaArrivo, Traversa traversaArrivo)
        {
            int spostamentoTraversa = ValoreAssoluto(traversaArrivo - traversaPartenza);
            int spostamentoColonna = ValoreAssoluto(colonnaArrivo - colonnaPartenza);

            if(spostamentoTraversa == 2 && spostamentoColonna == 1 || spostamentoTraversa == 1 && spostamentoColonna == 2){
                return true;
            } else {
                return false;
            }
        }
    }
}