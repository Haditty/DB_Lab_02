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
    /// Interaction logic for StockView.xaml
    /// </summary>
    public partial class StockView : UserControl
    {
        public StockViewModel StockViewModel { get; set; }
        public Store? SelectedStore {get; set; }
        public StockView(StockViewModel stockViewModel)
        {
            InitializeComponent();
            StockViewModel = stockViewModel;
        }

        private void StoresCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems[0] is Store && e is not null)
            {
                SelectedStore = (Store)e.AddedItems[0];
                StockViewModel.SelectedStore = SelectedStore;
                StockViewModel.LoadStoreStock(SelectedStore);
            }
        }
        private void AddBookBtn_Click(object sender, RoutedEventArgs e)
        {
            var addBookDialog = new AddBookDialog(SelectedStore);
            addBookDialog.ShowDialog();
        }
    }
}
