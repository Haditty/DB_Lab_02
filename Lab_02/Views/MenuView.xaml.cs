using Lab_02.Models;
using Lab_02.ViewModels;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab_02.Views
{
    /// <summary>
    /// Interaction logic for MenuView.xaml
    /// </summary>
    public partial class MenuView : UserControl
    {
        public MainWindowViewModel MainWindowViewModel { get; set; }
        public StockViewModel StockViewModel { get; set; }
        public MenuView(MainWindowViewModel mainWindowViewModel)
        {
            MainWindowViewModel = mainWindowViewModel;
            StockViewModel = MainWindowViewModel.StockViewModel;
            InitializeComponent();
        }
        private void OpenAddBookDialog_Click(object sender, RoutedEventArgs e)
        {
            var addBookDialog = new AddBookDialog(StockViewModel.SelectedStore, StockViewModel);
            addBookDialog.ShowDialog();
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindowViewModel.MainWindow.Close();
        }
    }
}
