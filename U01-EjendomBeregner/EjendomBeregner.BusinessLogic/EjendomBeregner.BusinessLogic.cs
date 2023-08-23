namespace EjendomBeregner.BusinessLogic
{
    public class EjendomBeregnerService
    {
        private readonly ILejemaalRepository _lejemaalRepository;

        public EjendomBeregnerService(ILejemaalRepository lejemaalRepository)
        {
            _lejemaalRepository = lejemaalRepository;
        }

        /// <summary>
        ///     Beregner ejendommens kvadratmeter ud fra ejendommens lejelmål.
        ///     Lejemål er i en kommasepareret tekstfil. Formatet af filen er:
        ///     "lejlighednummer", "kvadratmeter", "antal rum"
        ///     lejlighednummer: int
        ///     kvadratmeter: double
        ///     antal rum: double
        /// </summary>
        /// <param name="lejemaalDataFilename"></param>
        /// <returns></returns>
        public double BeregnKvadratmeter()//List<Lejemaal> lejemaals)
        {
            var lejemaals = _lejemaalRepository.HentLejemaal();
            double kvadratmeter = 0;
            foreach (var lejemaal in lejemaals)
            {
                kvadratmeter += lejemaal.Kvadratmeter;
            }
            return kvadratmeter;
        }

        private string RemoveQuotes(string lejemaalPart)
        {
            return lejemaalPart.Replace('"', ' ').Trim();
        }
    }

    public class Lejemaal
    {
        public int Lejlighednummer { get; set; }
        public double Kvadratmeter { get; set; }
        public double Rum { get; set; }
    }
}
