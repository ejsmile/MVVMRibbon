using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DevExpress.Data.Helpers;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using MVVMRibbon.Common.Utils;
using MVVMRibbon.Models.MyDbContextDataModel;
using MVVMRibbon.Common.DataModel;
using MVVMRibbon.DataModels;
using MVVMRibbon.DataBase;
using MVVMRibbon.Common.ViewModel;

namespace MVVMRibbon.Models.ViewModels
{
    public class SalesmanViewModel : SingleObjectViewModel<Salesman, long, IMyDbContextUnitOfWork>
    {
        /// <summary>
        /// Creates a new instance of SalesmanViewModel as a POCO view model.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        public static SalesmanViewModel Create(IUnitOfWorkFactory<IMyDbContextUnitOfWork> unitOfWorkFactory = null)
        {
            return ViewModelSource.Create(() => new SalesmanViewModel(unitOfWorkFactory));
        }

        /// <summary>
        /// Initializes a new instance of the SalesmanViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the SalesmanViewModel type without the POCO proxy factory.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        protected SalesmanViewModel(IUnitOfWorkFactory<IMyDbContextUnitOfWork> unitOfWorkFactory = null)
            : base(unitOfWorkFactory ?? UnitOfWorkSource.GetUnitOfWorkFactory(), x => x.Salesmanes, x => x.Name) {
        }

        /// <summary>
        /// The view model that contains a look-up collection of Employee for the corresponding navigation property in the view.
        /// </summary>
        public IEntitiesViewModel<Employee> LookUpEmployee
        {
            get
            {
                var id = Entity?.ID ?? -1;
                return GetLookUpEntitiesViewModel((SalaryViewModel x) => x.LookUpEmployee, x => x.Employees, e => e.Where(ee => ee.IsCanHead && id != ee.ID));
            }
        }

        public CollectionViewModel<Employee, long, IMyDbContextUnitOfWork> WorkersDetails
        {
            get { return GetDetailsCollectionViewModel((ManagerViewModel x) => x.WorkersDetails, x => x.Employees, x => x.HeadID, (x, key) => x.HeadID = key); }
        }
    }
}