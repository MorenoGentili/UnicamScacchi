using System;
using System.Collections.Generic;
using System.Linq;

namespace Scacchi.Modello.Pezzi {
    public class Cavallo : Pezzo
    {
        public Cavallo(Colore colore) : base(colore)
        {    
        }
        public override bool PuòMuovere(
            Colonna colonnaPartenza,
            Traversa traversaPartenza,
            Colonna colonnaArrivo,
            Traversa traversaArrivo,
            IEnumerable<ICasa> listaCase = null)
        {
            listaCase = listaCase??Enumerable.Empty<ICasa>();
            ICasa casaPartenza = listaCase.SingleOrDefault(casa => casa.Colonna == colonnaPartenza
            && casa.Traversa == traversaPartenza && casa.PezzoPresente == this);
            ICasa casaArrivo = listaCase.SingleOrDefault(casa => casa.Colonna == colonnaArrivo && casa.Traversa == traversaArrivo);
            if(casaArrivo?.PezzoPresente?.Colore == this.Colore) {
                return false;
            }
            var differenzaColonne = colonnaPartenza - colonnaArrivo;
            var differenzaTraverse = (int) traversaPartenza - (int) traversaArrivo;
            if(differenzaTraverse == 2 || differenzaTraverse == -2){
                if(differenzaColonne == 1 || differenzaColonne == -1){
                    return true;
                } else{
                    return false;
                }
            } else if(differenzaColonne == 2 || differenzaColonne == -2){
                
                if(differenzaTraverse == 1 || differenzaTraverse == -1){
                    return true;
                } else{
                    return false;
                }
            } else{
                return false;
            }
        }
    }
}