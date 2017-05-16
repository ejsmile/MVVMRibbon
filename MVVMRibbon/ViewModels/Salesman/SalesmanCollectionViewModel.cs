using System;
using System.Linq;
using DevExpress.Mvvm.POCO;
using MVVMRibbon.Common.Utils;
using MVVMRibbon.Models.MyDbContextDataModel;
using MVVMRibbon.Common.DataModel;
using MVVMRibbon.DataModels;
using MVVMRibbon.DataBase;
using MVVMRibbon.Common.ViewModel;

namespace MVVMRibbon.Models.ViewModels  
{
    public class SalesmanListViewModel : CollectionViewModel<Salesman, long, IMyDbContextUnitOfWork>
    {
        /// <summary>
        /// Creates a new instance of SalesmanListViewModel as a POCO view model.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        public static SalesmanListViewModel Create(
            IUnitOfWorkFactory<IMyDbContextUnitOfWork> unitOfWorkFactory = null)
        {
            return ViewModelSource.Create(() => new SalesmanListViewModel(unitOfWorkFactory));
        }

        /// <summary>
        /// Initializes a new instance of the SalesmanListViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the SalesmanListViewModel type without the POCO proxy factory.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        protected SalesmanListViewModel(IUnitOfWorkFactory<IMyDbContextUnitOfWork> unitOfWorkFactory = null)
            : base(unitOfWorkFactory ?? UnitOfWorkSource.GetUnitOfWorkFactory(), x => x.Salesmanes)
        {
        }
    }
}