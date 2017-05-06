using System;
using System.Collections.Generic;

namespace Scacchi.Modello
{
    public interface IScacchiera
    {
        IEnumerable<ICasa> Case { get; }
        ICasa this[Colonna colonna, Traversa traversa] { get; }
<<<<<<< HEAD
=======
        bool ReInVita(Colore colore);
        void SpostaPezzo(ICasa casaPartenza, ICasa casaArrivo);
>>>>>>> 61b3805c943602fbd9c12831296fd3405e55d23b

    }
}