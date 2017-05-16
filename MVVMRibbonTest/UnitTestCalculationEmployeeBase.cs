using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MVVMRibbon.DataModels;
using MVVMRibbon.Models.Calcalation;
using MVVMRibbon.Models.MyDbContextDataModel;

namespace MVVMRibbonTest
{
    [TestClass]
    public class UnitTestCalculationEmployeeBase
    {
        [TestMethod]
        public void TestMethodEmployeeBaseCalculationSuccessor()
        {
            const double delta = 0.00001;
            const double baseRate = 100;
            var dateTest = new DateTime(2017, 01, 01);

            var unitOfWorkMosk = new Mock<IMyDbContextUnitOfWork>();
            var baseEmployeer = new CalculationEmployeeBase<IMyDbContextUnitOfWork>(unitOfWorkMosk.Object, ParametersCalculationSource.ParametersCalculationForEmployee);
            var employee = new Employee {BaseRate = baseRate, DateOfEmployment = dateTest };
            Assert.AreEqual(baseRate, baseEmployeer.Calculation(employee, dateTest), delta);
            Assert.AreEqual(baseRate * 1.03, baseEmployeer.Calculation(employee, dateTest.AddYears(1)), delta);
            Assert.AreEqual(baseRate * 1.30, baseEmployeer.Calculation(employee, dateTest.AddYears(10)), delta);
            Assert.AreEqual(baseRate * 1.30, baseEmployeer.Calculation(employee, dateTest.AddYears(15)), delta);
        }
    }
}
