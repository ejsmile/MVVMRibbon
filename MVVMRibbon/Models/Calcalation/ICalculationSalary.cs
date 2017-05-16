using System;
using MVVMRibbon.DataModels;
using MVVMRibbon.Models.MyDbContextDataModel;

namespace MVVMRibbon.Models.MyDbContextDataModel
{
    public interface ICalculationSalary<TUnitOfWork> where TUnitOfWork : IMyDbContextUnitOfWork
    {
        Tuple<double, string> Calculation(Salary entity);
    }
}
