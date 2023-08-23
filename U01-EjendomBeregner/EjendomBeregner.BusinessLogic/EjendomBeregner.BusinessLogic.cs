using EjendomBeregner.Domain;
using EjendomBeregner.Infrastructure;

namespace EjendomBeregner.BusinessLogic
{
    /// <summary>
    ///     Application service der beregner ejendommens kvadratmeter.
    /// </summary>
    public class EjendomBeregnerService
    {
        private readonly ILejemaalRepository _lejemaalRepository;

        public EjendomBeregnerService(ILejemaalRepository lejemaalRepository)
        {
            _lejemaalRepository = lejemaalRepository;
        }

        /// <summary>
        ///     Beregner ejendommens kvadratmeter ud fra ejendommens lejelmål.
        /// </summary>
        /// <returns>Ejendommens kvadratmeter</returns>
        public double BeregnKvadratmeter()
        {
            var lejemaals = _lejemaalRepository.HentLejemaal();
            double kvadratmeter = 0;
            foreach (var lejemaal in lejemaals) kvadratmeter += lejemaal.Kvadratmeter;
            return kvadratmeter;
        }
    }
}

namespace EjendomBeregner.Domain
{
    /// <summary>
    ///     Domain model for lejemål
    /// </summary>
    public class Lejemaal
    {
        public int Lejlighednummer { get; set; }
        public double Kvadratmeter { get; set; }
        public double Rum { get; set; }
    }
}

namespace EjendomBeregner.Infrastructure
{
    /// <summary>
    ///     Repository interface for lejemål
    /// </summary>
    public interface ILejemaalRepository
    {
        /// <summary>
        ///     Indlæser ejendommens lejelmål.
        /// </summary>
        /// <returns>Liste af ejendommens lejemål</returns>
        IEnumerable<Lejemaal> HentLejemaal();
    }

    /// <summary>
    ///     Implementation af ILejemaalRepository der indlæser fake.
    ///     <summary></summary>
    public class LejemaalFakeRepository : ILejemaalRepository
    {
        public IEnumerable<Lejemaal> HentLejemaal()
        {
            return new List<Lejemaal>(new[] {
            new Lejemaal {Lejlighednummer = 1, Kvadratmeter = 100, Rum = 4},
            new Lejemaal {Lejlighednummer = 2, Kvadratmeter = 80.4, Rum = 3},
            new Lejemaal {Lejlighednummer = 3, Kvadratmeter = 60, Rum = 2.5}
            });
        }
    }
}