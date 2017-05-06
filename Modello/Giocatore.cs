using System;

namespace Scacchi.Modello
{
    public class Giocatore : IGiocatore
    {
        public string Nome { get; private set; }
        public int Punteggio { get; set; }

        public Giocatore(string nome){
            this.Nome = nome;
        }
    }
}