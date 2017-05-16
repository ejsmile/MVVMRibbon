using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Moq.Protected;
using MVVMRibbon.DataModels;
using MVVMRibbon.Models.Calcalation;
using MVVMRibbon.Models.MyDbContextDataModel;

namespace MVVMRibbonTest
{
    [TestClass]
    public class UnitTestCalculationEmployeeManager
    {

        private CalculationEmployeeManager<IMyDbContextUnitOfWork> getCalculation(Employee employee, IEnumerable<Employee> workers)
        {
            var unitOfWorkMosk = new Mock<IMyDbContextUnitOfWork>();
            var mock = new Mock<CalculationEmployeeManager<IMyDbContextUnitOfWork>>(unitOfWorkMosk.Object, ParametersCalculationSource.ParametersCalculationForManager)
            {
                CallBase = true
            };
            if (workers != null)
            {
                mock.Protected()
                    .Setup<IEnumerable<Employee>>("GetWorkers", employee)
                    .Returns(workers.AsEnumerable());
            }
            return mock.Object;
        }

        internal class CalculationEmployeeManagerTest<TUnitOfWork> : CalculationEmployeeManager<TUnitOfWork>
            where TUnitOfWork : IMyDbContextUnitOfWork
        {
            public CalculationEmployeeManagerTest(TUnitOfWork unitOfWork, IParametersCalculation parametersCalculation) : base(unitOfWork, parametersCalculation) { }
           
            public Type ExposeSuccessorType()
            {
                return SuccessorType();
            }
        }

        [TestMethod]
        public void TestManagerMethodSuccessorType()
        {
            var unitOfWorkMosk = new Mock<IMyDbContextUnitOfWork>();
            var baseManager = new CalculationEmployeeManagerTest<IMyDbContextUnitOfWork>(unitOfWorkMosk.Object, null);
            Assert.AreEqual(typeof(Manager), baseManager.ExposeSuccessorType());
        }

        [TestMethod]
        public void TestManagerMethodManagerCalculation()
        {
            const double delta = 0.00001;
            const double baseRate = 100;
            var dateTest = new DateTime(2017, 01, 01);

            
            var employee = new Manager { BaseRate = baseRate, DateOfEmployment = dateTest };

            var baseManager = getCalculation(employee, new LinkedList<Employee>());

            Assert.AreEqual(baseRate, baseManager.Calculation(employee, dateTest), delta);
            Assert.AreEqual(baseRate * 1.05, baseManager.Calculation(employee, dateTest.AddYears(1)), delta);
            Assert.AreEqual(baseRate * 1.40, baseManager.Calculation(employee, dateTest.AddYears(8)), delta);
            Assert.AreEqual(baseRate * 1.40, baseManager.Calculation(employee, dateTest.AddYears(15)), delta);
        }

        [TestMethod]
        public void TestManagerMethodManagerCalculationWorkers()
        {
            const double delta = 0.00001;
            const double baseRate = 1000;
            var dateTest = new DateTime(2017, 01, 01);
            var workers = new LinkedList<Employee>();
            workers.AddLast(new Employee {ID = 1, BaseRate = baseRate, DateOfEmployment = dateTest});
            workers.AddLast(new Employee {ID = 2, BaseRate = baseRate, DateOfEmployment = dateTest});
           
            var employee = new Manager { ID = 3, BaseRate = baseRate, DateOfEmployment = dateTest };

            var baseManager = getCalculation(employee, workers);
            baseManager.SetSuccessor(new CalculationEmployeeBase<IMyDbContextUnitOfWork>((new Mock<IMyDbContextUnitOfWork>()).Object, ParametersCalculationSource.ParametersCalculationForEmployee));

            Assert.AreEqual(baseRate + baseRate * 2 * 0.005, baseManager.Calculation(employee, dateTest), delta);
            Assert.AreEqual(baseRate * 1.05 + (baseRate * 2 * 1.03) * 0.005, baseManager.Calculation(employee, dateTest.AddYears(1)), delta);
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException), "Test not found calculation method")]
        public void TestManagerMethodManagerCalculationExpectedException()
        {
            var name = "Test";
            const double baseRate = 100;
            var dateTest = new DateTime(2017, 01, 01);

            var workers = new LinkedList<Employee>();
            workers.AddLast(new Employee { ID = 1, BaseRate = baseRate, DateOfEmployment = dateTest });
            workers.AddLast(new Employee { ID = 2, BaseRate = baseRate, DateOfEmployment = dateTest });

            var employee = new Employee { Name = name, BaseRate = baseRate, DateOfEmployment = dateTest };

            var baseManager = getCalculation(employee, workers);
           
            baseManager.Calculation(employee, dateTest);
        }
    }
}
