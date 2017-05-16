using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMRibbon.Common.DataModel.EntityFramework;
using MVVMRibbon.DataBase;
using MVVMRibbon.Models.MyDbContextDataModel;

namespace MVVMRibbon.Models.Calcalation
{
    public static class CalculationEmployeeSource<TUnitOfWork> where TUnitOfWork : IMyDbContextUnitOfWork
    {
        public static ICalculationEmployee<TUnitOfWork> CalculationEmployeeFactory(TUnitOfWork unitOfWork)
        {
            var calculationE = new CalculationEmployeeBase<TUnitOfWork>(unitOfWork, ParametersCalculationSource.ParametersCalculationForEmployee);
            var calculationS = new CalculationEmployeeManager<TUnitOfWork>(unitOfWork, ParametersCalculationSource.ParametersCalculationForManager);
            var calculationM = new CalculationEmployeeSalesman<TUnitOfWork>(unitOfWork, ParametersCalculationSource.ParametersCalculationForSalesman);

            calculationE.SetSuccessor(calculationM);
            calculationM.SetSuccessor(calculationS);
            
            return calculationE;
        }
    }
}
