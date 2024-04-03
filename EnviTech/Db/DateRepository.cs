using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace EnviTech.Db
{
    public class DateRepository : BaseRepository, IDateRepository
    {

        public DateRepository(IDbConnection db) : base(db)
        {
        }

        public async Task<List<DateTime>> GetDatesAsync()
        {
            string sql = $"SELECT Date_Time FROM {DataTable}";
            var dates = await _db.QueryAsync<DateTime>(sql);

            return dates.ToList();
        }

        public List<DateTime> GetDates()
        {
            string sql = $"SELECT Date_Time FROM {DataTable}";
            var dates = _db.Query<DateTime>(sql);

            return dates.ToList();
        }

        public DateTime GetEarliestDate()
        {
            string sql = $"SELECT MIN(Date_Time) FROM {DataTable}";
            return _db.QueryFirstOrDefault<DateTime>(sql);
        }

        public DateTime GetLatestDate()
        {
            string sql = $"SELECT MAX(Date_Time) FROM {DataTable}";
            return _db.QueryFirstOrDefault<DateTime>(sql);
        }
    }
}
