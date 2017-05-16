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
 
    public class ManagerCollectionViewModel : CollectionViewModel<Manager, long, IMyDbContextUnitOfWork>
    {
        /// <summary>
        /// Creates a new instance of ManagerCollectionViewModel as a POCO view model.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        public static ManagerCollectionViewModel Create(
            IUnitOfWorkFactory<IMyDbContextUnitOfWork> unitOfWorkFactory = null)
        {
            return ViewModelSource.Create(() => new ManagerCollectionViewModel(unitOfWorkFactory));
        }

        /// <summary>
        /// Initializes a new instance of the ManagerCollectionViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the ManagerCollectionViewModel type without the POCO proxy factory.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        protected ManagerCollectionViewModel(IUnitOfWorkFactory<IMyDbContextUnitOfWork> unitOfWorkFactory = null)
            : base(unitOfWorkFactory ?? UnitOfWorkSource.GetUnitOfWorkFactory(), x => x.Manageres)
        {
        }
    }
}