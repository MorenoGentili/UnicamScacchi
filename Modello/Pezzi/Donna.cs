using System;
using System.Collections.Generic;
using System.Linq;

namespace Scacchi.Modello.Pezzi
{
    public class Donna : Pezzo
    {
        public Donna(Colore colore) : base(colore)
        {
        }

        public override char Carattere {
            get {
                return Colore == Colore.Bianco ? '♛' : '♕';
            }
        }
        public override bool PuòMuovere(
            Colonna colonnaPartenza,
            Traversa traversaPartenza,
            Colonna colonnaArrivo,
            Traversa traversaArrivo,
            IEnumerable<ICasa> listaCase = null)
        {

            listaCase = listaCase ?? Enumerable.Empty<ICasa>();
            //prendo la casa di partenza
            ICasa casaPartenza = listaCase.SingleOrDefault(casa => casa.Colonna == colonnaPartenza
             && casa.Traversa == traversaPartenza
             && casa.PezzoPresente == this);
            //prendo la casa di arrivo senza specificare se ci sia un pezzo o meno
            ICasa casaArrivo = listaCase.SingleOrDefault(casa => casa.Colonna == colonnaArrivo
                         && casa.Traversa == traversaArrivo);
            //controllo che non ci siano pezzi tra me e l'arrivo              
            //prendo le differenze tra colonne e traverse            
            var differenzaColonne = (int)colonnaPartenza - (int)colonnaArrivo;
            var differenzaTraverse = (int)traversaPartenza - (int)traversaArrivo;
            //confronto le colonne e le traverse
            var stessaColonna = colonnaPartenza == colonnaArrivo;
            var stessaTraversa = traversaPartenza == traversaArrivo;
            //controllo se sono rimasto fermo
            if (differenzaColonne == 0 && differenzaTraverse == 0)
                return false;

                
            //se la lista non è vuota devo fare un certo tipo di controlli per i test scritti 
            if (listaCase.Count() != 0)
            {
                int pezziTrovati = -1;
                //prima di tutto devo capire se mi sto muovendo verticalmente, orizzontalmente o in obliquo
                if (((Math.Abs(differenzaColonne) - Math.Abs(differenzaTraverse)) == 0))
                {
                    //  MI STO MUOVENDO IN OBLIQUO
                    //controllo che davanti a me non ci siano pezzi di alcun genere
                    pezziTrovati = (listaCase.Where(casa => casa.Colonna != casaPartenza.Colonna
                        && casa.Traversa != casaPartenza.Traversa && casa.PezzoPresente != null)).Count();
                }
                else if (stessaTraversa && !stessaColonna)
                {
                    //  MI STO MUOVENDO IN ORIZZONTALE
                    //controllo che davanti a me non ci siano pezzi di alcun genere
                    pezziTrovati = (listaCase.Where(casa => casa.Traversa == traversaPartenza && (int) casa.Colonna >= Math.Min((int) colonnaPartenza, (int) colonnaArrivo) && (int) casa.Colonna <= Math.Max((int) colonnaPartenza, (int) colonnaArrivo) && casa.PezzoPresente != null && casa.PezzoPresente != this)).Count();
                }
                else if (stessaColonna && !stessaTraversa)
                {
                    //  MI STO MUOVENDO IN VERTICALE
                    //controllo che davanti a me non ci siano pezzi di alcun genere
                    pezziTrovati = (listaCase.Where(casa => casa.Colonna == colonnaPartenza && (int) casa.Traversa >= Math.Min((int) traversaPartenza, (int) traversaArrivo) && (int) casa.Traversa <= Math.Max((int) traversaPartenza, (int) traversaArrivo) && casa.PezzoPresente != null && casa.PezzoPresente != this)).Count();
                }

                // ora posso analizzare i  pezzi trovati
                if (pezziTrovati > 1)
                {
                    //ci sono più di un pezzo tra me e la destinazione, non è possibile andare oltre!
                    return false;
                }
                else if (pezziTrovati == 1)
                {
                    //devo controllare la posizione di questo pezzo
                    if (casaArrivo?.PezzoPresente == null)
                    {
                        //allora il pezzo sta in mezzo tra me e la destinazione 
                        return false;
                    }
                    else if (casaArrivo?.PezzoPresente?.Colore == this.Colore)
                    {
                        //questa voce causa fallimenti nei test precedenti quelli che non consideravano 
                        //le pedine nella scacchiera per farlo passare devo cancellare per forza i test
                        //precedenti
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else if (pezziTrovati == 0)
                {
                    //non c'è nessun pezzo tra me e la destinazione posso andare lì
                    return true;
                }
                else {
                    //Se sono qui la variabile è rimasta inizializzata a -1 e quindi ho avuto un errore nell'interpretazione
                    //del programma
                    return false;
                }

            }

            //Se sono qui sto facendo un test senza considerare delle case in input
            if ((Math.Abs(differenzaColonne) <= 1 && Math.Abs(differenzaTraverse) <= 1) || ((stessaTraversa && !stessaColonna)
            || (stessaColonna && !stessaTraversa)) || ((Math.Abs(differenzaColonne) - Math.Abs(differenzaTraverse)) == 0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}