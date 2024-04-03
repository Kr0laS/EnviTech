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

        public DataForm(RepositoryFacade repo)
        {
            _repo = repo;
            InitializeComponent();
        }

        //injection method
        public void GetFormData(string ValueName, string operation, string inputValue)
        {
            var list = _repo.Data.GetDataByValue(ValueName, operation, inputValue).ToList();
            Console.WriteLine();
        }
    }
}
