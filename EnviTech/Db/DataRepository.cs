using Dapper;
using EnviTech.Model;
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

        public IEnumerable<object> GetDataByValue(DataModel model)
        {
            string sql = $"SELECT * FROM {DataTable} WHERE {model.ValueName} {model.Operation} " +
                $"@InputValue AND Date_Time BETWEEN @StartDate AND @EndDate";

            var data = _db.Query<object>(sql, new { InputValue = model.InputValue, StartDate = model.StartDate, EndDate = model.EndDate });

            return data;
        }

    }
}
