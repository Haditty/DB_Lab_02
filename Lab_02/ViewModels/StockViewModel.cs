using Lab_02.Models;
using Lab_02.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_02.ViewModels
{
    internal class StockViewModel
    {
        public StockView StockView { get; set; }
        public StockViewModel(StockView stockView)
        {
            StockView = stockView;
            using (var db = new Lab01Context())
            {
                var stores = db.Stores.ToList();
                StockView.StoresCB.ItemsSource = new ObservableCollection<Store>(stores);
                //StockView.StockDG.ItemsSource = 
            }
        }
    }
}
