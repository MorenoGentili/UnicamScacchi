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
       public void IlPedoneBiancoPuoMuovereAvantiDiDueCaseSeSiTrovaNellaTraversaIniziale()
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
       public void IlPedoneNeroPuoMuovereAvantiDiDueCaseSeSiTrovaNellaTraversaIniziale()
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
       public void LaTorrePuoMuovereLungoUnaLineaOrizzontale()
       {
            //Given
            Torre torre = new Torre(Colore.Bianco);
            //When
            bool esito = torre.PuòMuovere(
                            colonnaPartenza: Colonna.A,
                            traversaPartenza: Traversa.Prima,
                            colonnaArrivo: Colonna.C,
                            traversaArrivo: Traversa.Prima);
            //Then
            Assert.True(esito);
       }

       [Fact]
       public void LaTorrePuoMuovereLungoUnaLineaVerticale()
       {
            //Given
            Torre torre = new Torre(Colore.Nero);
            //When
            bool esito = torre.PuòMuovere(
                            colonnaPartenza: Colonna.D,
                            traversaPartenza: Traversa.Prima,
                            colonnaArrivo: Colonna.D,
                            traversaArrivo: Traversa.Quinta);
            //Then
            Assert.True(esito);
       }

       [Fact]
       public void LaTorreNonPuoRimanereFerma()
       {
            //Given
            Torre torre = new Torre(Colore.Bianco);
            //When
                bool esito = torre.PuòMuovere(
                                    colonnaPartenza: Colonna.D,
                                    traversaPartenza: Traversa.Prima,
                                    colonnaArrivo: Colonna.D,
                                    traversaArrivo: Traversa.Prima);
            //Then
            Assert.False(esito);
       }

       [Fact]
       public void LaTorrePuoMuovereSoloOrizzontalmenteOppureVerticalmente()
       {
            //Given
            Torre torre = new Torre(Colore.Nero);
            //When
            bool esito = torre.PuòMuovere(
                                colonnaPartenza: Colonna.A,
                                traversaPartenza: Traversa.Seconda,
                                colonnaArrivo: Colonna.D,
                                traversaArrivo: Traversa.Prima);
            //Then
            Assert.False(esito);
       }

       [Fact]
       public void LoAlfierePuoMuoversiInAntidiagonale()
       {
            //Given
            Alfiere alfiere = new Alfiere(Colore.Bianco);
            //When
            bool esito = alfiere.PuòMuovere(
                                colonnaPartenza: Colonna.C,
                                traversaPartenza: Traversa.Prima,
                                colonnaArrivo: Colonna.D,
                                traversaArrivo: Traversa.Seconda);
            //Then
            Assert.True(esito);
       }

       [Fact]
       public void LoAlfierePuoMuoversiInDiagonale()
       {
           //Given
            Alfiere alfiere = new Alfiere(Colore.Nero);
            //When
            bool esito = alfiere.PuòMuovere(
                                colonnaPartenza: Colonna.D,
                                traversaPartenza: Traversa.Sesta,
                                colonnaArrivo: Colonna.C,
                                traversaArrivo: Traversa.Settima);
            //Then
            Assert.True(esito);
       }

       [Fact]
       public void LoAlfiereNonPuoMuoversiInOrizzontale()
       {
            //Given
            Alfiere alfiere = new Alfiere(Colore.Nero);
            //When
            bool esito = alfiere.PuòMuovere(
                                colonnaPartenza: Colonna.A,
                                traversaPartenza: Traversa.Prima,
                                colonnaArrivo: Colonna.C,
                                traversaArrivo: Traversa.Prima);
            //Then
            Assert.False(esito);
       }

       [Fact]
       public void LoAlfiereNonPuoMuoversiInVerticale()
       {
            //Given
            Alfiere alfiere = new Alfiere(Colore.Nero);
            //When
            bool esito = alfiere.PuòMuovere(
                                colonnaPartenza: Colonna.A,
                                traversaPartenza: Traversa.Prima,
                                colonnaArrivo: Colonna.A,
                                traversaArrivo: Traversa.Seconda);
            //Then
            Assert.False(esito);
       }

       [Fact]
       public void LoAlfiereNonPuoRestareFermo()
       {
            //Given
            Alfiere alfiere = new Alfiere(Colore.Bianco);
            //When
            bool esito = alfiere.PuòMuovere(
                                colonnaPartenza: Colonna.A,
                                traversaPartenza: Traversa.Prima,
                                colonnaArrivo: Colonna.A,
                                traversaArrivo: Traversa.Prima);
            //Then
            Assert.False(esito);
       }
       
       [Fact]
       public void LaDonnaPuoMuovereInVerticale()
       {
       //Given
       Donna donna = new Donna(Colore.Nero);
       //When
        bool esito = donna.PuòMuovere(
                                colonnaPartenza: Colonna.A,
                                traversaPartenza: Traversa.Prima,
                                colonnaArrivo: Colonna.A,
                                traversaArrivo: Traversa.Seconda);
       //Then
       Assert.True(esito);
       }

       [Fact]
       public void LaDonnaPuoMuovereInOrizzontale()
       {
       //Given
       Donna donna = new Donna(Colore.Nero);
       //When
       bool esito = donna.PuòMuovere(
                                colonnaPartenza: Colonna.A,
                                traversaPartenza: Traversa.Prima,
                                colonnaArrivo: Colonna.C,
                                traversaArrivo: Traversa.Prima);
       //Then
       Assert.True(esito);
       }

       [Fact]
       public void LaDonnaPuoMuovereInAntidiagonale()
       {
            //Given
            Donna donna = new Donna(Colore.Bianco);
            //When
            bool esito = donna.PuòMuovere(
                                colonnaPartenza: Colonna.C,
                                traversaPartenza: Traversa.Prima,
                                colonnaArrivo: Colonna.D,
                                traversaArrivo: Traversa.Seconda);
            //Then
            Assert.True(esito);
       }

       [Fact]
       public void LaDonnaPuoMuovereInDiagonale()
       {
            //Given
            Donna donna = new Donna(Colore.Bianco);
            //When
            bool esito = donna.PuòMuovere(
                                colonnaPartenza: Colonna.D,
                                traversaPartenza: Traversa.Sesta,
                                colonnaArrivo: Colonna.C,
                                traversaArrivo: Traversa.Settima);
            //Then
            Assert.True(esito);
       }

       [Fact]
       public void LaDonnaNonPuoMuoversiAdL()
       {
       //Given
       Donna donna = new Donna(Colore.Bianco);
       //When
       bool esito = donna.PuòMuovere(
                                colonnaPartenza: Colonna.A,
                                traversaPartenza: Traversa.Prima,
                                colonnaArrivo: Colonna.B,
                                traversaArrivo: Traversa.Terza);
       //Then
       Assert.False(esito);
       }

       [Fact]
       public void IlCavalloPuoMuoversiAdL()
       {
            //Given
            Cavallo cavallo = new Cavallo(Colore.Bianco);
            //When
            bool esito = cavallo.PuòMuovere(
                                colonnaPartenza: Colonna.B,
                                traversaPartenza: Traversa.Prima,
                                colonnaArrivo: Colonna.C,
                                traversaArrivo: Traversa.Terza);
            //Then
            Assert.True(esito);
       }

       [Fact]
       public void IlCavalloNonPuoMuoversiInVerticale()
       {
            //Given
            Cavallo cavallo = new Cavallo(Colore.Bianco);
            //When
            bool esito = cavallo.PuòMuovere(
                                colonnaPartenza: Colonna.B,
                                traversaPartenza: Traversa.Prima,
                                colonnaArrivo: Colonna.B,
                                traversaArrivo: Traversa.Settima);
            //Then
            Assert.False(esito);
       }

       [Fact]
       public void IlCavalloNonPuoMuoversiInOrizzontale()
       {
           //Given
            Cavallo cavallo = new Cavallo(Colore.Bianco);
            //When
            bool esito = cavallo.PuòMuovere(
                                colonnaPartenza: Colonna.C,
                                traversaPartenza: Traversa.Terza,
                                colonnaArrivo: Colonna.E,
                                traversaArrivo: Traversa.Terza);
            //Then
            Assert.False(esito);
       }

       [Fact]
       public void IlCavalloNonPuoMuoversiInDiagonale()
       {
            //Given
            Cavallo cavallo = new Cavallo(Colore.Nero);
            //When
            bool esito = cavallo.PuòMuovere(
                                colonnaPartenza: Colonna.G,
                                traversaPartenza: Traversa.Ottava,
                                colonnaArrivo: Colonna.E,
                                traversaArrivo: Traversa.Sesta);
            //Then
            Assert.False(esito);
       }


    }
    
}