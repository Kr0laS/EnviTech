using EnviTech.Db;
using EnviTech.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace EnviTech
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private readonly MainViewModel viewModel;

        public MainWindow(MainViewModel vm)
        {
            InitializeComponent();
            viewModel = vm;
            DataContext = viewModel;
        }
    }
}
