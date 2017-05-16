using System;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.Mvvm;
using DevExpress.XtraEditors;
using MVVMRibbon.Models.ViewModels;

namespace MVVMRibbon {
    public partial class MainView : XtraForm {
        public MainView() {
            InitializeComponent();
            this.Opacity = 0;
            if(!DesignMode)
                InitializeNavigation();
            ribbonControl1.Merge += ribbonControl1_Merge;
        }
        void ribbonControl1_Merge(object sender, DevExpress.XtraBars.Ribbon.RibbonMergeEventArgs e) {
            ribbonControl1.SelectedPage = e.MergedChild.SelectedPage;
        }
        void InitializeNavigation() {
            var fluentAPI = mvvmContext1.OfType<MyDbContextViewModel>();
            fluentAPI.BindCommand(biiSalary, (x, m) => x.Show(m), x => x.Modules[0]);
            fluentAPI.BindCommand(biiEmployee, (x, m) => x.Show(m), x => x.Modules[1]);
            fluentAPI.BindCommand(biiManager, (x, m) => x.Show(m), x => x.Modules[2]);
            fluentAPI.BindCommand(biiSalesman, (x, m) => x.Show(m), x => x.Modules[3]);
            
            //
            fluentAPI.BindCommand(biLogout, x => x.Logout());
            //
            fluentAPI.WithEvent(this, "Load")
                .EventToCommand(x => x.OnLoaded(null), x => x.DefaultModule);
            fluentAPI.WithEvent<FormClosingEventArgs>(this, "FormClosing")
                .EventToCommand(x => x.OnClosing(null), new Func<CancelEventArgs, object>((args) => args));
            fluentAPI.SetTrigger(x => x.State, (state) =>
            {
                if(state == AppState.Authorized)
                    Opacity = 1; /*Show Main Form*/
                if(state == AppState.ExitQueued)
                    Close(); // exit the app;
            });
            Messenger.Default.Register<string>(this, OnUserNameMessage);
        }
        void OnUserNameMessage(string userName) {
            if(string.IsNullOrEmpty(userName))
                this.Text = "Salary Application";
            else
                this.Text = "Salary Application - (" + userName + ")";
        }
    }
}