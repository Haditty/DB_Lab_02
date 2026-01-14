using Lab_02.Models;
using Lab_02.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Lab_02.Views
{
    /// <summary>
    /// Interaction logic for AddBookDialog.xaml
    /// </summary>
    public partial class AddBookDialog : Window
    {
        public Store? SelectedStore { get; set; }
        public StockViewModel StockViewModel { get; set; }
        public Book SelectedBook { get; set; }
        public ObservableCollection<StockSummary> SelectedStoreStock {  get; set; }
        public AddBookDialog(Store? selectedStore, StockViewModel stockViewModel)
        {
            InitializeComponent();
            StockViewModel = stockViewModel;
            SelectedStore = selectedStore;
            DataContext = StockViewModel;
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            //make sure the data grid in stock view is updated if user clicks on Add btn
            try
            {
            AddBook(Int32.Parse(AmountTb.Text));
            }
            catch { }
            Close();
        }

        //Make a command from this
        private void AddBook (int amount)
        {
            SelectedStoreStock = StockViewModel.LoadStoreStock(SelectedStore);
            SelectedBook = (Book)BookCb.SelectedItem;
            var addedStock = new StockStatus() { BookId = SelectedBook.Isbn, StoreId = SelectedStore.Id, InStock = amount};
            using (var db = new Lab01Context())
            {
                var bookToUpdate = db.StockStatuses.Find(SelectedStore.Id, SelectedBook.Isbn);
                if (bookToUpdate != null)
                {
                    bookToUpdate.InStock += amount;
                    db.SaveChanges();
                    StockViewModel.Stock = StockViewModel.LoadStoreStock(SelectedStore);
                    return;
                }
                db.StockStatuses.Add(addedStock);
                db.SaveChanges();
                StockViewModel.Stock = StockViewModel.LoadStoreStock(SelectedStore);
            }
        }
    }
}
