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

        private  IDateRepository _dateRepository;

        public MainViewModel(IDateRepository dateRepository)
        { 
            _dateRepository = dateRepository;

            var dates = dateRepository.GetDates();

            DateList = new ObservableCollection<string>(dates.Select(t => t.ToString()));
        }

    }
}
