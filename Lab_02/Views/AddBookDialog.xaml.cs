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
        public AddBookDialog()
        {
            InitializeComponent();
            Loaded += AddBookDialog_Loaded;
        }
        private void AddBookDialog_Loaded(object sender, RoutedEventArgs e)
        {
            using (var db = new Lab01Context())
            {
                var books = db.Books.ToList();
                BookCb.ItemsSource = new ObservableCollection<Book>(books);
            }
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
