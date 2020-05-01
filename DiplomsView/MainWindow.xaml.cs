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
using DiplomsDB.Models;

namespace DiplomsView
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ContextDB db;
        DiplomListFiller list_filler;
        public MainWindow()
        {
            InitializeComponent();
            db = new ContextDB();
            list_filler = new DiplomListFiller(this.diplomsList, db);
            FilterFiller filter_filler = new FilterFiller(this.filterGrid, db);
            list_filler.Fill();
            filter_filler.Fill(this.order_Select, this.spec_Select, this.supervisor_Select, this.setter_Select, this.reviewer_Select, this.comission_Select);

        }

        private void btn_Search_Click(object sender, RoutedEventArgs e)
        {
            bool search = false;
            String query = "select * from Diploms ";
            if((bool)check_Order.IsChecked)
            {
                search = true;
                query += " where Diploms.Order_id like '" + ((Order)this.order_Select.SelectedItem).Order_id + "'";
                var dips = this.db.Database.SqlQuery<Diplom>(query);
                this.diplomsList.Items.Clear();
                foreach (var dip in dips) this.diplomsList.Items.Add(list_filler.getExpander((Diplom)dip));
                //this.diplomsList.ItemsSource = dips;
                this.diplomsList.Items.Refresh();
            }
        }
    }
}
