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
        public void LaTorreNeraPuoMuoversiOrizzontalmente()
        {
            //Given
            Torre torre = new Torre(Colore.Nero);
            //When
            bool esito = torre.PuòMuovere(
                colonnaPartenza: Colonna.A,
                    traversaPartenza: Traversa.Ottava,
                    colonnaArrivo: Colonna.B,
                    traversaArrivo: Traversa.Ottava);
            //Then
            Assert.True(esito);
        }

        [Fact]
        public void LaTorreNeraPuoMuoversiVerticalmente()
        {
            //Given
            Torre torre = new Torre(Colore.Nero);
            //When
            bool esito = torre.PuòMuovere(
                colonnaPartenza: Colonna.H,
                    traversaPartenza: Traversa.Ottava,
                    colonnaArrivo: Colonna.H,
                    traversaArrivo: Traversa.Terza);
            //Then
            Assert.True(esito);
        }

        [Fact]
        public void LaTorreBiancaPuoMuoversiOrizzontalmente()
        {
            //Given
            Torre torre = new Torre(Colore.Bianco);
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
        public void LaTorreBiancaPuoMuoversiVerticalmente()
        {
            //Given
            Torre torre = new Torre(Colore.Bianco);
            //When
            bool esito = torre.PuòMuovere(
                colonnaPartenza: Colonna.A,
                    traversaPartenza: Traversa.Seconda,
                    colonnaArrivo: Colonna.A,
                    traversaArrivo: Traversa.Terza);
            //Then
            Assert.True(esito);
        }


        //test per gli alfieri
        [Fact]
        public void AlfiereBiancoSiMuoveDiagonalmenteQuantoVuole()
        {
            //Given
            Alfiere alfiere = new Alfiere(Colore.Bianco);
            //When
            bool esito = alfiere.PuòMuovere(
                colonnaPartenza: Colonna.C,
                    traversaPartenza: Traversa.Prima,
                    colonnaArrivo: Colonna.G,
                    traversaArrivo: Traversa.Quinta);
            //Then
            Assert.True(esito);
        }
        //test per gli alfieri
        [Fact]
        public void AlfiereNeroSiMuoveDiagonalmenteQuantoVuole()
        {
            //Given
            Alfiere alfiere = new Alfiere(Colore.Nero);
            //When
            bool esito = alfiere.PuòMuovere(
                colonnaPartenza: Colonna.C,
                    traversaPartenza: Traversa.Ottava,
                    colonnaArrivo: Colonna.A,
                    traversaArrivo: Traversa.Sesta);
            //Then
            Assert.True(esito);
        }

        //test per la regina
        [Fact]
        public void LaReginaSiPuoMuovereVerticalmenteDoveVuole()
        {
            //Given
            Regina regina = new Regina(Colore.Bianco);
            //When
            bool esito = regina.PuòMuovere(
                    colonnaPartenza: Colonna.C,
                        traversaPartenza: Traversa.Prima,
                        colonnaArrivo: Colonna.G,
                        traversaArrivo: Traversa.Quinta);
            //Then
            Assert.True(esito);
        }

    }
}