using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Scacchi.Modello;
using Xunit;

namespace Scacchi.Tests
{
    public class TavoloTest
    {
        [Fact]
        public void TestIlTavoloHaDueGiocatori()
        {
            ITavolo tavolo = new Tavolo(null, null);

            tavolo.RiceviGiocatori("Bianco", "Nero");

            Dictionary<Colore, IGiocatore> dict = tavolo.Giocatori;
            IGiocatore bianco = dict[Colore.Bianco];
            IGiocatore nero = dict[Colore.Nero];

            Assert.Equal(2, dict.Count);

            Assert.Equal(1, dict.Where(colore => colore.Key == Colore.Bianco).Count());
            Assert.Equal(1, dict.Where(colore => colore.Key == Colore.Nero).Count());

            Assert.Equal("Bianco", bianco.Nome);
            Assert.Equal("Nero", nero.Nome);

        }

        [Fact]
        public void AllAvvioDellaPartitaDeveEsserePredispostaUnaScacchieraELOrologioAvviato()
        {
            //Given
            IScacchiera scacchiera = new Scacchiera();
            IOrologio orologio = new Orologio();
            ITavolo tavolo = new Tavolo(scacchiera, orologio);

            //When
            tavolo.RiceviGiocatori("", "");
            tavolo.AvviaPartita();

            //Then
            Assert.NotEqual(null, tavolo.Scacchiera);
            Assert.NotEqual(null, tavolo.Orologio);
            Assert.False(orologio.InPausa);
        }

        [Fact]
        public void IlTavoloDeveEssereInGradoDiInterpretareLeCoordinateDigitateDallUtente()
        {
        //Given
        Tavolo tavolo = new Tavolo(null, null);
        //When
        Coordinata coordinata = tavolo.InterpretaCoordinataCasa("A4");
        //Then
        Assert.Equal(Traversa.Quarta, coordinata.Traversa);
        Assert.Equal(Colonna.A, coordinata.Colonna);
        }



        [Fact]
        public void IlTavoloDeveLanciareUnEccezioneSeLeCoordinateSonoSbagliate()
        {
        //Given
        Tavolo tavolo = new Tavolo(null, null);
        //When
        //Then
        Assert.Throws(typeof(InvalidOperationException), 
            () => {tavolo.InterpretaCoordinataCasa("Che fare");});
        }

        private bool vittoriaRichiamata = false;
        [Fact]
        public void IlTavoloProclamaVittoriaPerAltroSeScadeIlTempoMossa()
        {
        //Given
        Tavolo tavolo = new Tavolo(new Scacchiera(), new Orologio(TimeSpan.FromMilliseconds(1000)));
        //When
        tavolo.RiceviGiocatori("Bruno Liegi Bastonliegi", "Ennio Annio");
        tavolo.AvviaPartita();
        //Then
        //Il colore della Vittoria sarà Nero, perchè inizia sempre il bianco a giocare
        tavolo.Vittoria += (object sender, Colore colore) => {
            Assert.Equal(colore, Colore.Nero);
            vittoriaRichiamata = true;
        };
        Thread.Sleep(TimeSpan.FromMilliseconds(2000));
        Assert.True(vittoriaRichiamata);
        }


    }
}