using System.Collections.Generic;

namespace EnviTech.Db
{
    public interface IValuesRepository
    {
        IEnumerable<string> GetValues();
    }
}