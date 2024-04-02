using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnviTech.Db
{
    public class BaseRepository
    {
        protected const string OperatorsTable = "OPERATOR";
        protected const string DataTable = "DATA";
        protected const string StatusTable = "STATUS";

        protected readonly IDbConnection _db;

        public BaseRepository(IDbConnection dbConnection)
        {
            _db = dbConnection;
        }
    }
}
