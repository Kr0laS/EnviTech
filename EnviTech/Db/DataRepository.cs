using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnviTech.Db
{
    /// <summary>
    /// fetches the final data from the form for the dataform
    /// sorry for the bad name everything was very generalized...
    /// </summary>
    public class DataRepository : BaseRepository, IDataRepository
    {
        public DataRepository(IDbConnection db) : base(db)
        {
        }

        public IEnumerable<object> GetDataByValue(string valueName, 
            string operation, 
            string inputValue,
            DateTime startDate,
            DateTime endDate)
        {

            string sql = $"SELECT * FROM {DataTable} WHERE {valueName} {operation} {inputValue}" +
                $"AND Date_Time BETWEEN '{startDate}' AND {endDate}";

            var data = _db.Query<object>(sql);

            return data;
        }
    }
}
