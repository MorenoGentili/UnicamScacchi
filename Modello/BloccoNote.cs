using System;
using System.Collections.Generic;
using Scacchi.Servizi;

namespace Scacchi.Modello{

    public class BloccoNote : IBloccoNote
    {
        public IEnumerable<string> RecuperaMosse()
        {
           return null;
        }

        public async void ScriviMossa(string mossa)
        {
            using (DataBase db = new DataBase()){
                Mossa miaMossa = new Mossa();
                miaMossa.Valore = mossa;
                db.Mosse.Add(miaMossa);
                await db.SaveChangesAsync();
            }
        }
    }
}