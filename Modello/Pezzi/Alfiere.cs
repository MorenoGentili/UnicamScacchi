
using System;

namespace Scacchi.Modello.Pezzi
{
    public class Alfiere : IPezzo
    {
        public Alfiere(Colore colore)
        {
            this.colore = colore;
        }
        private readonly Colore colore;
        public Colore Colore
        {
            get
            {
                return this.colore;
            }
        }

        public bool PuòMuovere(Colonna colonnaPartenza, Traversa traversaPartenza, Colonna colonnaArrivo, Traversa traversaArrivo)
        {
            //devo controllare che l'alfiere possa muoversi solo sulle sue diagonali e non oltre!
            //la cosa che devo controllare in effetti è solamente il movimento sulle colonne
            //l'alfiere può andare in qualunque traversa ammissibile ma non nella stessa colonna e nemmeno
            //nella stessa traversa!
            if ((colonnaPartenza == colonnaArrivo) || traversaPartenza == traversaArrivo)
            {
                return false;
            }
            //ho escluso gran parte dell'area ammissibile in cui l'alfiere può andare ma non tutta!
            //mi salvo su due variabili la traversa di partenza e la colonna di partenza
            int IndicecolonnaPartenza = (int)colonnaPartenza;
            //definisco come rage destro e sinistro il numero di colonne e traverse su cui
            //l'alfiere può andare
            int colonnaRangeDestro = 8 - IndicecolonnaPartenza;
            int colonnaRangeSinistro = IndicecolonnaPartenza - 1;
            //controllo se il range di destinazione è accettabile
            //concetto di +1 +1
            for (int i = 1; i <= colonnaRangeDestro; i++)
            {
                if (Math.Abs(colonnaArrivo - colonnaPartenza) == i && Math.Abs(traversaArrivo - traversaPartenza) == i)
                {
                    return true;
                }
            }
            for (int i = 1; i <= colonnaRangeSinistro; i++)
            {
                if (Math.Abs(colonnaArrivo - colonnaPartenza) == i && Math.Abs(traversaArrivo - traversaPartenza) == i)
                {
                    return true;
                }
            }
            //se non ho restituito true ho dato dei parametri non ammissibili!
            return false;
        }
    }
}