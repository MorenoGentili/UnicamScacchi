using System;
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
        Assert.Equal(TimeSpan.FromMinutes(5), orologio1.TempoResiduoGiocatore1);
        Assert.Equal(TimeSpan.FromMinutes(5), orologio1.TempoResiduoGiocatore2);
        }

    }

}