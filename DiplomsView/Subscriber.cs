using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiplomsDB.Models;

namespace DiplomsView
{
    public static class Subscriber
    {
        public static void Subscribe(MainWindow mainwin)
        {
            mainwin.db.diplomAdded += mainwin.RefreshList;
            mainwin.db.diplomAdded += mainwin.ShowDipAddSuccess;
            mainwin.db.diplomDeleted += mainwin.RefreshList;
            mainwin.db.diplomDeleted += mainwin.ShowDipDelSuccess;
            mainwin.db.diplomUpdated += mainwin.RefreshList;
            mainwin.db.diplomUpdated += mainwin.ShowDipUpdSuccess;
            //--
            mainwin.db.supDeleted += mainwin.ShowSupDelSuccess;
            mainwin.db.supDeleted += mainwin.RefreshFilter;
            mainwin.db.supUpdated += mainwin.ShowSupUpdSuccess;
            mainwin.db.supUpdated += mainwin.RefreshFilter;
            mainwin.db.supUpdated += mainwin.RefreshList;
            mainwin.db.supAdded += mainwin.ShowSupAddSuccess;
            mainwin.db.supAdded += mainwin.RefreshFilter;
            //--
            mainwin.db.ordDeleted += mainwin.ShowOrdDelSuccess;
            mainwin.db.ordDeleted += mainwin.RefreshFilter;
            mainwin.db.ordUpdated += mainwin.ShowOrdUpdSuccess;
            mainwin.db.ordUpdated += mainwin.RefreshFilter;
            mainwin.db.ordAdded += mainwin.ShowOrdAddSuccess;
            mainwin.db.ordAdded += mainwin.RefreshFilter;
            //--
            mainwin.db.comDeleted += mainwin.ShowComDelSuccess;
            mainwin.db.comDeleted += mainwin.RefreshFilter;
            mainwin.db.comUpdated += mainwin.ShowComUpdSuccess;
            mainwin.db.comUpdated += mainwin.RefreshFilter;
            mainwin.db.comAdded += mainwin.ShowComAddSuccess;
            mainwin.db.comAdded += mainwin.RefreshFilter;
            //--
            mainwin.ex_handler.Error += mainwin.ShowProtocol;

        }
        public static void Subscribe(Catalog cat)
        {
            cat.db.supDeleted += cat.RefreshCatalog;
            cat.db.supUpdated += cat.RefreshCatalog;
            cat.db.supAdded += cat.RefreshCatalog;
            cat.db.ordAdded += cat.RefreshCatalog;
            cat.db.ordDeleted += cat.RefreshCatalog;
            cat.db.ordUpdated += cat.RefreshCatalog;
            cat.db.comDeleted += cat.RefreshCatalog;
            cat.db.comUpdated += cat.RefreshCatalog;
            cat.db.comAdded += cat.RefreshCatalog;
        }
        public static void Subscribe(AddEditDiplom edit_dip)
        {
            edit_dip.db.diplomAdded += edit_dip.ShowDipAddSuccess;
            edit_dip.db.diplomDeleted += edit_dip.ShowDipDelSuccess;
            edit_dip.db.diplomUpdated += edit_dip.ShowDipUpdSuccess;
            //--
            edit_dip.db.supDeleted += edit_dip.ShowSupDelSuccess;
            edit_dip.db.supDeleted += edit_dip.RefreshForm;
            edit_dip.db.supUpdated += edit_dip.ShowSupUpdSuccess;
            edit_dip.db.supUpdated += edit_dip.RefreshForm;
            edit_dip.db.supAdded += edit_dip.ShowSupAddSuccess;
            edit_dip.db.supAdded += edit_dip.RefreshForm;
            //--
            edit_dip.db.ordDeleted += edit_dip.ShowOrdDelSuccess;
            edit_dip.db.ordDeleted += edit_dip.RefreshForm;
            edit_dip.db.ordUpdated += edit_dip.ShowOrdUpdSuccess;
            edit_dip.db.ordUpdated += edit_dip.RefreshForm;
            edit_dip.db.ordAdded += edit_dip.ShowOrdAddSuccess;
            edit_dip.db.ordAdded += edit_dip.RefreshForm;
            //--
            edit_dip.db.comDeleted += edit_dip.ShowComDelSuccess;
            edit_dip.db.comDeleted += edit_dip.RefreshForm;
            edit_dip.db.comUpdated += edit_dip.ShowComUpdSuccess;
            edit_dip.db.comUpdated += edit_dip.RefreshForm;
            edit_dip.db.comAdded += edit_dip.ShowComAddSuccess;
            edit_dip.db.comAdded += edit_dip.RefreshForm;
            edit_dip.ex_handler.Error += edit_dip.ShowProtocol;
        }
        public static void Unsubscribe(Catalog cat)
        {
            cat.db.supDeleted -= cat.RefreshCatalog;
            cat.db.supUpdated -= cat.RefreshCatalog;
            cat.db.supAdded -= cat.RefreshCatalog;
            cat.db.ordAdded -= cat.RefreshCatalog;
            cat.db.ordDeleted -= cat.RefreshCatalog;
            cat.db.ordUpdated -= cat.RefreshCatalog;
            cat.db.comDeleted -= cat.RefreshCatalog;
            cat.db.comUpdated -= cat.RefreshCatalog;
            cat.db.comAdded -= cat.RefreshCatalog;
        }
        public static void Unsubscribe(AddEditDiplom edit_dip)
        {
            edit_dip.db.diplomAdded -= edit_dip.ShowDipAddSuccess;
            edit_dip.db.diplomDeleted -= edit_dip.ShowDipDelSuccess;
            edit_dip.db.diplomUpdated -= edit_dip.ShowDipUpdSuccess;
            edit_dip.db.supDeleted -= edit_dip.ShowSupDelSuccess;
            edit_dip.db.supDeleted -= edit_dip.RefreshForm;
            edit_dip.db.supUpdated -= edit_dip.ShowSupUpdSuccess;
            edit_dip.db.supUpdated -= edit_dip.RefreshForm;
            edit_dip.db.supAdded -= edit_dip.ShowSupAddSuccess;
            edit_dip.db.supAdded -= edit_dip.RefreshForm;
            edit_dip.db.ordDeleted -= edit_dip.ShowOrdDelSuccess;
            edit_dip.db.ordDeleted -= edit_dip.RefreshForm;
            edit_dip.db.comDeleted -= edit_dip.ShowComDelSuccess;
            edit_dip.db.comDeleted -= edit_dip.RefreshForm;
            edit_dip.db.comUpdated -= edit_dip.ShowComUpdSuccess;
            edit_dip.db.comUpdated -= edit_dip.RefreshForm;
            edit_dip.db.comAdded -= edit_dip.ShowComAddSuccess;
            edit_dip.db.comAdded -= edit_dip.RefreshForm;
            edit_dip.ex_handler.Error -= edit_dip.ShowProtocol;
        }
    }
}
