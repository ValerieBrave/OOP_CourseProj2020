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
            mainwin.db.supDeleted += mainwin.RefreshList;
            mainwin.db.supUpdated += mainwin.ShowSupUpdSuccess;
            mainwin.db.supUpdated += mainwin.RefreshFilter;
            mainwin.db.supUpdated += mainwin.RefreshList;
            mainwin.db.supAdded += mainwin.ShowSupAddSuccess;
            mainwin.db.supAdded += mainwin.RefreshFilter;
            mainwin.db.supAdded += mainwin.RefreshList;
            //--
            mainwin.db.ordDeleted += mainwin.ShowOrdDelSuccess;
            mainwin.db.ordDeleted += mainwin.RefreshFilter;
            mainwin.db.ordDeleted += mainwin.RefreshList;
            mainwin.db.ordUpdated += mainwin.ShowOrdUpdSuccess;
            mainwin.db.ordUpdated += mainwin.RefreshFilter;
            mainwin.db.ordUpdated += mainwin.RefreshList;
            mainwin.db.ordAdded += mainwin.ShowOrdAddSuccess;
            mainwin.db.ordAdded += mainwin.RefreshFilter;
            mainwin.db.ordAdded += mainwin.RefreshList;
            //--
            mainwin.db.comDeleted += mainwin.ShowComDelSuccess;
            mainwin.db.comDeleted += mainwin.RefreshFilter;
            mainwin.db.comDeleted += mainwin.RefreshList;
            mainwin.db.comUpdated += mainwin.ShowComUpdSuccess;
            mainwin.db.comUpdated += mainwin.RefreshFilter;
            mainwin.db.comUpdated += mainwin.RefreshList;
            mainwin.db.comAdded += mainwin.ShowComAddSuccess;
            mainwin.db.comAdded += mainwin.RefreshFilter;
            mainwin.db.comAdded += mainwin.RefreshList;
            //--
            mainwin.db.revDeleted += mainwin.ShowRevDelSuccess;
            mainwin.db.revDeleted += mainwin.RefreshFilter;
            mainwin.db.revDeleted += mainwin.RefreshList;
            mainwin.db.revUpdated += mainwin.ShowRevUpdSuccess;
            mainwin.db.revUpdated += mainwin.RefreshFilter;
            mainwin.db.revUpdated += mainwin.RefreshList;
            mainwin.db.revAdded += mainwin.ShowRevAddSuccess;
            mainwin.db.revAdded += mainwin.RefreshFilter;
            mainwin.db.revAdded += mainwin.RefreshList;
            //--
            mainwin.db.setDeleted += mainwin.ShowSetDelSuccess;
            mainwin.db.setDeleted += mainwin.RefreshFilter;
            mainwin.db.setDeleted += mainwin.RefreshList;
            mainwin.db.setUpdated += mainwin.ShowSetUpdSuccess;
            mainwin.db.setUpdated += mainwin.RefreshFilter;
            mainwin.db.setUpdated += mainwin.RefreshList;
            mainwin.db.setAdded += mainwin.ShowSetAddSuccess;
            mainwin.db.setAdded += mainwin.RefreshFilter;
            mainwin.db.setAdded += mainwin.RefreshList;
            //--
            mainwin.db.specDeleted += mainwin.ShowSpecDelSuccess;
            mainwin.db.specDeleted += mainwin.RefreshFilter;
            mainwin.db.specDeleted += mainwin.RefreshList;
            mainwin.db.specUpdated += mainwin.ShowSpecUpdSuccess;
            mainwin.db.specUpdated += mainwin.RefreshFilter;
            mainwin.db.specUpdated += mainwin.RefreshList;
            mainwin.db.specAdded += mainwin.ShowSpecAddSuccess;
            mainwin.db.specAdded += mainwin.RefreshFilter;
            mainwin.db.specAdded += mainwin.RefreshList;
            //--
            mainwin.db.chaDeleted += mainwin.ShowChaDelSuccess;
            mainwin.db.chaDeleted += mainwin.RefreshFilter;
            mainwin.db.chaDeleted += mainwin.RefreshList;
            mainwin.db.chaUpdated += mainwin.ShowChaUpdSuccess;
            mainwin.db.chaUpdated += mainwin.RefreshFilter;
            mainwin.db.chaUpdated += mainwin.RefreshList;
            mainwin.db.chaAdded += mainwin.ShowChaAddSuccess;
            mainwin.db.chaAdded += mainwin.RefreshFilter;
            mainwin.db.chaAdded += mainwin.RefreshList;
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
            cat.db.revDeleted += cat.RefreshCatalog;
            cat.db.revUpdated += cat.RefreshCatalog;
            cat.db.revAdded += cat.RefreshCatalog;
            cat.db.setDeleted += cat.RefreshCatalog;
            cat.db.setUpdated += cat.RefreshCatalog;
            cat.db.setAdded += cat.RefreshCatalog;
            cat.db.specDeleted += cat.RefreshCatalog;
            cat.db.specUpdated += cat.RefreshCatalog;
            cat.db.specAdded += cat.RefreshCatalog;
            cat.db.chaDeleted += cat.RefreshCatalog;
            cat.db.chaUpdated += cat.RefreshCatalog;
            cat.db.chaAdded += cat.RefreshCatalog;
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
            //--
            edit_dip.db.revDeleted += edit_dip.ShowRevDelSuccess;
            edit_dip.db.revDeleted += edit_dip.RefreshForm;
            edit_dip.db.revUpdated += edit_dip.ShowRevUpdSuccess;
            edit_dip.db.revUpdated += edit_dip.RefreshForm;
            edit_dip.db.revAdded += edit_dip.ShowRevAddSuccess;
            edit_dip.db.revAdded += edit_dip.RefreshForm;
            //--
            edit_dip.db.setDeleted += edit_dip.ShowSetDelSuccess;
            edit_dip.db.setDeleted += edit_dip.RefreshForm;
            edit_dip.db.setUpdated += edit_dip.ShowSetUpdSuccess;
            edit_dip.db.setUpdated += edit_dip.RefreshForm;
            edit_dip.db.setAdded += edit_dip.ShowSetAddSuccess;
            edit_dip.db.setAdded += edit_dip.RefreshForm;
            //--
            edit_dip.db.specDeleted += edit_dip.ShowSpecDelSuccess;
            edit_dip.db.specDeleted += edit_dip.RefreshForm;
            edit_dip.db.specUpdated += edit_dip.ShowSpecUpdSuccess;
            edit_dip.db.specUpdated += edit_dip.RefreshForm;
            edit_dip.db.specAdded += edit_dip.ShowSpecAddSuccess;
            edit_dip.db.specAdded += edit_dip.RefreshForm;
            //--
            edit_dip.db.chaDeleted += edit_dip.ShowChaDelSuccess;
            edit_dip.db.chaDeleted += edit_dip.RefreshForm;
            edit_dip.db.chaUpdated += edit_dip.ShowChaUpdSuccess;
            edit_dip.db.chaUpdated += edit_dip.RefreshForm;
            edit_dip.db.chaAdded += edit_dip.ShowChaAddSuccess;
            edit_dip.db.chaAdded += edit_dip.RefreshForm;
            //--
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
            cat.db.revDeleted -= cat.RefreshCatalog;
            cat.db.revUpdated -= cat.RefreshCatalog;
            cat.db.revAdded -= cat.RefreshCatalog;
            cat.db.setDeleted -= cat.RefreshCatalog;
            cat.db.setUpdated -= cat.RefreshCatalog;
            cat.db.setAdded -= cat.RefreshCatalog;
            cat.db.specDeleted -= cat.RefreshCatalog;
            cat.db.specUpdated -= cat.RefreshCatalog;
            cat.db.specAdded -= cat.RefreshCatalog;
            cat.db.chaDeleted -= cat.RefreshCatalog;
            cat.db.chaUpdated -= cat.RefreshCatalog;
            cat.db.chaAdded -= cat.RefreshCatalog;
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
            edit_dip.db.revDeleted -= edit_dip.ShowRevDelSuccess;
            edit_dip.db.revDeleted -= edit_dip.RefreshForm;
            edit_dip.db.revUpdated -= edit_dip.ShowRevUpdSuccess;
            edit_dip.db.revUpdated -= edit_dip.RefreshForm;
            edit_dip.db.revAdded -= edit_dip.ShowRevAddSuccess;
            edit_dip.db.revAdded -= edit_dip.RefreshForm;
            edit_dip.db.setDeleted -= edit_dip.ShowSetDelSuccess;
            edit_dip.db.setDeleted -= edit_dip.RefreshForm;
            edit_dip.db.setUpdated -= edit_dip.ShowSetUpdSuccess;
            edit_dip.db.setUpdated -= edit_dip.RefreshForm;
            edit_dip.db.setAdded -= edit_dip.ShowSetAddSuccess;
            edit_dip.db.setAdded -= edit_dip.RefreshForm;
            edit_dip.db.specDeleted -= edit_dip.ShowSpecDelSuccess;
            edit_dip.db.specDeleted -= edit_dip.RefreshForm;
            edit_dip.db.specUpdated -= edit_dip.ShowSpecUpdSuccess;
            edit_dip.db.specUpdated -= edit_dip.RefreshForm;
            edit_dip.db.specAdded -= edit_dip.ShowSpecAddSuccess;
            edit_dip.db.specAdded -= edit_dip.RefreshForm;
            edit_dip.db.chaDeleted -= edit_dip.ShowChaDelSuccess;
            edit_dip.db.chaDeleted -= edit_dip.RefreshForm;
            edit_dip.db.chaUpdated -= edit_dip.ShowChaUpdSuccess;
            edit_dip.db.chaUpdated -= edit_dip.RefreshForm;
            edit_dip.db.chaAdded -= edit_dip.ShowChaAddSuccess;
            edit_dip.db.chaAdded -= edit_dip.RefreshForm;
            edit_dip.ex_handler.Error -= edit_dip.ShowProtocol;
        }
    }
}
