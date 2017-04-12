using System;
using System.Linq;
using Scacchi.Modello.Pezzi;
using Xunit;

namespace Scacchi.Modello
{
    public class PezziTest
    {

        [Fact]
        public void IlPedoneBiancoPuoMuovereAvantiDiUnaCasa()
        {
            //Given
            Pedone pedone = new Pedone(Colore.Nero);
            //When
            bool esito = pedone.PuòMuovere(
                    colonnaPartenza: Colonna.A,
                    traversaPartenza: Traversa.Seconda,
                    colonnaArrivo: Colonna.A,
                    traversaArrivo: Traversa.Terza);

            //Then
            Assert.True(esito);
        }

        [Theory]
        [InlineData(typeof(Donna))]
        [InlineData(typeof(Pedone))]
        public void IlPedoneNonPuòRestareFermo(Type t) {
            //Given
            IPezzo pezzo = Activator.CreateInstance(t, Colore.Bianco) as IPezzo;
            //When
            bool esito = pezzo.PuòMuovere(Colonna.A, Traversa.Prima, Colonna.A, Traversa.Prima);
            //Then
            Assert.True(esito, t.Name);
        }
    }
}