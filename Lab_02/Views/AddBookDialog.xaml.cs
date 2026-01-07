using Lab_02.Models;
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
        public ObservableCollection<Book> Books { get; set; }
        public Store? SelectedStore { get; set; }
        public AddBookDialog(Store? selectedStore)
        {
            InitializeComponent();
            using (var db = new Lab01Context())
            {
                Books = new ObservableCollection<Book>(
                    db.Books.ToList()
                );
            }
            Loaded += AddBookDialog_Loaded;
            SelectedStore = selectedStore;
        }
        private void AddBookDialog_Loaded(object sender, RoutedEventArgs e)
        {
            BookCb.ItemsSource = Books;
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new Lab01Context())
            {
                var books = db.Books.ToList();
                //Code for adding the book and the right amount to the selected store
                //make sure the data grid in stock view is updated if user clicks on Add btn
            }
            Close();
        }
    }
}
