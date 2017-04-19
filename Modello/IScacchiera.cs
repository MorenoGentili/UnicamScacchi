using System.Collections.Generic;

namespace Scacchi.Modello
{
    public interface IScacchiera
    {
        IEnumerable<ICasa> Casa { get; }
        //questa è una proprietà alla quale però si può accedere solo se dall'esterno mi vengono dati
        //due indici, quello della colonna e quello della traversa.
        ICasa this[Colonna colonna, Traversa traversa]{get;}
    }
}