using Lab_02.Models;
using Lab_02.Views;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_02.ViewModels
{
    public class StockViewModel
    {
        public StockView StockView { get; set; }
        public StockViewModel()
        {
            StockView = new StockView(this);
            using (var db = new Lab01Context())
            {
                var stores = db.Stores.ToList();
                StockView.StoresCB.ItemsSource = new ObservableCollection<Store>(stores);
            }
        }

        public void LoadStoreStock (Store selectedStore)
        {
            using (var db = new Lab01Context())
            {
                var stock = db.StockStatuses
                    .Include(s => s.Store)
                    .Where(s => s.StoreId == selectedStore.Id)
                    .Select(s => new
                    {
                        ISBN = s.Book.Isbn,
                        Title = s.Book.Title,
                        Price = s.Book.Price,
                        Publisher = s.Book.Publisher.Name,
                        Stock = s.InStock,
                    })
                    .ToList();

                var collection = new ObservableCollection<object>(stock);
                StockView.StockDG.ItemsSource = collection;
            }
        }
    }
}
