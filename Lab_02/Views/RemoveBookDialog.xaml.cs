using Lab_02.Models;
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

namespace Lab_02.Views
{
    /// <summary>
    /// Interaction logic for RemoveBookDialog.xaml
    /// </summary>
    public partial class RemoveBookDialog : Window
    {
        public Store SelectedStore { get; set; }
        public StockSummary SelectedBook { get; set; }
        public RemoveBookDialog(Store? selectedStore, StockSummary selectedBook)
        {
            SelectedStore = selectedStore;
            SelectedBook = selectedBook;
            //this class should get the selected book from StockView when gets created
            InitializeComponent();
        }

        private void Remove_Button_Click(object sender, RoutedEventArgs e)
        {
            RemoveBook(Int32.Parse(AmountTb.Text));
            Close();
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void RemoveBook (int amount)
        {
            using (var db = new Lab01Context())
            {
                //var bookToRemove = 

                var bookToRemove = db.StockStatuses.Find(SelectedStore.Id,SelectedBook.ISBN);
                bookToRemove.InStock -= amount;
                if (bookToRemove.InStock < 0)
                    db.StockStatuses.Remove(bookToRemove);
                db.SaveChanges();
                var bb = db.StockStatuses.ToList();
            }
        }
    }
}
