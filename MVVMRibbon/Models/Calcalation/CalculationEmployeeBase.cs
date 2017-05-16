using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMRibbon.DataModels;
using MVVMRibbon.Models.MyDbContextDataModel;

namespace MVVMRibbon.Models.Calcalation
{
    public class CalculationEmployeeBase<TUnitOfWork> : CalculationEmployeeAbstract<TUnitOfWork> where TUnitOfWork : IMyDbContextUnitOfWork
    {
        public CalculationEmployeeBase(TUnitOfWork unitOfWork, IParametersCalculation parametersCalculation) : base(unitOfWork, parametersCalculation) { }

        protected override Type SuccessorType()
        {
            return typeof(Employee);
        }

        protected override double CalculationSuccessor(Employee entity, DateTime period)
        {
            return GetBonusByWorkExperience(period, entity.DateOfEmployment, entity.BaseRate, ParametersCalculation.BonusPersentByWorkExperienceByYear, ParametersCalculation.MaxBonusPersentByWorkExperience);
        }

        protected override IEnumerable<Employee> GetWorkers(Employee entry)
        {
            return new LinkedList<Employee>();
        }
    }
}
