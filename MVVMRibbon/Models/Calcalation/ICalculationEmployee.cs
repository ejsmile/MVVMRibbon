using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMRibbon.DataModels;
using MVVMRibbon.Models.MyDbContextDataModel;

namespace MVVMRibbon.Models.Calcalation
{
    public interface ICalculationEmployee<TUnitOfWork> where TUnitOfWork : IMyDbContextUnitOfWork
    {
        IParametersCalculation ParametersCalculation { get; }
        ICalculationEmployee<TUnitOfWork> Head { get; set; }

        double Calculation(Employee entity, DateTime period);
        void SetSuccessor(ICalculationEmployee<TUnitOfWork> successor);
        ICalculationEmployee<TUnitOfWork> GetSuccessor();

    }
}
