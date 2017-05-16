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

namespace MVVMRibbon.Common.Views.Salary { 
    [DevExpress.Utils.MVVM.UI.ViewType("SalaryView")]
    public partial class SalaryEditFormView : DevExpress.XtraEditors.XtraUserControl
    {
        public SalaryEditFormView()
        {
            InitializeComponent();
            if (!DesignMode) InitBindings();
        }
        void InitBindings()
        {
            var fluent = mvvmContext1.OfType<SalaryViewModel>();
            fluent.SetObjectDataSourceBinding(
                salaryBindingSource, x => x.Entity, x => x.Update());

            fluent.SetBinding(employeeBindingSource,
               abs => abs.DataSource, x => x.LookUpEmployee.Entities);
        }
    }
}
