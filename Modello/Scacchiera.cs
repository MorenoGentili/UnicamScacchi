using System;
using System.Collections.Generic;
using System.Linq;
using Scacchi.Modello.Pezzi;

namespace Scacchi.Modello
{
    public class Scacchiera : IScacchiera
    {
        private ICasa[] listaCase;

        /*public Scacchiera() {
            listaCase = new ICasa[64];
            int contatore=0;
            for (int i = 1; i < 9; i++)
            {
                for (int j = 1; j < 9; j++,contatore++)
                {
                    ICasa casa = new Casa((Colonna)j,(Traversa)i);
                    listaCase[contatore] = casa;
                }
            }

        }*/

        public Scacchiera()
        {
            listaCase = Enumerable.Range(0, 64)
            .Select(i => CreaCasa(i))
            .ToArray();
        }

        internal ICasa CreaCasa(int i)
        {
            Colonna colonna = (Colonna)(i % 8 + 1);
            Traversa traversa = (Traversa)(i / 8 + 1);
            ICasa casa = new Casa(colonna, traversa);

            if (traversa == Traversa.Seconda)
            {
                casa.PezzoPresente = new Pedone(Colore.Bianco);
            }
            else if (traversa == Traversa.Settima)
            {
                casa.PezzoPresente = new Pedone(Colore.Nero);
            }
            else if (traversa == Traversa.Prima || traversa == Traversa.Ottava)
            {

                Colore colore = traversa == Traversa.Prima ? Colore.Bianco : Colore.Nero;

                switch (colonna)
                {
                    case Colonna.A:
                        casa.PezzoPresente = new Torre(colore);
                        break;
                    case Colonna.B:
                        casa.PezzoPresente = new Cavallo(colore);
                        break;
                    case Colonna.C:
                        casa.PezzoPresente = new Alfiere(colore);
                        break;
                    case Colonna.D:
                        casa.PezzoPresente = new Donna(colore);
                        break;
                    case Colonna.E:
                        casa.PezzoPresente = new Re(colore);
                        break;
                    case Colonna.F:
                        casa.PezzoPresente = new Alfiere(colore);
                        break;
                    case Colonna.G:
                        casa.PezzoPresente = new Cavallo(colore);
                        break;
                    case Colonna.H:
                        casa.PezzoPresente = new Torre(colore);
                        break;
                }
            }
            return casa;
        }

        public IEnumerable<ICasa> Case
        {
            get
            {
                return listaCase;
            }
        }

        public ICasa this[Colonna colonna, Traversa traversa]
        {
            get
            {
                return listaCase[(int)colonna - 1 + (((int)traversa - 1) * 8)];
            }
        }

    }
}