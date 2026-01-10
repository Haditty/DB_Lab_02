using Lab_02.Commands;
using Lab_02.Models;
using Lab_02.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Windows.Themes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Lab_02.ViewModels
{
    public class StockViewModel : ViewModelBase
    {
        public ObservableCollection<Store> Stores { get; set; }
        public StockView StockView { get; set; }
        public ObservableCollection<Book> Books { get; set; }
        public DelegateCommand SetSelectedStoreCommand { get; set; }
        public DelegateCommand ShowRemoveBookCommand { get; set; }
        public Action<object> ShowRemoveBookWindow { get; set; }
        private ObservableCollection<StockSummary> _stock;
        public ObservableCollection<StockSummary> Stock
        {
            get => _stock;
            set
            {
                _stock = value;
                RaisePropertyChanged();
            }
        }
        private StockSummary _selectedBook;
        public StockSummary SelectedBook
        {
            get => _selectedBook;
            set
            {
                _selectedBook = value;
                RaisePropertyChanged();
                ShowRemoveBookCommand.RaiseCanExecuteChanged();
            }
        }
        private Store _selectedStore;
        public Store SelectedStore
        {
            get => _selectedStore;
            set
            {
                _selectedStore = value;
                StockView.SelectedStore = value;
                RaisePropertyChanged();
            }
        }
        public StockViewModel(Action<object> showRemoveBookWindow)
        {
            StockView = new StockView(this);
            SetSelectedStoreCommand = new DelegateCommand(SetSelectedStore);
            ShowRemoveBookCommand = new DelegateCommand(showRemoveBookWindow, CanShowRemoveBookWindow);
            LoadStores();
            LoadBooks();
        }
        private void LoadBooks()
        {
            using (var db = new Lab01Context())
            {
                Books = new ObservableCollection<Book>(
                    db.Books.ToList()
                );
            }
        }
        private bool CanShowRemoveBookWindow(object? arg) => SelectedBook != null;
        // The implementation of this method should not be done in a ViewModel. It should be done in Code Behind.
        // Because the ViewModel should not know anything about the functionality of the window.
        /*private void ShowRemoveBookWindow(object obj)
        {
            throw new NotImplementedException();
        }*/
        private void SetSelectedStore(object? obj)
        {
            if (obj is Store)
            {
                SelectedStore = (Store)obj;
                Stock = LoadStoreStock(SelectedStore);
                StockView.StoresCB.SelectedItem = SelectedStore;
            }
        }

        public void LoadStores ()
        {
            /*using (var db = new Lab01Context())
            {
                var stores = db.Stores.ToList();
                StockView.StoresCB.ItemsSource = new ObservableCollection<Store>(stores);
            }*/
            using (var db = new Lab01Context())
            {
                Stores = new ObservableCollection<Store>(
                    db.Stores.ToList()
                );
            }
        }

        public ObservableCollection<StockSummary> LoadStoreStock (Store selectedStore)
        {
            using (var db = new Lab01Context())
            {
                var stock = db.StockStatuses
                    .Include(s => s.Store)
                    .Where(s => s.StoreId == selectedStore.Id)
                    .Select(s => new StockSummary
                    {
                        ISBN = s.Book.Isbn,
                        Title = s.Book.Title,
                        Price = s.Book.Price,
                        Publisher = s.Book.Publisher.Name,
                        Stock = s.InStock,
                    })
                    .ToList();
                return new ObservableCollection<StockSummary>(stock);
            }
        }
    }
}
