﻿using Dapper;
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
    }
}
