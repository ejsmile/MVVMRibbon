using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using MVVMRibbon.Common.DataModel;
using MVVMRibbon.Common.ViewModel;
using MVVMRibbon.Models.MyDbContextDataModel;
using MVVMRibbon.DataBase;
using MVVMRibbon.DataModels;
using MVVMRibbon.ViewModels;

namespace MVVMRibbon.Models.ViewModels {
    /// <summary>
    /// Represents the root POCO view model for the MyDbContext data model.
    /// </summary>
    public partial class MyDbContextViewModel : DocumentsViewModel<MyDbContextModuleDescription, IMyDbContextUnitOfWork> {
        const string TablesGroup = "Tables";

        const string ViewsGroup = "Views";

        /// <summary>
        /// Creates a new instance of MyDbContextViewModel as a POCO view model.
        /// </summary>
        public static MyDbContextViewModel Create() {
            return ViewModelSource.Create(() => new MyDbContextViewModel());
        }

        /// <summary>
        /// Initializes a new instance of the MyDbContextViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the MyDbContextViewModel type without the POCO proxy factory.
        /// </summary>
        //protected MyDbContextViewModel()
        //    : base(UnitOfWorkSource.GetUnitOfWorkFactory()) {
        //}

        protected override MyDbContextModuleDescription[] CreateModules() {
            return new MyDbContextModuleDescription[] {
                new MyDbContextModuleDescription("Salary", "SalaryCollectionView", TablesGroup, GetPeekCollectionViewModelFactory(x => x.Salaries)),                
                new MyDbContextModuleDescription("Employee", "EmployeeCollectionView", TablesGroup, GetPeekCollectionViewModelFactory(x => x.Employees)),
                new MyDbContextModuleDescription("Manager", "ManagerCollectionView", TablesGroup, GetPeekCollectionViewModelFactory(x => x.Manageres)),
                new MyDbContextModuleDescription("Salesman", "SalesmanCollectionView", TablesGroup, GetPeekCollectionViewModelFactory(x => x.Salesmanes)),
            };
        }
    }

    public partial class MyDbContextModuleDescription : ModuleDescription<MyDbContextModuleDescription> {
        public MyDbContextModuleDescription(string title, string documentType, string group, Func<MyDbContextModuleDescription, object> peekCollectionViewModelFactory = null)
            : base(title, documentType, group, peekCollectionViewModelFactory) {
        }
    }
}