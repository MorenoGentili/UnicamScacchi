using System;
using System.Collections.Generic;

namespace Scacchi.Modello
{
    public class Scacchiera : IScacchiera
    {
        //all'esterno la collezione sarà iEnumerable ma all'interno posso fare come voglio
        private ICasa[] caseDellaScacchiera;
        private int countCase=0; 
        //ovviamente nel metodo costruttore bisogna generare le case della scacchiera
        public Scacchiera()
        {
            caseDellaScacchiera = new ICasa[64];
            for (int i = 1; i < 9; i++)
            {
                //ciclo per le traverse
                for (int j = 1; j < 9; j++)
                {
                    //ciclo per la colonna
                    ICasa casa = new Casa((Colonna)j, (Traversa)i);
                    caseDellaScacchiera[i+j-2] = casa;
                    countCase++;
                }
            }
        }

        public ICasa this[Colonna colonna, Traversa traversa]
        {
            get
            {
                return caseDellaScacchiera[(Math.Abs(((int)colonna - 1) + (((int)traversa-1)* 8)))];
            }
        }

        public IEnumerable<ICasa> Casa
        {
            get
            {
                return caseDellaScacchiera;
            }
        }
        public int getCount(){
            return countCase;
        }
        //metodo per stampare la scacchiera
        public void toString(){
             for (int i = 1; i < 9; i++)
                {//ciclo per le traverse
                for (int j = 1; j < 9; j++)
                {
                    
                    Console.WriteLine(caseDellaScacchiera[i+j-2].Colonna +" "+ caseDellaScacchiera[i+j-2].Traversa);
                }
            }
        }
    }
}