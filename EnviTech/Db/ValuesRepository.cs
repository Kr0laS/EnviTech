using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnviTech.Db
{
    public class ValuesRepository : BaseRepository, IValuesRepository
    {
        public ValuesRepository(IDbConnection db) : base(db)
        {
        }

        public IEnumerable<string> GetValues()
        {
            string sql = @"
                SELECT COLUMN_NAME
                FROM INFORMATION_SCHEMA.COLUMNS
                WHERE TABLE_NAME = 'DATA' AND COLUMN_NAME LIKE 'Value%'";
            return _db.Query<string>(sql);
        }
    }
}
