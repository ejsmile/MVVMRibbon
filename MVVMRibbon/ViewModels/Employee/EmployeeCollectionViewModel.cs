using System;
using System.Data.Entity.Core.Objects;
using System.Linq;
using DevExpress.Data.Helpers;
using DevExpress.Mvvm.POCO;
using MVVMRibbon.Common.Utils;
using MVVMRibbon.Models.MyDbContextDataModel;
using MVVMRibbon.Common.DataModel;
using MVVMRibbon.DataModels;
using MVVMRibbon.DataBase;
using MVVMRibbon.Common.ViewModel;

namespace MVVMRibbon.Models.ViewModels
{
    public class EmployeeCollectionViewModel : CollectionViewModel<Employee, long, IMyDbContextUnitOfWork>
    {
        /// <summary>
        /// Creates a new instance of EmployeeCollectionViewModel as a POCO view model.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        public static EmployeeCollectionViewModel Create(
            IUnitOfWorkFactory<IMyDbContextUnitOfWork> unitOfWorkFactory = null)
        {
            return ViewModelSource.Create(() => new EmployeeCollectionViewModel(unitOfWorkFactory));
        }

        /// <summary>
        /// Initializes a new instance of the EmployeeCollectionViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the EmployeeCollectionViewModel type without the POCO proxy factory.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        protected EmployeeCollectionViewModel(IUnitOfWorkFactory<IMyDbContextUnitOfWork> unitOfWorkFactory = null)
            //TODO подумать получаеться класс слишком много знает о иерархий            
            : base(unitOfWorkFactory ?? UnitOfWorkSource.GetUnitOfWorkFactory(), x => x.Employees, e => e.Where(ee => !(ee is Manager) && !(ee is Salesman)))
        //подумать над ORM(RepositoryQueryBase)
        //: base(unitOfWorkFactory ?? UnitOfWorkSource.GetUnitOfWorkFactory(), x => x.Employees, e => e.Where(ee => ObjectContext.GetObjectType(ee.GetType()) == typeof(Employee) ))
        {
        }
    }
}