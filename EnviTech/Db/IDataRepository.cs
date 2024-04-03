using EnviTech.Model;
using System;
using System.Collections.Generic;

namespace EnviTech.Db
{
    public interface IDataRepository
    {
        IEnumerable<object> GetDataByValue(DataModel dataModel);
    }
}