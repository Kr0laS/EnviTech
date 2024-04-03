using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnviTech.Db
{
    public interface IDateRepository
    {
        List<DateTime> GetDates();
        Task<List<DateTime>> GetDatesAsync();
        DateTime GetEarliestDate();
        DateTime GetLatestDate();
    }
}
