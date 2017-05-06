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
            ITavolo tavolo = new Tavolo(null, null, null);

            tavolo.RiceviGiocatori("Bianco", "Nero");

            IReadOnlyDictionary<Colore, IGiocatore> dict = tavolo.Giocatori;
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
            BloccoNote bloccoNote = new BloccoNote();
            ITavolo tavolo = new Tavolo(scacchiera, orologio, bloccoNote);

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
        Tavolo tavolo = new Tavolo(null, null, null);
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
        Tavolo tavolo = new Tavolo(null, null, null);
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
        Tavolo tavolo = new Tavolo(new Scacchiera(), new Orologio(TimeSpan.FromMilliseconds(1000)), new BloccoNote());
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

        [TheoryAttribute]
        [InlineDataAttribute("A2 A5")]
        [InlineDataAttribute("B1 B4")]
        [InlineDataAttribute("D1 D3")]
        [InlineDataAttribute("E1 E5")]
        [InlineDataAttribute("F1 F3")]
        [InlineDataAttribute("D1 D2")]
        public void MossaInvalidaLanciaEccezione(string mossaInvalida)
        {
        //Given
        Scacchiera scacchiera = new Scacchiera();
        Orologio orologio = new Orologio();
        BloccoNote bloccoNote = new BloccoNote();
        Tavolo tavolo = new Tavolo(scacchiera, orologio, bloccoNote);
        //When
        tavolo.RiceviGiocatori("Robespierre", "Rob Van Dam");
        tavolo.AvviaPartita();
        //Simulazione di alcune mosse valide di pedoni
        tavolo.InserisciMossa("A2 A4");
        tavolo.InserisciMossa("A7 A5");
        tavolo.InserisciMossa("B2 B4");
        tavolo.InserisciMossa("A5 B4");
        //Cosa succede per le mosse invalide
        Assert.Throws(typeof(InvalidOperationException), () => {
                tavolo.InserisciMossa(mossaInvalida);
        });
        }

        [TheoryAttribute]
        [InlineDataAttribute("A2","A4")]
        [InlineDataAttribute("B1","C3")]
        public void pezzoSiSpostaSeMossaValida(string coord1, string coord2) {
            //Given
            Scacchiera scacchiera = new Scacchiera();
            Orologio orologio = new Orologio();
            BloccoNote bloccoNote = new BloccoNote();
            Tavolo tavolo = new Tavolo(scacchiera, orologio, bloccoNote);
            //When
            tavolo.RiceviGiocatori("Fhurer", "Mahatma");
            tavolo.AvviaPartita();
            var coordPartenza = tavolo.InterpretaCoordinataCasa(coord1);
            var coordFine = tavolo.InterpretaCoordinataCasa(coord2);
            var pezzoInQuestione = tavolo.Scacchiera[coordPartenza.Colonna, coordPartenza.Traversa].PezzoPresente; 
            tavolo.InserisciMossa(coord1 + " " + coord2);
            Assert.Equal(tavolo.Scacchiera[coordPartenza.Colonna, coordPartenza.Traversa].PezzoPresente, null);
            Assert.Equal(tavolo.Scacchiera[coordFine.Colonna, coordFine.Traversa].PezzoPresente, pezzoInQuestione);

        }

        [Fact]
        public void partitaFinisceSeSiMangiaIlRe()
        {
        //Given
        //Bisognerebbe simulare un intera partita di scacchi? Come fare una cosa del genere?
        //When
        
        //Then
        }




    }
}