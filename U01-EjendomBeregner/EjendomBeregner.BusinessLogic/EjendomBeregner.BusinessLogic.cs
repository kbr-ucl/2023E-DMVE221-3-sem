using System.Globalization;

namespace EjendomBeregner.BusinessLogic;

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

/// <summary>
///     Domain model for lejemål
/// </summary>
public class Lejemaal
{
    public int Lejlighednummer { get; set; }
    public double Kvadratmeter { get; set; }
    public double Rum { get; set; }
}

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
///     Implementation af ILejemaalRepository der indlæser lejemål fra en kommasepareret tekstfil.
///     <summary></summary>
public class LejemaalFileRepository : ILejemaalRepository
{
    private readonly IFileWrapper _fileWrapper;
    private readonly string _lejemaalDataFilename;

    public LejemaalFileRepository(string lejemaalDataFilename, IFileWrapper fileWrapper)
    {
        _lejemaalDataFilename = lejemaalDataFilename;
        _fileWrapper = fileWrapper;
    }

    /// <summary>
    ///     Indlæser ejendommens lejelmål.
    ///     Lejemål er i en kommasepareret tekstfil. Formatet af filen er:
    ///     "lejlighednummer", "kvadratmeter", "antal rum"
    ///     lejlighednummer: int
    ///     kvadratmeter: double
    ///     antal rum: double
    ///     Data eksempel fra filen: 3, 20.5, 4.5
    /// </summary>
    /// <param name="lejemaalDataFilename"></param>
    /// <returns>Ejendommens kvadratmeter</returns>
    public IEnumerable<Lejemaal> HentLejemaal()
    {
        var lejemaalene = _fileWrapper.ReadAllLines(_lejemaalDataFilename);
        foreach (var lejemaal in lejemaalene)
        {
            var lejemaalParts = lejemaal.Split(',');
            int.TryParse(RemoveQuotes(lejemaalParts[0]), out var lejlighednummer);
            double.TryParse(RemoveQuotes(lejemaalParts[1]), CultureInfo.InvariantCulture, out var lejemaalKvadratmeter);
            double.TryParse(RemoveQuotes(lejemaalParts[2]), CultureInfo.InvariantCulture, out var rum);
            yield return new Lejemaal
            {
                Lejlighednummer = lejlighednummer,
                Kvadratmeter = lejemaalKvadratmeter,
                Rum = rum
            };
        }
    }

    private string RemoveQuotes(string lejemaalPart)
    {
        return lejemaalPart.Replace('"', ' ').Trim();
    }
}

/// <summary>
///     Wrapper omkring File.ReadAllLines
/// </summary>
public interface IFileWrapper
{
    string[] ReadAllLines(string path);
}

public class FileWrapper : IFileWrapper
{
    public string[] ReadAllLines(string path)
    {
        return File.ReadAllLines(path);
    }
}