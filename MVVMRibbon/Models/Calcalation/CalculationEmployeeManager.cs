using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMRibbon.DataModels;
using MVVMRibbon.Models.MyDbContextDataModel;

namespace MVVMRibbon.Models.Calcalation
{
    public class CalculationEmployeeManager<TUnitOfWork> : CalculationEmployeeAbstract<TUnitOfWork> where TUnitOfWork : IMyDbContextUnitOfWork
    {
        public CalculationEmployeeManager(TUnitOfWork unitOfWork, IParametersCalculation parametersCalculation) : base(unitOfWork, parametersCalculation) { }

        protected override Type SuccessorType()
        {
            return typeof(Manager);
        }

        protected override double CalculationSuccessor(Employee entity, DateTime period)
        {
            return GetBonusByWorkExperience(period, entity.DateOfEmployment, entity.BaseRate, ParametersCalculation.BonusPersentByWorkExperienceByYear, ParametersCalculation.MaxBonusPersentByWorkExperience) 
                + GetWorkers(entity).Sum(work => (Head.Calculation(work, period) * ParametersCalculation.BonusPersentForWorkers) / 100);
        }
    }
}
