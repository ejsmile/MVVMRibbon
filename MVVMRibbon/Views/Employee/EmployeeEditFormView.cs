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
using MVVMRibbon.Models;
using MVVMRibbon.Models.ViewModels;
using DevExpress.XtraGrid.Views.Grid;
using System.Data.Entity;

namespace MVVMRibbon.Common.Views.Employee
{
    [DevExpress.Utils.MVVM.UI.ViewType("EmployeeView")]
    public partial class EmployeeEditFormView : DevExpress.XtraEditors.XtraUserControl
    {
        public EmployeeEditFormView()
        {
            InitializeComponent();
            if (!DesignMode) InitBindings();
        }

        void InitBindings()
        {
            var fluent = mvvmContext1.OfType<EmployeeViewModel>();
            fluent.SetObjectDataSourceBinding(
                employeeBindingSource, x => x.Entity, x => x.Update());

            fluent.SetBinding(headBindingSource,
               abs => abs.DataSource, x => x.LookUpEmployee.Entities);
        }
    }
}
