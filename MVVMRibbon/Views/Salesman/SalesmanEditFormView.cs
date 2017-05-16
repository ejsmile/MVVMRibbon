using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using MVVMRibbon.Models.ViewModels;

namespace MVVMRibbon.Common.Views.Salesman
{
    [DevExpress.Utils.MVVM.UI.ViewType("SalesmanView")]
    public partial class SalesmanEditFormView : DevExpress.XtraEditors.XtraUserControl
    {
        public SalesmanEditFormView()
        {
            InitializeComponent();
            if (!DesignMode) InitBindings();
        }
        void InitBindings()
        {
            var fluent = mvvmContext1.OfType<SalesmanViewModel>();
            fluent.SetObjectDataSourceBinding(
                salesmanBindingSource, x => x.Entity, x => x.Update());

            fluent.SetBinding(headBindingSource,
               abs => abs.DataSource, x => x.LookUpEmployee.Entities);

            fluent.SetBinding(
                   gridControl1, gc => gc.DataSource, x => x.WorkersDetails.Entities);

            ((GridView)gridControl1.MainView).OptionsBehavior.Editable = false;
        }
    }
}
