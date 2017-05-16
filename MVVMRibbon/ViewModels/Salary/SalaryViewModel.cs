using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DevExpress.Data.Helpers;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using MVVMRibbon.Common;
using MVVMRibbon.Common.Utils;
using MVVMRibbon.Models.MyDbContextDataModel;
using MVVMRibbon.Common.DataModel;
using MVVMRibbon.DataModels;
using MVVMRibbon.DataBase;
using MVVMRibbon.Common.ViewModel;
using MVVMRibbon.Models.Calcalation;

namespace MVVMRibbon.Models.ViewModels
{
    public partial class SalaryViewModel : SingleObjectViewModel<Salary, long, IMyDbContextUnitOfWork>
    {
        private readonly ICalculationSalary<IMyDbContextUnitOfWork> _calculationSalary;
        /// <summary>
        /// Creates a new instance of SalaryViewModel as a POCO view model.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        /// <param name="calculationSalary">Class for calculationSalary salary</param>
        public static SalaryViewModel Create(IUnitOfWorkFactory<IMyDbContextUnitOfWork> unitOfWorkFactory = null, ICalculationSalary<IMyDbContextUnitOfWork> calculationSalary = null)
        {
            return ViewModelSource.Create(() => new SalaryViewModel(unitOfWorkFactory, calculationSalary));
        }

        /// <summary>
        /// Initializes a new instance of the SalaryViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the SalaryViewModel type without the POCO proxy factory.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        /// <param name="calculationSalary">Class for calculationSalary salary</param>
        protected SalaryViewModel(IUnitOfWorkFactory<IMyDbContextUnitOfWork> unitOfWorkFactory = null, ICalculationSalary<IMyDbContextUnitOfWork> calculationSalary = null)
            : base(unitOfWorkFactory ?? UnitOfWorkSource.GetUnitOfWorkFactory(), x => x.Salaries, x => x.ToString())
        {
            _calculationSalary = calculationSalary ?? CalculationSalarySource<IMyDbContextUnitOfWork>.CalculationSalaryFactory(UnitOfWork);
        }

        /// <summary>
        /// The view model that contains a look-up collection of Employee for the corresponding navigation property in the view.
        /// </summary>
        public IEntitiesViewModel<Employee> LookUpEmployee
        {
            get { return GetLookUpEntitiesViewModel((SalaryViewModel x) => x.LookUpEmployee, x => x.Employees); }
        }

        public CollectionViewModel<Employee, long, IMyDbContextUnitOfWork> WorkersDetails
        {
            get
            {
                return GetDetailsCollectionViewModel((SalaryViewModel x) => x.WorkersDetails, x => x.Employees,
                    x => x.HeadID, (x, key) => x.HeadID = key);
            }
        }

        [Command(CanExecuteMethodName = "CanCalculation")]
        public void Calculation()
        {
            var tuple = _calculationSalary.Calculation(Entity);
            if (!string.IsNullOrEmpty(tuple.Item2))
            {
               MessageBoxService.ShowMessage(tuple.Item2, CommonResources.Warning_Caption, MessageButton.OK);
            }
            else
            {
                if (Entity.Money == tuple.Item1) return;
                Entity.Money = tuple.Item1;
                this.RaisePropertyChanged(x => x.Entity);
                OnEntityChanged();
            }
        }
        
        public bool CanCalculation()
        {
            return ((Entity?.EmployeeID ?? -1) > 0) && _calculationSalary != null;
        }

        protected override void UpdateCommands()
        {
            base.UpdateCommands();
            this.RaiseCanExecuteChanged(x => x.Calculation());
        }
    }
}