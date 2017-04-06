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
        public bool PuòMuovere(
            Colonna colonnaPartenza,
            Traversa traversaPartenza,
            Colonna colonnaArrivo,
            Traversa traversaArrivo)
        {
            var stessaColonna = colonnaPartenza == colonnaArrivo;
            var distanzaTraLeTraverse = (int) traversaArrivo - (int) traversaPartenza;

            if (stessaColonna && distanzaTraLeTraverse == 1 && colore == Colore.Bianco ){
                return true;
            } else if(stessaColonna && distanzaTraLeTraverse == -1 && colore == Colore.Nero) {
                return true;
            } else if(stessaColonna && distanzaTraLeTraverse == 2 && colore == Colore.Bianco &&
                        traversaPartenza == Traversa.Seconda){
                            return true;
            } else if(stessaColonna && distanzaTraLeTraverse == -2 && colore == Colore.Nero && 
                        traversaPartenza == Traversa.Settima){
                            return true;
            } else {
                return false;
            }

        }
    }
}