using System;
using System.Collections.Generic;
using System.Linq;

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
            Traversa traversaArrivo,
            IEnumerable<ICasa> listaCase = null)
        {
            listaCase = listaCase??Enumerable.Empty<ICasa>();

                ICasa casaPartenza = listaCase.SingleOrDefault(casa => casa.Colonna == colonnaPartenza 
                && casa.Traversa == traversaPartenza 
                && casa.PezzoPresente == this);
                if ((this.colore == Colore.Bianco
                     && colonnaArrivo - colonnaPartenza == 1 
                     && traversaArrivo-traversaPartenza == 1) || (this.colore == Colore.Nero 
                     && colonnaPartenza - colonnaArrivo == 1 
                     && traversaPartenza-traversaArrivo == 1)){
                    ICasa casaArrivo = listaCase.SingleOrDefault( casa => casa.Colonna==colonnaArrivo 
                    && casa.Traversa == traversaArrivo);
                    if (casaArrivo.PezzoPresente.Colore != this.colore) return true;
                }
            
            var stessaColonna = colonnaPartenza == colonnaArrivo;
            int distanzaTraLeTraverse;
            if(Colore == Colore.Bianco){
            distanzaTraLeTraverse = (int) traversaArrivo - (int) traversaPartenza;
            }else{
            distanzaTraLeTraverse =  (int) traversaPartenza - (int) traversaArrivo;
            }

            if (stessaColonna && distanzaTraLeTraverse == 1){
                if(listaCase.SingleOrDefault( casa => casa.Colonna==colonnaArrivo 
                    && casa.Traversa == traversaArrivo)?.PezzoPresente == null)
                    return true;
                else
                    return false;

            } else {
                return false;
            }

        }
    }
}