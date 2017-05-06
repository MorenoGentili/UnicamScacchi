using System;
using System.Collections.Generic;
using System.Linq;
using Scacchi.Extensions;

namespace Scacchi.Modello.Pezzi {
    public class Torre : Pezzo
    {
        public override char Carattere {
            get {
                return Colore == Colore.Bianco ? '♜' : '♖';
            }
        }
        public Torre(Colore colore) : base(colore)
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
            if (!base.PuòMuovere(colonnaPartenza, traversaPartenza, colonnaArrivo, traversaArrivo, listaCase))
                return false;
           
           if(colonnaArrivo == colonnaPartenza && traversaPartenza != traversaArrivo
                ||
              traversaPartenza == traversaArrivo && colonnaPartenza != colonnaArrivo)
              {   
                  //Caso input senza listaCase
                  if(listaCase == null){

                  
                      return true;
                  }
                  else{ // Caso con lista in input
                        ICasa casaPartenza = listaCase.SingleOrDefault(casa => casa.Colonna == colonnaPartenza 
                            && casa.Traversa == traversaPartenza 
                            && casa.PezzoPresente == this);
                        
                        ICasa casaArrivo = listaCase.SingleOrDefault( casa => casa.Colonna==colonnaArrivo 
                            && casa.Traversa == traversaArrivo);
                        
                        // Movimento in verticale
                        if(colonnaArrivo == colonnaPartenza){
                            Traversa traversaMaggiore = traversaPartenza > traversaArrivo? 
                                                            traversaPartenza : traversaArrivo;
                            Traversa traversaMinore = traversaPartenza < traversaArrivo? 
                                                            traversaPartenza : traversaArrivo;

                            IEnumerable<ICasa> caseInMezzo = listaCase
                                                                      .Where(casa => casa.Colonna == colonnaPartenza 
                                                                            && casa.Traversa < traversaMaggiore && casa.Traversa > traversaMinore)
                                                                      .ConPezzi();
                            if(caseInMezzo.Count() == 0){ // Nessun pezzo in mezzo
                                if(casaArrivo?.PezzoPresente == null || casaPartenza.PezzoPresente.Colore != casaArrivo.PezzoPresente.Colore){
                                    return true; // Mangiato o casella vuota!
                                }
                                else{ // Stesso colore nella casella di arrivo
                                    return false; 
                                }

                            } else { // Pezzi in mezzo
                                return false;
                            }
                            

                        } else { // Movimento in orizzontale
                            Colonna colonnaMaggiore = colonnaPartenza > colonnaArrivo ? colonnaPartenza: colonnaArrivo;
                            Colonna colonnaMinore = colonnaPartenza < colonnaArrivo ? colonnaPartenza: colonnaArrivo;
                            
                            IEnumerable<ICasa> caseInMezzo = listaCase
                                                                      .Where(casa => casa.Traversa == traversaPartenza 
                                                                                && casa.Colonna < colonnaMaggiore 
                                                                                && casa.Colonna > colonnaMinore)
                                                                      .ConPezzi();
                            
                            if(caseInMezzo.Count() == 0){ // Nessun pezzo in mezzo
                                if(casaPartenza?.PezzoPresente?.Colore != casaArrivo?.PezzoPresente?.Colore || casaArrivo?.PezzoPresente == null){
                                    return true; // Mangiato o casella vuota!
                                }
                                else{ // Stesso colore nella casella di arrivo
                                    return false; 
                                }

                            } else { // Pezzi in mezzo
                                return false;
                            }
                                                                            
                            
                        }
                        
                  }
              }

            return false;



        } 
    }
}