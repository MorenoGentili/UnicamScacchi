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
        public void IlCavalloPuòMuovereAvantiASinistraDiDueCase()
        {
        //Given
        Cavallo cavallo = new Cavallo(Colore.Nero);
        //When
        bool esito = cavallo.PuòMuovere(
            colonnaPartenza: Colonna.D,
            traversaPartenza: Traversa.Quarta,
            colonnaArrivo: Colonna.C,
            traversaArrivo: Traversa.Sesta);
        //Then
        Assert.True(esito);
        }

                [Fact]
        public void IlCavalloPuòMuovereAvantiADestraDiDueCase()
        {
        //Given
        Cavallo cavallo = new Cavallo(Colore.Nero);
        //When
        bool esito = cavallo.PuòMuovere(
            colonnaPartenza: Colonna.D,
            traversaPartenza: Traversa.Quarta,
            colonnaArrivo: Colonna.E,
            traversaArrivo: Traversa.Sesta);
        //Then
        Assert.True(esito);
        }

        [Fact]
        public void IlCavalloPuòMuovereIndietroASinistraDiDueCase()
        {
        //Given
        Cavallo cavallo = new Cavallo(Colore.Nero);
        //When
        bool esito = cavallo.PuòMuovere(
            colonnaPartenza: Colonna.D,
            traversaPartenza: Traversa.Quarta,
            colonnaArrivo: Colonna.C,
            traversaArrivo: Traversa.Seconda);
        //Then
        Assert.True(esito);
        }

        [Fact]
        public void IlCavalloPuòMuovereIndietroADestraDiDueCase()
        {
        //Given
        Cavallo cavallo = new Cavallo(Colore.Nero);
        //When
        bool esito = cavallo.PuòMuovere(
            colonnaPartenza: Colonna.D,
            traversaPartenza: Traversa.Quarta,
            colonnaArrivo: Colonna.E,
            traversaArrivo: Traversa.Seconda);
        //Then
        Assert.True(esito);
        }

        [Fact]
        public void IlCavalloPuòMuovereADestraAvantiDiUnaCasa()
        {
        //Given
        Cavallo cavallo = new Cavallo(Colore.Nero);
        //When
        bool esito = cavallo.PuòMuovere(
            colonnaPartenza: Colonna.D,
            traversaPartenza: Traversa.Quarta,
            colonnaArrivo: Colonna.F,
            traversaArrivo: Traversa.Quinta);
        //Then
        Assert.True(esito);
        }

        [Fact]
        public void IlCavalloPuòMuovereADestraIndietroDiUnaCasa()
        {
        //Given
        Cavallo cavallo = new Cavallo(Colore.Nero);
        //When
        bool esito = cavallo.PuòMuovere(
            colonnaPartenza: Colonna.D,
            traversaPartenza: Traversa.Quarta,
            colonnaArrivo: Colonna.F,
            traversaArrivo: Traversa.Terza);
        //Then
        Assert.True(esito);
        }

        [Fact]
        public void IlCavalloPuòMuovereASinistraAvantiDiUnaCasa()
        {
        //Given
        Cavallo cavallo = new Cavallo(Colore.Nero);
        //When
        bool esito = cavallo.PuòMuovere(
            colonnaPartenza: Colonna.D,
            traversaPartenza: Traversa.Quarta,
            colonnaArrivo: Colonna.B,
            traversaArrivo: Traversa.Quinta);
        //Then
        Assert.True(esito);
        }

        [Fact]
        public void IlCavalloPuòMuovereASinistraIndietroDiUnaCasa()
        {
        //Given
        Cavallo cavallo = new Cavallo(Colore.Nero);
        //When
        bool esito = cavallo.PuòMuovere(
            colonnaPartenza: Colonna.D,
            traversaPartenza: Traversa.Quarta,
            colonnaArrivo: Colonna.B,
            traversaArrivo: Traversa.Terza);
        //Then
        Assert.True(esito);
        }


    }
}