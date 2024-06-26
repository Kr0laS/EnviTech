﻿using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using EnviTech.Db;
using EnviTech.StartupHelpers;
using EnviTech.Model;

namespace EnviTech.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        #region - - - Properties - - -

        private DateTime _startDate;

        public DateTime StartDate
        {
            get { return _startDate; }
            set
            {
                _startDate = value;
                OnPropertyChanged(nameof(StartDate));
            }
        }

        private DateTime _endDate;

        public DateTime EndDate
        {
            get { return _endDate; }
            set
            {
                _endDate = value;
                OnPropertyChanged(nameof(EndDate));
            }
        }

        private DateTime _pickedStartDate;

        public DateTime PickedStartDate
        {
            get { return _pickedStartDate; }
            set
            {
                _pickedStartDate = value;
                OnPropertyChanged(nameof(PickedStartDate));
            }
        }

        private DateTime _pickedEndDate;

        public DateTime PickedEndDate
        {
            get { return _pickedEndDate; }
            set
            {
                _pickedEndDate = value;
                OnPropertyChanged(nameof(PickedEndDate));
            }
        }

        private ObservableCollection<string> _valueList;

        public ObservableCollection<string> ValueList
        {
            get { return _valueList; }
            set
            {
                _valueList = value;
                OnPropertyChanged(nameof(ValueList));
            }
        }

        private string _selectedValue;

        public string SelectedValue
        {
            get { return _selectedValue; }
            set
            {
                _selectedValue = value;
                OnPropertyChanged(nameof(SelectedValue));
            }
        }

        private string _inputValue = string.Empty;

        public string InputValue
        {
            get { return _inputValue; }
            set
            {
                _inputValue = value;
                OnPropertyChanged(nameof(InputValue));
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

        #endregion

        private readonly RepositoryFacade _repo;
        private readonly IAbstractFactory<DataForm> _dataFormFactory;

        public MainViewModel(RepositoryFacade repo,
            IAbstractFactory<DataForm> dataFormFactory)
        {
            _repo = repo;
            _dataFormFactory = dataFormFactory;

            FetchDbInitialInfo();

            ClearPageCommand = new Command(() => ClearPage());

            SubmitFormCommand = new Command(() => SubmitForm());
        }


        public Command ClearPageCommand { get; set; }

        public Command SubmitFormCommand { get; set; }

        private void SubmitForm()
        {
            if (!FormIsValid()) return;

            var dataform = _dataFormFactory.Create();

            dataform.GetFormData(new DataModel
            {
                InputValue = InputValue,
                Operation = Operator,
                ValueName = SelectedValue,
                StartDate = StartDate,
                EndDate = EndDate,
            }, ValueList.ToList());

            dataform.Show();
        }
        
        private void ClearPage()
        {
            PickedStartDate = StartDate;
            PickedEndDate = EndDate;
            InputValue = "";
            SelectedValue = "";
            Operator = "";
        }

        private void FetchDbInitialInfo()
        {
            StartDate = _repo.Dates.GetEarliestDate();
            EndDate = _repo.Dates.GetLatestDate();

            PickedStartDate = StartDate;
            PickedEndDate = EndDate;

            var operators = _repo.Operators.GetOperators();

            OperatorList = new ObservableCollection<string>(operators);

            var values = _repo.Values.GetValues()
                .OrderBy(val => int.Parse(val.Substring(5)))
                .ToList();

            ValueList = new ObservableCollection<string>(values);
        }

        private bool FormIsValid()
        {
            if (InputValue == "" || SelectedValue == "" || Operator == "")
            {
                MessageBox.Show("Some input is invalid");
                return false;
            }

            return true;
        }
    }
}
