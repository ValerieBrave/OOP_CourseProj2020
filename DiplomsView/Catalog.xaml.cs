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
        ContextDB db;
        dbExceptionHandler handler;
        CatalogFiller filler;
        int cat_id;
        public Catalog()
        {
            InitializeComponent();
        }
        public Catalog(ContextDB d, dbExceptionHandler h, int id)
        {
            InitializeComponent();
            db = d;
            handler = h;
            cat_id = id;
            filler = new CatalogFiller(db, handler, this, this.catalog, cat_id);
            filler.Fill(cat_id);
        }

        public void RefreshCatalog(string id)
        {
            this.catalog.Items.Clear();
            filler.Fill(cat_id);
        }

    }
}
