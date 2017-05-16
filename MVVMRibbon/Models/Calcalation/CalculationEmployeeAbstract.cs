using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMRibbon.DataModels;
using MVVMRibbon.Models.MyDbContextDataModel;

namespace MVVMRibbon.Models.Calcalation
{
    public class CalculationEmployeeAbstract<TUnitOfWork>: ICalculationEmployee<TUnitOfWork> where TUnitOfWork : IMyDbContextUnitOfWork
    {
        private readonly TUnitOfWork _unitOfWork;
        private ICalculationEmployee<TUnitOfWork> _successor;
        
        public CalculationEmployeeAbstract(TUnitOfWork unitOfWork, IParametersCalculation parametersCalculation)
        {
            _unitOfWork = unitOfWork;
            Head = this;
            ParametersCalculation = parametersCalculation;
        }
        public IParametersCalculation ParametersCalculation { get; }

        public ICalculationEmployee<TUnitOfWork> Head { get; set; }

        public double Calculation(Employee entity, DateTime period)
        {
            if (GetTypeEntity(entity) == SuccessorType())
            {
                return CalculationSuccessor(entity, period);
            }
            if (_successor != null)
            {
                return _successor.Calculation(entity, period);
            }
            throw new NotImplementedException(entity.Name + " not found calculation method");
        }

        public void SetSuccessor(ICalculationEmployee<TUnitOfWork> successor)
        {
            _successor = successor;
            successor.Head = Head;
        }

        public ICalculationEmployee<TUnitOfWork> GetSuccessor()
        {
            return _successor;
        }

        protected static double GetBonusByWorkExperience(DateTime period, DateTime dateOfEmployment, double baseRate, double bonusByYears, double maxBonusByYears)
        {
            var startMonthDateOfEmployment = new DateTime(dateOfEmployment.Year, dateOfEmployment.Month, 1);
            if (startMonthDateOfEmployment > period)
                throw new ArgumentException("Date calculation before date Of employment");
            //стаж за выслугу лет
            var bonusExperience = GetYearWorkExperience(period, dateOfEmployment) * bonusByYears;
            //не больше максимального бонуса
            bonusExperience = bonusExperience > maxBonusByYears ? maxBonusByYears : bonusExperience;
            //надбавка за стаж
            var answer = baseRate + (bonusExperience * baseRate / 100);
            return answer;
        }

        protected static Type GetTypeEntity(Employee entity)
        {
            return ObjectContext.GetObjectType(entity.GetType());
        }
        protected static int GetYearWorkExperience(DateTime period, DateTime dateOfEmployment)
        {
            var years = period.Year - dateOfEmployment.Year;
            if (dateOfEmployment > period.AddYears(-years))
                years--;
            return years;
        }
        protected virtual double CalculationSuccessor(Employee entity, DateTime period)
        {
            throw new NotImplementedException(nameof(SuccessorType));
        }

        protected virtual IEnumerable<Employee> GetWorkers(Employee entry)
        {
            //Надо расширить IRepository на работу с внешними ключами
            return _unitOfWork.Employees.Where(w => w.HeadID == entry.ID);
        }

        protected virtual Type SuccessorType()
        {
            throw new NotImplementedException(nameof(SuccessorType));
        }
    }
}
