using EjendomBeregner.BusinessLogic;

namespace BusinessLogic.Test
{
    public class BeregnKvadratmeterTests
    {
        [Fact]
        public void Kvadratmeter_Sum_Stemmer_Med_Lejemaalsum()
        {
            // Arrange
            var sut = new EjendomBeregnerService();
            var lejemaals = new List<Lejemaal>
            {
                new Lejemaal {Kvadratmeter = 5},
                new Lejemaal {Kvadratmeter = 20},
                new Lejemaal {Kvadratmeter = 30}
            };
            var expected = lejemaals.Sum(l => l.Kvadratmeter);

            // Act 
            var actual = sut.BeregnKvadratmeter();

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}