using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnviTech.Db
{
    internal class OperatorsRepository: BaseRepository
    {
        public OperatorsRepository(IDbConnection db) : base(db)
        {
        }

        public List<string> GetOperators()
        {

        }

        public Task<List<string>> GetOperatorsAsync()
        {

        }
    }
}
