using System.Collections.Generic;

namespace Scacchi.Modello{
    public interface IBloccoNote {
        void ScriviMossa(string mossa);
        IEnumerable<string> RecuperaMosse (); 
        
    }
}