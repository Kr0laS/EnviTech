using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnviTech.Db
{
    internal class DateRepository : IDateRepository
    {
        private readonly IDbConnection _dbConnection;

        public DateRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public List<DateTime> GetDates()
        {
            return new List<DateTime>()
            {
                DateTime.Now,
            };
        }
    }
}
