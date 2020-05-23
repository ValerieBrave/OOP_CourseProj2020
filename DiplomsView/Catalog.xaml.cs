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
using DiplomsDB.Models;

namespace DiplomsView
{
    /// <summary>
    /// Логика взаимодействия для Catalog.xaml
    /// </summary>
    public partial class Catalog : Window
    {
        public ContextDB db;
        dbExceptionHandler handler;
        CatalogFiller filler;
        int cat_id;
        public Catalog()
        {
            InitializeComponent();
        }
        public Catalog(dbExceptionHandler h, int id)
        {
            InitializeComponent();
            db = SingleContext.getContext();
            handler = h;
            cat_id = id;
            filler = new CatalogFiller(handler, this, this.catalog, this.catalog_name, cat_id);
            filler.Fill(cat_id);
        }

        public void RefreshCatalog(string id)
        {
            this.catalog.Items.Clear();
            filler.Fill(cat_id);
        }

        private void btn_addElem_Click(object sender, RoutedEventArgs e)
        {
            AddCatElement ace = new AddCatElement(handler, cat_id);
            ace.ShowDialog();
        }

        private void Catalog_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Subscriber.Unsubscribe(this);
        }
    }
}
