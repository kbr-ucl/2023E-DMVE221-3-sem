using System.Collections;

namespace EjendomBeregner.BusinessLogic
{
    public interface ILejemaalRepository
    {
        List<Lejemaal> HentLejemaal();
    }

    public class LejemaalRepository : ILejemaalRepository
    {
        public List<Lejemaal> HentLejemaal()
        {
            throw new System.NotImplementedException();
        }
    }
}