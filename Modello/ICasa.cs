using Scacchi.Modello.Pezzi;

namespace Scacchi.Modello
{
    public interface ICasa
    {
        Colonna Colonna {get;}
        Traversa Traversa {get;}
        IPezzo PezzoPresente {get;set;}
    }
}