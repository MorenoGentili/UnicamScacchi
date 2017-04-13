using System.Collections.Generic;

namespace Scacchi.Modello
{
    public interface IScacchiera
    {
        IEnumerable<ICasa> Case { get; }
        ICasa this[Colonna colonna, Traversa traversa] { get; }
    }
}