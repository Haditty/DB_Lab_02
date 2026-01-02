using Lab_02.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Lab_02.ViewModels
{
    internal class MainWindowViewModel : ViewModelBase
    {
        public MainWindow MainWindow { get; set; }
        public StockView StockView { get; set; }
        public UserControl ActiveView { get; set; }
        public MainWindowViewModel(MainWindow mainWindow)
        {
            MainWindow = mainWindow;
            StockView = new StockView();
            ActiveView = StockView;
            Grid.SetRow(ActiveView, 1);
            MainWindow.Grid.Children.Add(ActiveView);
        }

    }
}
