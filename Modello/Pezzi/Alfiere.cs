using System;
using System.Collections.Generic;
using System.Linq;

<<<<<<< HEAD
namespace Scacchi.Modello.Pezzi {
    public class Alfiere : IPezzo
=======
namespace Scacchi.Modello.Pezzi
{

    public class Alfiere : Pezzo
>>>>>>> 61b3805c943602fbd9c12831296fd3405e55d23b
    {
        public Alfiere(Colore colore) : base(colore)
        {
        }

         public override char Carattere {
            get {
                return Colore == Colore.Bianco ? '♝' : '♗';
            }
        }
         public override bool PuòMuovere(
            Colonna colonnaPartenza,
            Traversa traversaPartenza,
            Colonna colonnaArrivo,
            Traversa traversaArrivo,
            IEnumerable<ICasa> listaCase = null)
        {
            
            var differenzaColonne = colonnaPartenza - colonnaArrivo;
            var differenzaTraverse = (int)traversaPartenza - (int)traversaArrivo;
            if (listaCase != null)
            {
                listaCase = listaCase ?? Enumerable.Empty<ICasa>();
                ICasa casaPartenza = listaCase.SingleOrDefault(casa => casa.Colonna == colonnaPartenza
                    && casa.Traversa == traversaPartenza
                    && casa.PezzoPresente == this);
                ICasa casaArrivo = listaCase.SingleOrDefault(casa => casa.Colonna == colonnaArrivo
               && casa.Traversa == traversaArrivo);
                if (((Math.Abs(differenzaColonne) - Math.Abs(differenzaTraverse)) == 0)
                && (differenzaColonne != 0 && differenzaTraverse != 0))
                {
                    int pezziInTraiettoria;
                    if (traversaArrivo > traversaPartenza)
                    {
                        if (colonnaArrivo > colonnaPartenza)
                        {
                            pezziInTraiettoria = (listaCase.Where(casa => (casa.Traversa < traversaArrivo
                            && casa.Traversa > traversaPartenza) && (casa.Colonna < colonnaArrivo && casa.Colonna > colonnaPartenza))).Count();
                            if (pezziInTraiettoria > 0)
                            {
                                return false;
                            }
                            else
                            {
                                if (casaArrivo?.PezzoPresente?.Colore != this.Colore)
                                    return true;
                                else
                                    return false;
                            }
                        }
                        else
                        {
                            pezziInTraiettoria = (listaCase.Where(casa => (casa.Traversa < traversaArrivo
                            && casa.Traversa > traversaPartenza) && (casa.Colonna > colonnaArrivo && casa.Colonna < colonnaPartenza))).Count();
                            if (pezziInTraiettoria > 0)
                            {
                                return false;
                            }
                            else
                            {
                                if (casaArrivo?.PezzoPresente?.Colore != this.Colore)
                                    return true;
                                else
                                    return false;
                            }

                        }
                    }
                    else
                    {

                        if (colonnaArrivo < colonnaPartenza)
                        {
                            pezziInTraiettoria = (listaCase.Where(casa => (casa.Traversa > traversaArrivo
                            && casa.Traversa < traversaPartenza) && (casa.Colonna > colonnaArrivo && casa.Colonna < colonnaPartenza))).Count();
                            if (pezziInTraiettoria > 0)
                            {
                                return false;
                            }
                            else
                            {
                                if (casaArrivo.PezzoPresente?.Colore != this.Colore)
                                    return true;
                                else
                                    return false;
                            }
                        }
                        else
                        {
                            pezziInTraiettoria = (listaCase.Where(casa => (casa.Traversa > traversaArrivo
                            && casa.Traversa < traversaPartenza) && (casa.Colonna < colonnaArrivo && casa.Colonna > colonnaPartenza))).Count();
                            if (pezziInTraiettoria > 0)
                            {
                                return false;
                            }
                            else
                            {
                                if (casaArrivo?.PezzoPresente?.Colore != this.Colore)
                                    return true;
                                else
                                    return false;
                            }

                        }
                    }
                }
            }
            if (differenzaColonne == 0 && differenzaTraverse == 0)
                return false;
            if ((Math.Abs(differenzaColonne) - Math.Abs(differenzaTraverse)) == 0)
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