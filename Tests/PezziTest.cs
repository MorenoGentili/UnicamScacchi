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
        public void SePedoneNeroCasaInizialePuoMuovereDiDueCase()
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
        public void SePedoneBiancoCasaInizialePuoMuovereDiDueCase()
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
        public void TorreMuoveStessaTraversa()
        {
        //Given
        Torre torre = new Torre(Colore.Bianco);
        //When
        bool esito = torre.PuòMuovere(colonnaPartenza: Colonna.A,
                    traversaPartenza: Traversa.Seconda,
                    colonnaArrivo: Colonna.A,
                    traversaArrivo: Traversa.Quinta);
        //Then
        Assert.True(esito);
        }

        [Fact]
        public void TorreMuoveStessaColonna()
        {
            //Given
            Torre torre = new Torre(Colore.Nero);
            //When
            bool esito = torre.PuòMuovere(colonnaPartenza: Colonna.A,
                        traversaPartenza: Traversa.Seconda,
                        colonnaArrivo: Colonna.C,
                        traversaArrivo: Traversa.Seconda);
            //Then
            Assert.True(esito);
        }
        [Fact]
        public void AlfiereMuoveDiagonale()
        {
            //Given
            Alfiere alfiere = new Alfiere(Colore.Bianco);
            //When
            bool esito = alfiere.PuòMuovere(colonnaPartenza: Colonna.F,
                        traversaPartenza: Traversa.Prima,
                        colonnaArrivo: Colonna.C,
                        traversaArrivo: Traversa.Quarta);
            //Then
            Assert.True(esito);
        }
        [Fact]
        public void DonnaMuoveDiagonaleOStessaTraversOStessaColonna()
        {
            //Given
            Donna donna = new Donna(Colore.Bianco);
            //When
            bool diagonale = donna.PuòMuovere(colonnaPartenza: Colonna.F,
                        traversaPartenza: Traversa.Prima,
                        colonnaArrivo: Colonna.C,
                        traversaArrivo: Traversa.Quarta);
            bool traversa = donna.PuòMuovere(colonnaPartenza: Colonna.F,
                        traversaPartenza: Traversa.Prima,
                        colonnaArrivo: Colonna.C,
                        traversaArrivo: Traversa.Prima);
            bool colonna = donna.PuòMuovere(colonnaPartenza: Colonna.C,
                        traversaPartenza: Traversa.Prima,
                        colonnaArrivo: Colonna.C,
                        traversaArrivo: Traversa.Quarta);
            bool caso = donna.PuòMuovere(colonnaPartenza: Colonna.A,
                        traversaPartenza: Traversa.Prima,
                        colonnaArrivo: Colonna.C,
                        traversaArrivo: Traversa.Quarta);
            bool controlloArrivoPartenza = donna.PuòMuovere(colonnaPartenza: Colonna.A,
                        traversaPartenza: Traversa.Prima,
                        colonnaArrivo: Colonna.A,
                        traversaArrivo: Traversa.Prima);
            //Then
            Assert.True(diagonale);
            Assert.True(traversa);
            Assert.True(colonna);
            Assert.False(controlloArrivoPartenza);
            Assert.False(caso);
        }

        [Fact]
        public void CavalloMuoveAdL()
        {
            //Given
            Cavallo cavallo = new Cavallo(Colore.Bianco);
            //When
            bool esito = cavallo.PuòMuovere(colonnaPartenza: Colonna.G,
                            traversaPartenza: Traversa.Prima,
                            colonnaArrivo: Colonna.F,
                            traversaArrivo: Traversa.Terza);
            bool caso = cavallo.PuòMuovere(colonnaPartenza: Colonna.A,
                            traversaPartenza: Traversa.Prima,
                            colonnaArrivo: Colonna.C,
                            traversaArrivo: Traversa.Quarta);
            //Then
            Assert.True(esito);
            Assert.False(caso);
        }
        [Fact]
        public void RePuoMuovereDiUnaCasa()
        {
            //Given
            Re re = new Re(Colore.Bianco);
            //When
            bool esito = re.PuòMuovere(colonnaPartenza: Colonna.D,
                                traversaPartenza: Traversa.Prima,
                                colonnaArrivo: Colonna.C,
                                traversaArrivo: Traversa.Seconda);
            bool caso = re.PuòMuovere(colonnaPartenza: Colonna.A,
                                traversaPartenza: Traversa.Prima,
                                colonnaArrivo: Colonna.B,
                                traversaArrivo: Traversa.Quarta);
            //Then
            Assert.True(esito);
            Assert.False(caso);
        }
    }
}