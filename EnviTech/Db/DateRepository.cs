﻿using Dapper;
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
        private readonly IDbConnection _db;

        public DateRepository(IDbConnection dbConnection)
        {
            _db = dbConnection;
        }

        public async Task<List<DateTime>> GetDates()
        {
            string sql = "SELECT Date_Time FROM DATA";
            var dates = await _db.QueryAsync<DateTime>(sql);

            return dates.ToList();
        }
    }
}
