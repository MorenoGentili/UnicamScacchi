using System;
using System.Threading;
using Scacchi.Modello;
using Xunit;

namespace Scacchi.Tests {
    public class OrologioTest {

        private TimeSpan attesa = TimeSpan.FromMilliseconds(20);
        private TimeSpan tolleranza = TimeSpan.FromMilliseconds(50);

        [Fact]
        public void AccendendoloITempiResiduiDevonoEssereDi5Minuti()
        {
        //Given
        IOrologio orologio1 = new Orologio();
        //When
        orologio1.Accendi();
        //Then
        Assert.Equal(orologio1.TempoIniziale, orologio1.TempoResiduoBianco);
        Assert.Equal(orologio1.TempoIniziale, orologio1.TempoResiduoNero);
        }

        [Fact]
        public void QuandoSiAvviaAlloraIlTempoDeveAvanzarePerBianco()
        {
        //Given
        IOrologio orologio1 = new Orologio();
        orologio1.Accendi();
        //When
        orologio1.Avvia();
        Thread.Sleep(attesa);
        //Then
        Assert.InRange(orologio1.TempoResiduoBianco,
                orologio1.TempoIniziale-attesa-tolleranza,
                orologio1.TempoIniziale-attesa);
        }

        [Fact]
        public void QuandoInPausaIlTempoNonDeveAvanzare()
        {
        //Given
        IOrologio orologio1 = new Orologio();
        orologio1.Accendi();
        orologio1.Avvia();
        Thread.Sleep(attesa);
        //When
        orologio1.Pausa();
        TimeSpan primaLettura = orologio1.TempoResiduoBianco;
        Thread.Sleep(attesa);
        //Then
        Assert.Equal(primaLettura, orologio1.TempoResiduoBianco);
        }

        /*Quando avvia l'orologio mentre era in pausa, il tempo deve ricominciare a decrescere
        per il giocatore che era di turno*/
        [Fact]
        public void QuandoIlTempoRiprendeSoloBiancoAvanza()
        {
        //Given
        IOrologio orologio1 = new Orologio();
        orologio1.Accendi();
        orologio1.Avvia();
        orologio1.Pausa();
        TimeSpan primaLetturaBianco = orologio1.TempoResiduoBianco;
        TimeSpan primaLetturaNero = orologio1.TempoResiduoNero;
        //When
        orologio1.Avvia();
        Thread.Sleep(attesa);
        //Then
        Assert.InRange(orologio1.TempoResiduoBianco,
                primaLetturaBianco - attesa - tolleranza,
                primaLetturaBianco - attesa);
        //Assert.Equal(primaLetturaNero, orologio1.TempoResiduoNero);
        Assert.True(primaLetturaNero == orologio1.TempoResiduoNero);
        }

        /*Quando si cambia giocatore, il tempo deve arrestarsi per il giocatore precedente ed iniziare a
        decrescere per il giocatore attualmente di turno*/
        [Fact]
        public void QuandoBiancoPassaIlTurnoIlTempoAvanzaPerNero()
        {
        //Given
        IOrologio orologio1 = new Orologio();
        orologio1.Accendi();
        orologio1.Avvia();
        //When
        orologio1.FineTurno();
        Thread.Sleep(attesa);
        //Then
        Assert.InRange(orologio1.TempoResiduoBianco,
                orologio1.TempoIniziale - tolleranza,
                orologio1.TempoIniziale);
        Assert.InRange(orologio1.TempoResiduoNero,
                orologio1.TempoIniziale - attesa - tolleranza,
                orologio1.TempoIniziale - attesa);
        }

        [Fact]
        public void QuandoNeroPassaIlTurnoIlTempoAvanzaPerBianco()
        {
        //Given
        IOrologio orologio1 = new Orologio();
        orologio1.Accendi();
        orologio1.Avvia();
        orologio1.FineTurno();
        //When
        orologio1.FineTurno();
        Thread.Sleep(attesa);
        //Then
        Assert.InRange(orologio1.TempoResiduoBianco,
        orologio1.TempoIniziale - attesa - tolleranza,
        orologio1.TempoIniziale - attesa);

        Assert.InRange(orologio1.TempoResiduoNero,
        orologio1.TempoIniziale - tolleranza,
        orologio1.TempoIniziale);
        }
        
        /*Quando resetta l'orologio, il tempo deve essere reimpostato a 5 minuti per entrambi i giocatori.
        Il tempo residuo resterà fermo per entrambi i giocatori finché l'utente non lo avvia*/
        [Fact]
        public void SulResetSiRicominciaDalTempoIniziale()
        {
        //Given
        IOrologio orologio1 = new Orologio();
        orologio1.Accendi();
        orologio1.Avvia();
        Thread.Sleep(attesa);
        orologio1.FineTurno();
        Thread.Sleep(attesa);
        orologio1.FineTurno();
        Thread.Sleep(attesa);
        //When
        orologio1.Reset();
        Thread.Sleep(1);
        //Then
        Assert.Equal(orologio1.TempoResiduoBianco, orologio1.TempoIniziale);
        Assert.Equal(orologio1.TempoResiduoNero, orologio1.TempoIniziale);
        }

        [Fact]
        public void QuandoAvvioSenzaAccendereDeveVerificarsiUnEccezione()
        {
        //Given
        IOrologio orologio1 = new Orologio();
        //When

        //Then
        Assert.Throws(typeof(InvalidOperationException), () => {
                orologio1.Avvia();
        });
        }

        /*Sollevare l'evento `TempoScaduto` quando il tempo residuo del giocatore di turno arriva a zero.*/
        [Fact]
        public void QuandoIlTempoDiUnGiocatoreScendeAZeroDeveEssereSollevatoTempoScaduto()
        {
        //Given
        IOrologio orologio1 = new Orologio(TimeSpan.FromMilliseconds(50));
        orologio1.Accendi();
        orologio1.Avvia();
        bool invocato = false;
        orologio1.TempoScaduto += (sender, arg1) => {
            invocato = true;
        };
        //When
        Thread.Sleep(200);
        //Then
        Assert.True(invocato);
        }

        //Questo test è "anomalo" perché non testa il nostro codice ma va a verificare
        //come si comporta l'EventHandler, una classe scritta da Microsoft
        //Ovviamente Microsoft ha già testato l'EventHandler e non è necessario che lo facciamo anche noi
        //Comunque, teniamo qui questo test giusto come esercizio e per ricordarci di come si
        //sottoscrivono gli eventi.
        private int sottoscrittoriInvocati = 0;
        [Fact]
        public void TempoScadutoDeveNotificareTuttiISuoiSottoscrittori(){

        //Given        
        IOrologio orologio = new Orologio(TimeSpan.FromMilliseconds(50));
        orologio.Accendi();
        orologio.Avvia();

        orologio.TempoScaduto += NotificaSconfitta;
        //Oltre che sottoscrivere un evento con un metodo, posso anche indicare una lambda expression
        orologio.TempoScaduto += (sender, colore) => {
                sottoscrittoriInvocati++;
        };   
        //When
        Thread.Sleep(TimeSpan.FromMilliseconds(200));
        //Then
        //Mi aspetto che vengano invocati entrambi i metodi che ho sottoscritto all'evento
        //1. Il metodo NotificaSconfitta definito in questa classe
        //2. La lambda expression (che è un metodo anonimo)
        Assert.Equal(2, sottoscrittoriInvocati);
        }

        private void NotificaSconfitta(object sender, Colore e)
        {
            sottoscrittoriInvocati++;
        }
    }

}