using System;
using System.Collections.Generic;
using System.Linq;
using Scacchi.Extensions;

namespace Scacchi.Modello.Pezzi {
    public class Torre : IPezzo
    {
        private readonly Colore colore;
        public Torre(Colore colore)
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
            Traversa traversaArrivo,
           IEnumerable<ICasa> listaCase = null)
        {
           
           
           if(colonnaArrivo == colonnaPartenza && traversaPartenza != traversaArrivo
                ||
              traversaPartenza == traversaArrivo && colonnaPartenza != colonnaArrivo)
              {   
                  return true;
              }

            return false;



        } 
    }
}