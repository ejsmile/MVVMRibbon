using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMRibbon.Models.MyDbContextDataModel;

namespace MVVMRibbon.Models.Calcalation
{
    public static class CalculationSalarySource<TUnitOfWork> where TUnitOfWork : IMyDbContextUnitOfWork
    {
        public static ICalculationSalary<TUnitOfWork> CalculationSalaryFactory(TUnitOfWork unitOfWork)
        {
            return new CalculationSalary<TUnitOfWork>(unitOfWork,
                CalculationEmployeeSource<TUnitOfWork>.CalculationEmployeeFactory(unitOfWork));
        }
    }
}
