namespace Scacchi.Modello {
    public struct Coordinata {

        public Coordinata(Traversa traversa, Colonna colonna)
        {
            Traversa = traversa;
            Colonna = colonna;
        }

        public Traversa Traversa { get; private set; }
        public Colonna Colonna { get; private set; }

    }
}