using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnviTech.Db
{
    internal class BaseRepository
    {
        protected readonly IDbConnection _db;

        public BaseRepository(IDbConnection dbConnection)
        {
            _db = dbConnection;
        }
    }
}
