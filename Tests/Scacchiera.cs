using System.Linq;
using Scacchi.Modello;
using Xunit;

namespace Scacchi.Tests{

public class ScacchieraTest{

    [Fact]
    public void ScacchieraDeveAvere64Case()
    {
    //Given
    IScacchiera scacchiera= new Scacchiera();
    //When
    
    //Then
    Assert.Equal(64, scacchiera.Case.Count());
    }
[Fact]
public void indexerDeveRestituireCasaCorretta()
    {
    //Given
    IScacchiera scacchiera= new Scacchiera();
    //When
    ICasa casa= scacchiera[Colonna.F,Traversa.Quinta];
    //Then
    Assert.Equal(Colonna.F, casa.Colonna);
     Assert.Equal(Traversa.Quinta, casa.Traversa);
    }
}

}

