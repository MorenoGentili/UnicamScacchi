using System;

namespace Scacchi.Modello.Pezzi
{
    public class Regina : IPezzo
    {
        public Regina(Colore colore)
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
            //faccio in modo che la regina possa muoversi verticalmente dove vuole
            if (colonnaArrivo == colonnaPartenza && traversaPartenza != traversaArrivo)
            {
                return true;
            }
            //faccio in modo che la regina possa muoversi lateralmente
            else if (colonnaArrivo != colonnaPartenza && (traversaPartenza == traversaArrivo))
            {
                return true;
            }
            else if (colonnaArrivo != colonnaPartenza && traversaPartenza != traversaArrivo)
            {
                //sto tentando di muovermi lateralmente
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
            }
            //Se sono qui la regina si sta spostando in una posizione non ammissibile!
            return false;
        }
    }
}