using Xunit;
using Scacchi.Modello;
using System;

namespace Scacchi.Tests{

    public class ScacchieraTest{
        [Fact]
        public void laScacchieraDeveAvere64Case()
        {
        //Given
        Scacchiera Scacchiera = new Scacchiera();
        //When
        //Then
        Assert.Equal(64, Scacchiera.getCount());
        }

        [Fact]
        public void indexDeveRestituireCasaCorretta()
        {
        //Given
        Scacchiera Scacchiera = new Scacchiera();
        //When
        ICasa casa = Scacchiera[Colonna.F, Traversa.Quinta];
        //Then
        Assert.Equal(Colonna.F, casa.Colonna);
        Assert.Equal(Traversa.Quinta,casa.Traversa);
        }
    }
}