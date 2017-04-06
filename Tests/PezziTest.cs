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
            Pedone pedone = new Pedone(Colore.Bianco);
            //When
            bool esito = pedone.PuòMuovere(
                    colonnaPartenza: Colonna.A,
                    traversaPartenza: Traversa.Seconda,
                    colonnaArrivo: Colonna.A,
                    traversaArrivo: Traversa.Terza);

            //Then
            Assert.True(esito);
        }

        [Fact]
        public void IlPedoneNeroPuoMuovereAvantiDiUnaCasa()
        {
            //Given
            Pedone pedone = new Pedone(Colore.Nero);
            //When
            bool esito = pedone.PuòMuovere(
                colonnaPartenza: Colonna.A,
                traversaPartenza: Traversa.Settima,
                colonnaArrivo: Colonna.A,
                traversaArrivo: Traversa.Sesta);

            //Then
            Assert.True(esito);
        }
        [Fact]
        public void IlPedoneNeroPuoMuovereAvantiDiDueCaseConTraversaIniziale()
        {
            //Given
            Pedone pedone = new Pedone(Colore.Nero);
            //When
            bool esito = pedone.PuòMuovere(
                colonnaPartenza: Colonna.A,
                traversaPartenza: Traversa.Settima,
                colonnaArrivo: Colonna.A,
                traversaArrivo: Traversa.Quinta);

            //Then
            Assert.True(esito);
        }
        [Fact]
        public void IlPedoneBiancoPuoMuovereAvantiDiDueCaseConTraversaIniziale()
        {
            //Given
            Pedone pedone = new Pedone(Colore.Bianco);
            //When
            bool esito = pedone.PuòMuovere(
                colonnaPartenza: Colonna.A,
                traversaPartenza: Traversa.Seconda,
                colonnaArrivo: Colonna.A,
                traversaArrivo: Traversa.Quarta);

            //Then
            Assert.True(esito);
        }
        [Fact]
        public void LaTorrePuoMuoversiOrizzontalmente()
        {
        //Given
        Torre torre= new Torre(Colore.Nero);
        //When
        bool esito = torre.PuòMuovere(
            colonnaPartenza: Colonna.A,
                traversaPartenza: Traversa.Seconda,
                colonnaArrivo: Colonna.B,
                traversaArrivo: Traversa.Seconda);
        //Then
        Assert.True(esito);
        }
        
        [Fact]
        public void LaTorrePuoMuoversiVerticalmente()
        {
        //Given
        Torre torre= new Torre(Colore.Nero);
        //When
        bool esito = torre.PuòMuovere(
            colonnaPartenza: Colonna.A,
                traversaPartenza: Traversa.Seconda,
                colonnaArrivo: Colonna.A,
                traversaArrivo: Traversa.Terza);
        //Then
        Assert.True(esito);
        }

    }
}