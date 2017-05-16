using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Globalization;
//using System.Data.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMRibbon.Common;
using MVVMRibbon.Common.DataModel;
using MVVMRibbon.DataModels;
using MVVMRibbon.Models.MyDbContextDataModel;

namespace MVVMRibbon.Models.Calcalation
{
    public class CalculationSalary<TUnitOfWork> : ICalculationSalary<TUnitOfWork> where TUnitOfWork : IMyDbContextUnitOfWork
    {
        private readonly TUnitOfWork _unitOfWork;
        protected ICalculationEmployee<TUnitOfWork> Calculations;

        public CalculationSalary(TUnitOfWork unitOfWork, ICalculationEmployee<TUnitOfWork> сalculationSuccessores)
        {
            _unitOfWork = unitOfWork;
            Calculations = сalculationSuccessores;
        }

        protected virtual void CheckCalculationSalary(Employee employee, Salary salary)
        {
            //var proccessed = _unitOfWork.Salaries.Where(s => s.EmployeeID == employee.ID && s.Date == salary.Date);
            if (_unitOfWork.Salaries.Any(s => s.EmployeeID == employee.ID && s.Date == salary.Date))
                throw new Exception("Emloyee " + employee + " of " + salary.Date.ToString("dd/M/yyyy", CultureInfo.InvariantCulture) + " already calculation");
        }

        public Tuple<double, string> Calculation(Salary entity)
        {
            Tuple<double, string> answer;

            var employee = _unitOfWork.Employees.Find(entity.EmployeeID);
            try
            {
                CheckCalculationSalary(employee, entity);
                answer = new Tuple<double, string>(Calculations.Calculation(employee, entity.Date), "");
            }
            catch (Exception ex)
            {

                answer = new Tuple<double, string>(-1, ex.Message);
            }
            return answer;            
        }
    }
}
