using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MVVMRibbon.DataModels;
using MVVMRibbon.Models.Calcalation;
using MVVMRibbon.Models.MyDbContextDataModel;

namespace MVVMRibbonTest
{
    [TestClass]
    public class UnitTestCalculationEmployeeAbstract
    {
        private class CalculationEmployeeAbstractTest<TUnitOfWork> : CalculationEmployeeAbstract<TUnitOfWork>
            where TUnitOfWork : IMyDbContextUnitOfWork
        {
            public CalculationEmployeeAbstractTest(TUnitOfWork unitOfWork, IParametersCalculation parametersCalculation) : base(unitOfWork, parametersCalculation)
            {
            }

            public static int ExposeGetYearWorkExperience(DateTime period, DateTime dateOfEmployment)
            {
                return GetYearWorkExperience(period, dateOfEmployment);
            }

            public static double ExposeGetBonusByWorkExperience(DateTime period, DateTime dateOfEmployment,
                double baseRate, double bonusByYears, double maxBonusByYears)
            {
                return GetBonusByWorkExperience(period, dateOfEmployment, baseRate, bonusByYears, maxBonusByYears);
            }

            public static Type ExposeGetTypeEntity(Employee entity)
            {
                return GetTypeEntity(entity);
            }
        }

        [TestMethod]
        public void TestMethodEmployeeAbstractExposeGetYearWorkExperience()
        {
            Assert.AreEqual(0,
                CalculationEmployeeAbstractTest<IMyDbContextUnitOfWork>.ExposeGetYearWorkExperience(
                    new DateTime(2017, 01, 02), new DateTime(2017, 01, 02)));
            Assert.AreEqual(0,
                CalculationEmployeeAbstractTest<IMyDbContextUnitOfWork>.ExposeGetYearWorkExperience(
                    new DateTime(2017, 10, 02), new DateTime(2017, 01, 02)));
            Assert.AreEqual(0,
                CalculationEmployeeAbstractTest<IMyDbContextUnitOfWork>.ExposeGetYearWorkExperience(
                    new DateTime(2017, 01, 12), new DateTime(2017, 01, 02)));
            Assert.AreEqual(13,
                CalculationEmployeeAbstractTest<IMyDbContextUnitOfWork>.ExposeGetYearWorkExperience(
                    new DateTime(2030, 01, 02), new DateTime(2017, 01, 02)));
            Assert.AreEqual(12,
                CalculationEmployeeAbstractTest<IMyDbContextUnitOfWork>.ExposeGetYearWorkExperience(
                    new DateTime(2030, 01, 01), new DateTime(2017, 01, 02)));
        }

        [TestMethod]
        public void TestMethodEmployeeAbstractExposeGetBonusByWorkExperience()
        {
            const double delta = 0.00001;
            const double baseRate = 100;
            const int bonusByYears = 2;
            const int maxBonusByYears = 10;
            var testYear = new DateTime(2017, 01, 01);

            Assert.AreEqual(baseRate,
                CalculationEmployeeAbstractTest<IMyDbContextUnitOfWork>.ExposeGetBonusByWorkExperience(
                    testYear, testYear, baseRate, bonusByYears, maxBonusByYears), delta);

            Assert.AreEqual(baseRate*1.02,
                CalculationEmployeeAbstractTest<IMyDbContextUnitOfWork>.ExposeGetBonusByWorkExperience(
                    testYear.AddYears(1), testYear, baseRate, bonusByYears, maxBonusByYears), delta);

            Assert.AreEqual(baseRate*1.1,
                CalculationEmployeeAbstractTest<IMyDbContextUnitOfWork>.ExposeGetBonusByWorkExperience(
                    testYear.AddYears(10), testYear, baseRate, bonusByYears, maxBonusByYears), delta);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentException), "Date calculation before date Of employment")]
        public void TestMethodEmployeeAbstractExposeGetBonusByWorkExperienceExpectedException()
        {
            const double baseRate = 100;
            const int bonusByYears = 2;
            const int maxBonusByYears = 10;
            var testYear = new DateTime(2017, 01, 01);

            CalculationEmployeeAbstractTest<IMyDbContextUnitOfWork>.ExposeGetBonusByWorkExperience(
                testYear.AddYears(-1), testYear, baseRate, bonusByYears, maxBonusByYears);
        }

        [TestMethod]
        public void TestMethodEmployeeAbstractExposeGetTypeEntity()
        {
            Employee employee = new Employee();
            Assert.AreEqual(typeof (Employee),
                CalculationEmployeeAbstractTest<IMyDbContextUnitOfWork>.ExposeGetTypeEntity(employee));
            Employee manager = new Manager();
            Assert.AreEqual(typeof (Manager),
                CalculationEmployeeAbstractTest<IMyDbContextUnitOfWork>.ExposeGetTypeEntity(manager));
            Employee Salesman = new Salesman();
            Assert.AreEqual(typeof (Salesman),
                CalculationEmployeeAbstractTest<IMyDbContextUnitOfWork>.ExposeGetTypeEntity(Salesman));
        }

        [TestMethod]
        public void TestMethodEmployeeAbstractSetSuccessor()
        {
            var unitOfWorkMosk = new Mock<IMyDbContextUnitOfWork>();
            var typeMethod = new CalculationEmployeeAbstractTest<IMyDbContextUnitOfWork>(unitOfWorkMosk.Object, null);
            var typeMethodSetSuccessor = new CalculationEmployeeAbstractTest<IMyDbContextUnitOfWork>(unitOfWorkMosk.Object, null);
            var typeMethodSetSuccessorSecond = new CalculationEmployeeAbstractTest<IMyDbContextUnitOfWork>(unitOfWorkMosk.Object, null);
            typeMethod.SetSuccessor(typeMethodSetSuccessor);
            typeMethodSetSuccessor.SetSuccessor(typeMethodSetSuccessorSecond);
            Assert.AreEqual(typeMethod.Head, typeMethodSetSuccessor.Head);
            Assert.AreEqual(typeMethod.GetSuccessor(), typeMethodSetSuccessor);
            Assert.AreEqual(typeMethod.Head, typeMethodSetSuccessorSecond.Head);
            Assert.AreEqual(typeMethodSetSuccessor.GetSuccessor(), typeMethodSetSuccessorSecond);
        }

    }
}
