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
    public class UnitTestCalculationEmployeeSalesman
    {
        internal class CalculationEmployeeSalesmanTest<TUnitOfWork> : CalculationEmployeeSalesman<TUnitOfWork>
            where TUnitOfWork : IMyDbContextUnitOfWork
        {
            public CalculationEmployeeSalesmanTest(TUnitOfWork unitOfWork, IParametersCalculation parametersCalculation) : base(unitOfWork, parametersCalculation) { }

            public Type ExposeSuccessorType()
            {
                return SuccessorType();
            }
        }

        [TestMethod]
        public void TestMethodSalesmanSuccessorType()
        {
            var unitOfWorkMosk = new Mock<IMyDbContextUnitOfWork>();
            var baseSalesman = new CalculationEmployeeSalesmanTest<IMyDbContextUnitOfWork>(unitOfWorkMosk.Object, null);
            Assert.AreEqual(typeof(Salesman), baseSalesman.ExposeSuccessorType());
        }

        [TestMethod]
        public void TestMethodSalesmanCalculationSuccessor()
        {
            const double delta = 0.00001;
            const double baseRate = 100;
            var dateTest = new DateTime(2017, 01, 01);
            var employee = new Salesman { BaseRate = baseRate, DateOfEmployment = dateTest };

            var unitOfWorkMosk = new Mock<IMyDbContextUnitOfWork>();
            var mock = new Mock<CalculationEmployeeSalesman<IMyDbContextUnitOfWork>>(unitOfWorkMosk.Object, ParametersCalculationSource.ParametersCalculationForSalesman)
            {
                CallBase = true
            };
            mock.Protected()
                    .Setup<IEnumerable<Employee>>("GetWorkers", employee)
                    .Returns((new LinkedList<Employee>()).AsEnumerable());
           
            var baseSalesman = mock.Object;

            Assert.AreEqual(baseRate, baseSalesman.Calculation(employee, dateTest), delta);
            Assert.AreEqual(baseRate * 1.01, baseSalesman.Calculation(employee, dateTest.AddYears(1)), delta);
            Assert.AreEqual(baseRate * 1.35, baseSalesman.Calculation(employee, dateTest.AddYears(35)), delta);
            Assert.AreEqual(baseRate * 1.35, baseSalesman.Calculation(employee, dateTest.AddYears(40)), delta);
        }

        [TestMethod]
        public void TestMethodSalesmanCalculationSuccessorWorkers()
        {
            const double delta = 0.00001;
            const double baseRate = 1000;
            var dateTest = new DateTime(2017, 01, 01);

            var unitOfWorkMosk = new Mock<IMyDbContextUnitOfWork>();

            var workers = new List<Employee>
            {
                new Employee {ID = 1, BaseRate = baseRate, DateOfEmployment = dateTest},
                new Employee {ID = 2, BaseRate = baseRate, DateOfEmployment = dateTest}
            };

            var manager = new Manager {ID = 3, BaseRate = baseRate, DateOfEmployment = dateTest };

            var workersSalesmans = new List<Employee>
            {
                manager,
                new Employee {ID = 4, BaseRate = baseRate, DateOfEmployment = dateTest}
            };

            var employee = new Salesman { BaseRate = baseRate, DateOfEmployment = dateTest };

            var mock = new Mock<CalculationEmployeeSalesman<IMyDbContextUnitOfWork>>(unitOfWorkMosk.Object, ParametersCalculationSource.ParametersCalculationForSalesman)
            {
                CallBase = true
            };
            //salesman
            mock.Protected()
                .Setup<IEnumerable<Employee>>("GetWorkers", employee)
                .Returns(workersSalesmans.AsEnumerable());

            //manager
            mock.Protected()
                .Setup<IEnumerable<Employee>>("GetWorkers", workersSalesmans[0])
                .Returns(workers.AsEnumerable());

            //employers
            mock.Protected()
                .Setup<IEnumerable<Employee>>("GetWorkers", workersSalesmans[1])
                .Returns(new LinkedList<Employee>());

            mock.Protected()
                .Setup<IEnumerable<Employee>>("GetWorkers", workers[0])
                .Returns(workers.AsEnumerable());

            mock.Protected()
                .Setup<IEnumerable<Employee>>("GetWorkers", workers[1])
                .Returns(workers.AsEnumerable());

            var mockManager = new Mock<CalculationEmployeeManager<IMyDbContextUnitOfWork>>(unitOfWorkMosk.Object, ParametersCalculationSource.ParametersCalculationForManager)
            {
                CallBase = true
            };

            //manager
            mockManager.Protected()
                .Setup<IEnumerable<Employee>>("GetWorkers", manager)
                .Returns(workers.AsEnumerable());

            var baseEmployeer = new CalculationEmployeeBase<IMyDbContextUnitOfWork>(unitOfWorkMosk.Object, ParametersCalculationSource.ParametersCalculationForEmployee);
            var baseManager = mockManager.Object;
            var baseSalesman = mock.Object;

            baseSalesman.SetSuccessor(baseManager);
            baseManager.SetSuccessor(baseEmployeer);

            
            Assert.AreEqual(baseRate + (baseRate * 0.003) * 3 + (baseRate + (0.005 * baseRate) * 2) * 0.003, 
                baseSalesman.Calculation(employee, dateTest), delta);
        }
    }
}
