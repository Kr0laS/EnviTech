using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EnviTech.Db;

namespace EnviTech.ViewModel
{
    public partial class MainViewModel : BaseViewModel
    {
        [ObservableProperty]
        private ObservableCollection<DateTime> DateList;

        private  IDateRepository _dateRepository;

        public MainViewModel(IDateRepository dateRepository)
        { 
            _dateRepository = dateRepository;

            Task.Run(async () =>
            {
                var dates = await dateRepository.GetDates();

                DateList = new ObservableCollection<DateTime>(dates);
            });
        }

    }
}
