using System;
using System.Collections.Generic;

namespace EnviTech.Db
{
    public interface IDataRepository
    {
        IEnumerable<object> GetDataByValue(string valueName, 
            string operation, 
            string inputValue, 
            DateTime startDate,
            DateTime endDate);
    }
}