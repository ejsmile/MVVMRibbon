using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMRibbon.DataModels;
using MVVMRibbon.Models.MyDbContextDataModel;

namespace MVVMRibbon.Models.Calcalation
{
    public class CalculationEmployeeSalesman<TUnitOfWork> : CalculationEmployeeAbstract<TUnitOfWork> where TUnitOfWork : IMyDbContextUnitOfWork
    {
        public CalculationEmployeeSalesman(TUnitOfWork unitOfWork, IParametersCalculation parametersCalculation) : base(unitOfWork, parametersCalculation) { }

        protected override Type SuccessorType()
        {
            return typeof(Salesman);
        }

        protected override double CalculationSuccessor(Employee entity, DateTime period)
        {
            var answer = GetBonusByWorkExperience(period, entity.DateOfEmployment, entity.BaseRate,
               ParametersCalculation.BonusPersentByWorkExperienceByYear, ParametersCalculation.MaxBonusPersentByWorkExperience);
            //в стак собирем всех потомков
            var stack = new Stack<Employee>(GetWorkers(entity));
            var processed = new HashSet<Employee>();
            while (stack.Any())
            {
                var worker = stack.Pop();
                if (processed.Contains(worker))
                    continue;
                answer += (Head.Calculation(worker, period) * ParametersCalculation.BonusPersentForWorkers) / 100;
                processed.Add(worker);
                GetWorkers(worker).ToList().ForEach(stack.Push);
            }

            return answer;
        }
    }
}
