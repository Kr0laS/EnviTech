using System;
using System.Collections.ObjectModel;
using System.Linq;
using EnviTech.Db;

namespace EnviTech.ViewModel
{
    public partial class MainViewModel : BaseViewModel
    {
        private ObservableCollection<string> _dateList;

        public ObservableCollection<string> DateList
        {
            get { return _dateList; }
            set
            {
                _dateList = value;
                OnPropertyChanged(nameof(DateList));
            }
        }

        private ObservableCollection<string> _operatorList;

        public ObservableCollection<string> OperatorList
        {
            get { return _operatorList; }
            set
            {
                _operatorList = value;
                OnPropertyChanged(nameof(OperatorList));
            }
        }

        private string _operator;

        public string Operator
        {
            get { return _operator; }
            set
            {
                _operator = value;
                OnPropertyChanged(nameof(Operator));
            }
        }

        private string _startDate;

        public string StartDate
        {
            get { return _startDate; }
            set
            {
                _startDate = value;
                OnPropertyChanged(nameof(StartDate));
            }
        }

        private string _endDate;

        public string EndDate
        {
            get { return _endDate; }
            set
            {
                _endDate = value;
                OnPropertyChanged(nameof(EndDate));
            }
        }

        private readonly RepositoryFacade _repo;

        public MainViewModel(RepositoryFacade repo)
        {
            _repo = repo;

            var dates = repo.Dates.GetDates();
            var operators = repo.Operators.GetOperators();

            OperatorList = new ObservableCollection<string>(operators);
            DateList = new ObservableCollection<string>(dates.Select(t => t.ToString()));
        }

    }
}
