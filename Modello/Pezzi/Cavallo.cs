
namespace Scacchi.Modello.Pezzi
{
    public class Cavallo : IPezzo
    {
        private readonly Colore colore;
        public Cavallo(Colore colore){
            this.colore=colore;
        }
        public Colore Colore {
            get{
                return this.colore;
            }
        }

        public bool PuòMuovere(Colonna colonnaPartenza, Traversa traversaPartenza, Colonna colonnaArrivo, Traversa traversaArrivo)
        {
           return false;
        }
    }
}