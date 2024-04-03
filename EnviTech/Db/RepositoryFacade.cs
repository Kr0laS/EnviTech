using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnviTech.Db
{
    public class RepositoryFacade
    {
        public readonly IDateRepository Dates;
        public readonly IOperatorsRepository Operators;
        public readonly IValuesRepository Values;
        public readonly IDataRepository Data;

        public RepositoryFacade(IDateRepository dateRepository,
            IOperatorsRepository operatorsRepository,
            IValuesRepository values,
            IDataRepository data)
        {
            Dates = dateRepository;
            Operators = operatorsRepository;
            Values = values;
            Data = data;
        }
    }
}
