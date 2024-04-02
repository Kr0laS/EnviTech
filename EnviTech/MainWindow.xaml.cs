using EnviTech.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
