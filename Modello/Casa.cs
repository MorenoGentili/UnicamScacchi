using System;
using Scacchi.Modello.Pezzi;

namespace Scacchi.Modello{
    public class Casa : ICasa
    {
        private Colonna colonna;
        private Traversa traversa;
        public Casa(Colonna Colonna, Traversa Traversa){
            this.traversa=Traversa;
            this.colonna=Colonna;
            
        }
        public Colonna Colonna {
            get {
                return this.colonna;
            }
        }

        public Traversa Traversa {
            get{
                return this.traversa;
            }
        }

        public IPezzo PezzoPresente { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}