using EjendomBeregner.BusinessLogic;
using Moq;
using Xunit;

namespace BusinessLogic.Test;

public class BeregnKvadratmeterTests
{
    [Fact]
    public void Kvadratmeter_Sum_Stemmer_Med_Lejemaalsum()
    {
        // Arrange
        var lejemaals = new List<Lejemaal>
        {
            new() {Kvadratmeter = 5},
            new() {Kvadratmeter = 20},
            new() {Kvadratmeter = 30}
        };
        var expected = lejemaals.Sum(l => l.Kvadratmeter);

        var lejemaalRepositoryMock = new Mock<ILejemaalRepository>();
        lejemaalRepositoryMock.Setup(l => l.HentLejemaal()).Returns(lejemaals);

        var sut = new EjendomBeregnerService(lejemaalRepositoryMock.Object);

        // Act 
        var actual = sut.BeregnKvadratmeter();

        // Assert
        Assert.Equal(expected, actual);
    }
}