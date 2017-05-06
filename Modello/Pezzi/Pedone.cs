using System;
using System.Collections.Generic;
using System.Linq;

namespace Scacchi.Modello.Pezzi
{
<<<<<<< HEAD
    public class Pedone : IPezzo
=======
    public class Pedone : Pezzo
>>>>>>> 61b3805c943602fbd9c12831296fd3405e55d23b
    {
        public Pedone(Colore colore) : base(colore)
        {
<<<<<<< HEAD
            this.colore = colore;
        }
        public Colore Colore
        {
            get
            {
                return colore;
=======
            if (colore == Colore.Bianco)
                traversaInizio = Traversa.Seconda;
            else
                traversaInizio = Traversa.Settima;
        }

        public override char Carattere {
            get {
                return Colore == Colore.Bianco ? '♟' : '♙';
>>>>>>> 61b3805c943602fbd9c12831296fd3405e55d23b
            }
        }

        public override int GetHashCode()
        {
            return Colore.GetHashCode();
        }

        public override bool Equals(object altroOggetto)
        {
            if (!(altroOggetto is Pedone))
                return false;

            return ((Pedone)altroOggetto)?.Colore == this.Colore;
        }

        private Traversa traversaInizio;
        public override bool PuòMuovere(
            Colonna colonnaPartenza,
            Traversa traversaPartenza,
            Colonna colonnaArrivo,
            Traversa traversaArrivo,
            IEnumerable<ICasa> listaCase = null)
        {
<<<<<<< HEAD
            // nel caos il pedone si vuole muovere nella stessa colonna

            listaCase = listaCase ?? Enumerable.Empty<ICasa>();

            ICasa casaPartenza = listaCase.SingleOrDefault(casa => casa.Colonna == colonnaPartenza
            && casa.Traversa == traversaPartenza
            && casa.PezzoPresente == this);
            if ((this.colore == Colore.Bianco
                 && colonnaArrivo - colonnaPartenza == 1
                 && traversaArrivo - traversaPartenza == 1) || (this.colore == Colore.Nero
                 && colonnaPartenza - colonnaArrivo == 1
=======
            bool puòMuovere = base.PuòMuovere(colonnaPartenza, traversaPartenza, colonnaArrivo, traversaArrivo, listaCase);
            if (!puòMuovere)
                return false;

            listaCase = listaCase ?? Enumerable.Empty<ICasa>();
            ICasa casaPartenza = listaCase.SingleOrDefault(casa => casa.Colonna == colonnaPartenza
            && casa.Traversa == traversaPartenza
            && casa.PezzoPresente == this);

            //Avanzamento diagonale del pedone
            if ((this.Colore == Colore.Bianco
                 && Math.Abs(colonnaArrivo - colonnaPartenza) == 1
                 && traversaArrivo - traversaPartenza == 1) || (this.Colore == Colore.Nero
                 && Math.Abs(colonnaPartenza - colonnaArrivo) == 1
>>>>>>> 61b3805c943602fbd9c12831296fd3405e55d23b
                 && traversaPartenza - traversaArrivo == 1))
            {
                ICasa casaArrivo = listaCase.SingleOrDefault(casa => casa.Colonna == colonnaArrivo
               && casa.Traversa == traversaArrivo);
<<<<<<< HEAD
                if (casaArrivo.PezzoPresente.Colore != this.colore) return true;
            }
            var stessaColonna = colonnaPartenza == colonnaArrivo;

            var distanzaTraLeTraverse = (int)(traversaArrivo - traversaPartenza);

            if (this.colore == Colore.Nero)
            {
                if (stessaColonna && distanzaTraLeTraverse == -2 && traversaPartenza == Traversa.Settima)
                {
                    return true;
                }
                if (stessaColonna && distanzaTraLeTraverse == -1)
                {
=======
                if (casaArrivo?.PezzoPresente?.Colore != this.Colore)
                    return true;
            }

            //Normale avanzamento del pedone
            var stessaColonna = colonnaPartenza == colonnaArrivo;
            var primaMossa = traversaPartenza == traversaInizio;
            int distanzaTraLeTraverse;
            if (Colore == Colore.Bianco)
            {
                distanzaTraLeTraverse = (int)traversaArrivo - (int)traversaPartenza;
            }
            else
            {
                distanzaTraLeTraverse = (int)traversaPartenza - (int)traversaArrivo;
            }
            if (stessaColonna && distanzaTraLeTraverse == 1)
            {
                if (listaCase.SingleOrDefault(casa => casa.Colonna == colonnaArrivo
                    && casa.Traversa == traversaArrivo)?.PezzoPresente == null)
>>>>>>> 61b3805c943602fbd9c12831296fd3405e55d23b
                    return true;
                }
                else
                {
                    return false;
<<<<<<< HEAD
                }
=======

            }
            //Avanzamento del pedone di due caselle
            else if(primaMossa && stessaColonna && Math.Abs(distanzaTraLeTraverse) == 2) {
                try {
                    //Vedo se trovo un pezzo all'interno della casa tra quella di 
                    //partenza e quella di arrivo. Se la trovo il pedone non si muove
                    listaCase.Single((casa) =>
                     (this.Colore == Colore.Bianco &&
                     casa.Traversa < traversaArrivo
                     && casa.Traversa > traversaPartenza 
                     && casa.PezzoPresente != null) ||
                     (this.Colore == Colore.Nero &&
                     casa.Traversa < traversaPartenza &&
                     casa.Traversa > traversaArrivo &&
                     casa.PezzoPresente != null));
                    return false;
                } catch (InvalidOperationException ex) {
                    return true;
                }
            } else {
                return false;
>>>>>>> 61b3805c943602fbd9c12831296fd3405e55d23b
            }
            if (this.colore == Colore.Bianco)
            {
                if (stessaColonna && distanzaTraLeTraverse == 2 && traversaPartenza == Traversa.Seconda)
                {
                    return true;
                }
                if (stessaColonna && distanzaTraLeTraverse == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (stessaColonna && distanzaTraLeTraverse == 1)
                {
                    if (listaCase.SingleOrDefault(casa => casa.Colonna == colonnaArrivo
                        && casa.Traversa == traversaArrivo)?.PezzoPresente == null)
                        return true;
                    else
                        return false;

                }
                else
                {
                    return false;
                }
            }
        }
    }
}