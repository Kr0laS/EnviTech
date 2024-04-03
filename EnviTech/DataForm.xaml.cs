using EnviTech.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EnviTech
{
    /// <summary>
    /// Interaction logic for DataForm.xaml
    /// </summary>
    public partial class DataForm : Window
    {
        private readonly RepositoryFacade _repo;
        private int index = 0;
        private List<object> _tableData;
        private const int GAP = 30;

        public DataForm(RepositoryFacade repo)
        {
            _repo = repo;
            InitializeComponent();
        }

        //injection method
        public void GetFormData(string ValueName, string operation, string inputValue)
        {
            _tableData = _repo.Data.GetDataByValue(ValueName, operation, inputValue).ToList();
            
            dataGrid.ItemsSource = _tableData.GetRange(0, GAP);
        }

        private void LeftButton_Click(object sender, RoutedEventArgs e)
        {
            if (index < GAP)
                return;
            dataGrid.ItemsSource = _tableData.GetRange(index - GAP, index);
            index -= GAP;
        }

        private void RightButton_Click(object sender, RoutedEventArgs e)
        {
            if (index + GAP > _tableData.Count)
            {
                dataGrid.ItemsSource = _tableData.GetRange(index, _tableData.Count - 1);
                index += GAP;
                return;
            }
            dataGrid.ItemsSource = _tableData.GetRange(index, index + GAP);
            index += GAP;
        }
    }
}
