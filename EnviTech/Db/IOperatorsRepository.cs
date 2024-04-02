using System.Collections.Generic;
using System.Threading.Tasks;

namespace EnviTech.Db
{
    public interface IOperatorsRepository
    {
        List<string> GetOperators();
        Task<List<string>> GetOperatorsAsync();
    }
}