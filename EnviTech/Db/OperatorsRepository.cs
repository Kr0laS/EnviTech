using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnviTech.Db
{
    public class OperatorsRepository : BaseRepository, IOperatorsRepository
    {
        public OperatorsRepository(IDbConnection db) : base(db)
        {
        }

        public List<string> GetOperators()
        {
            string sql = $"SELECT Name FROM {OperatorsTable}";
            var operators = _db.Query<string>(sql);

            return operators.ToList();
        }

        public async Task<List<string>> GetOperatorsAsync()
        {
            string sql = $"SELECT Name FROM {OperatorsTable}";
            var operators = await _db.QueryAsync<string>(sql);

            return operators.ToList();
        }
    }
}
