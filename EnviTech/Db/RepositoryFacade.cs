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

        public RepositoryFacade(IDateRepository dateRepository,
            IOperatorsRepository operatorsRepository)
        {
            Dates = dateRepository;
            Operators = operatorsRepository;
        }
    }
}
