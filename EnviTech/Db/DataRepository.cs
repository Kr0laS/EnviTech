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

        public IEnumerable<object> GetDataByValue(DataModel model, List<string> values)
        {
            var status = model.ValueName.Replace("Value", "Status");

            values.Remove(model.ValueName);
            string Values = string.Join(", ", values.Select(v => $"d.{v}"));

            string sql = $"SELECT d.Date_Time, {model.ValueName}, s.Description, {Values} FROM {DataTable} d " +
                         $"INNER JOIN {StatusTable} s ON d.{status} = s.id " +
                         $"WHERE {model.ValueName} {model.Operation} @InputValue " +
                         $"AND Date_Time BETWEEN @StartDate AND @EndDate";

            var data = _db.Query<object>(sql, model);

            return data;
        }
    }
}
