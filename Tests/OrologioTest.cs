using System;
using System.Threading;
using Scacchi.Modello;
using Xunit;

namespace Scacchi.Tests {

    public class OrologioTest {

        [Fact]
        public void AccendendoloITempiResiduiDevonoEssereDi5Minuti()
        {
        //Given
        IOrologio orologio1 = new Orologio();
        //When
        orologio1.Accendi();
        //Then
        Assert.Equal(TimeSpan.FromMinutes(Orologio.TempoInizialeInMinuti), orologio1.TempoResiduoGiocatore1);
        Assert.Equal(TimeSpan.FromMinutes(Orologio.TempoInizialeInMinuti), orologio1.TempoResiduoGiocatore2);
        }

        [Fact]
        public void InizioContoAllaRovesciaG1()
        {
        //Given
        IOrologio orologio1 = new Orologio();
        //When
        orologio1.Accendi();
        orologio1.Avvia();
        Thread.Sleep(250);
        //Then
        Assert.InRange(orologio1.TempoResiduoGiocatore1,
                TimeSpan.FromMilliseconds(Orologio.TempoInizialeInMinuti*60*1000-1000),
                TimeSpan.FromMilliseconds(Orologio.TempoInizialeInMinuti*60*1000-250));
        }

        [Fact]
        public void QuandoInPausaIlTempoNonDeveAvanzare()
        {
        //Given
        IOrologio orologio1 = new Orologio();
        //When
        orologio1.Accendi();
        orologio1.Avvia();
        Thread.Sleep(250);
        orologio1.Pausa();
        TimeSpan primaLettura = orologio1.TempoResiduoGiocatore1;
        Thread.Sleep(250);
        //Then
        //Assert.InRange(orologio1.TempoResiduoGiocatore1, TimeSpan.FromMilliseconds(299000), TimeSpan.FromMilliseconds(299750));
        Assert.Equal(primaLettura, orologio1.TempoResiduoGiocatore1);
        }

        /*Quando avvia l'orologio mentre era in pausa, il tempo deve ricominciare a decrescere
        per il giocatore che era di turno*/
        [Fact]
        public void QuandoIlTempoRiprendeSoloIlG1Avanza()
        {
        //Given
        IOrologio orologio1 = new Orologio();
        //When
        orologio1.Accendi();
        orologio1.Avvia();
        //Thread.Sleep(250);
        orologio1.Pausa();
        TimeSpan primaLetturaG1 = orologio1.TempoResiduoGiocatore1;
        TimeSpan primaLetturaG2 = orologio1.TempoResiduoGiocatore2;
        orologio1.Avvia();
        Thread.Sleep(250);
        //Then
        Assert.InRange(orologio1.TempoResiduoGiocatore1.TotalMilliseconds,
                primaLetturaG1.TotalMilliseconds - 300,
                primaLetturaG1.TotalMilliseconds - 250);
        //Assert.Equal(primaLetturaG2, orologio1.TempoResiduoGiocatore2);
        Assert.True(primaLetturaG2 == orologio1.TempoResiduoGiocatore2);
        }

        /*Quando si cambia giocatore, il tempo deve arrestarsi per il giocatore precedente ed iniziare a
        decrescere per il giocatore attualmente di turno*/
        [Fact]
        public void QuandoG1PassaIlTempoAvanzaPerG2()
        {
        //Given
        IOrologio orologio1 = new Orologio();
        //When
        orologio1.Accendi();
        orologio1.Avvia();
        orologio1.FineTurno();
        Thread.Sleep(250);
        //Then
        Assert.InRange(orologio1.TempoResiduoGiocatore1.TotalMilliseconds,
                Orologio.TempoInizialeInMinuti*60*1000-25,
                Orologio.TempoInizialeInMinuti*60*1000);
        Assert.InRange(orologio1.TempoResiduoGiocatore2.TotalMilliseconds,
                Orologio.TempoInizialeInMinuti*60*1000-500,
                Orologio.TempoInizialeInMinuti*60*1000-250);
        }

        [Fact]
        public void QuandoG2PassaIlTempoAvanzaPerG1()
        {
        //Given
        IOrologio orologio1 = new Orologio();
        //When
        orologio1.Accendi();
        orologio1.Avvia();
        orologio1.FineTurno();
        orologio1.FineTurno();
        Thread.Sleep(250);
        //Then
        Assert.InRange(orologio1.TempoResiduoGiocatore1.TotalMilliseconds, 299500, 299750);
        Assert.InRange(orologio1.TempoResiduoGiocatore2.TotalMilliseconds, 299975, 300000);
        }
        
        /*Quando resetta l'orologio, il tempo deve essere reimpostato a 5 minuti per entrambi i giocatori.
        Il tempo residuo resterà fermo per entrambi i giocatori finché l'utente non lo avvia*/
        [Fact]
        public void OnResetSiRicominciada5Minuti()
        {
        //Given
        IOrologio orologio1 = new Orologio();
        orologio1.Accendi();
        orologio1.Avvia();
        Thread.Sleep(250);
        orologio1.FineTurno();
        Thread.Sleep(500);
        orologio1.FineTurno();
        Thread.Sleep(125);
        //When
        orologio1.Reset();
        Thread.Sleep(1);
        //Then
        Assert.Equal(orologio1.TempoResiduoGiocatore1.TotalMilliseconds, 300000);
        Assert.Equal(orologio1.TempoResiduoGiocatore2.TotalMilliseconds, 300000);
        }

        [Fact]
        public void ThrowExQuandoAvvioSenzaAccendere()
        {
        //Given
        IOrologio orologio1 = new Orologio();
        //When
//        orologio1.Avvia();
        //Then
        Assert.Throws(typeof(InvalidOperationException), () => {orologio1.Avvia();});
        }

        /*Sollevare l'evento `TempoScaduto` quando il tempo residuo del giocatore di turno arriva a zero.
        Questo non vi ho ancora spiegato come realizzarlo, quindi lo vedremo durante la prossima lezione,
        oltre ad una revisione delle vostre implementazioni. Nel frattempo, potete usarlo come esercizio di
        ricerca su StackOverflow :P*/
        [Fact]
        public void OnTimeOutSollevareEventoRelativo()
        {
        //Given
        IOrologio orologio1 = new Orologio(TimeSpan.FromMilliseconds(50)) ;
        //When
        orologio1.Accendi();
        orologio1.Avvia();
        bool invocato = false;
        orologio1.TempoScaduto += (sender, arg1) => {
            invocato = true;
        };
        Thread.Sleep(2000);
        //Then
        Assert.True(invocato);
        }
    }

}