using Lab_02.Models;
using Lab_02.Views;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Lab_02.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindow MainWindow { get; set; }
        public UserControl ActiveView { get; set; }
        public StockViewModel StockViewModel { get; set; }
        public MenuView MenuView { get; set; }
        public MainWindowViewModel(MainWindow mainWindow)
        {
            MainWindow = mainWindow;
            StockViewModel = new StockViewModel(OpenRemoveBookWindow);
            MenuView = new MenuView(this);
            ActiveView = StockViewModel.StockView;
            Grid.SetRow(MenuView, 0);
            Grid.SetRow(ActiveView, 1);
            MainWindow.Grid.Children.Add(MenuView);
            MainWindow.Grid.Children.Add(ActiveView);
        }
        private void OpenRemoveBookWindow(object obj)
        {
            var removeBookDialog = new RemoveBookDialog(StockViewModel.SelectedStore, StockViewModel.SelectedBook, StockViewModel);
            removeBookDialog.ShowDialog();
        }
    }
}