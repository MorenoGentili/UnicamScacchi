using System;
using System.Collections.Generic;
using System.Linq;

namespace Scacchi.Modello.Pezzi {
    public class Pedone : Pezzo
    {
        public Pedone(Colore colore) : base(colore)
        {
        }

        public override string ToString() {
            return $"Pedone {Colore}";
        }

        public override int GetHashCode() {
            return Colore.GetHashCode();
        }

        public override bool Equals(object altroOggetto){
            if (!(altroOggetto is Pedone))
                return false;

            return ((Pedone) altroOggetto)?.Colore == this.Colore;
        }
        
        public override bool PuòMuovere(
            Colonna colonnaPartenza,
            Traversa traversaPartenza,
            Colonna colonnaArrivo,
            Traversa traversaArrivo,
            IEnumerable<ICasa> listaCase = null)
        {
            bool puòMuovere = base.PuòMuovere(colonnaPartenza, traversaPartenza, colonnaArrivo, traversaArrivo, listaCase);
            if (!puòMuovere)
                return false;

            listaCase = listaCase??Enumerable.Empty<ICasa>();

                ICasa casaPartenza = listaCase.SingleOrDefault(casa => casa.Colonna == colonnaPartenza 
                && casa.Traversa == traversaPartenza 
                && casa.PezzoPresente == this);
                if ((this.Colore == Colore.Bianco
                     && colonnaArrivo - colonnaPartenza == 1 
                     && traversaArrivo-traversaPartenza == 1) || (this.Colore == Colore.Nero 
                     && colonnaPartenza - colonnaArrivo == 1 
                     && traversaPartenza-traversaArrivo == 1)){
                    ICasa casaArrivo = listaCase.SingleOrDefault( casa => casa.Colonna==colonnaArrivo 
                    && casa.Traversa == traversaArrivo);
                    if (casaArrivo.PezzoPresente.Colore != this.Colore) return true;
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