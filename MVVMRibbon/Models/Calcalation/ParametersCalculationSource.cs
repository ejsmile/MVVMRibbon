using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMRibbon.DataModels;

namespace MVVMRibbon.Models.Calcalation
{
    public static class ParametersCalculationSource
    {
        public static IParametersCalculation ParametersCalculationForEmployee => new ParametersCalculation(3, 30, 0);
        public static IParametersCalculation ParametersCalculationForManager => new ParametersCalculation(5, 40, 0.5);
        public static IParametersCalculation ParametersCalculationForSalesman => new ParametersCalculation(1, 35, 0.3);        
    }

    public class ParametersCalculation : IParametersCalculation
    {
        public ParametersCalculation(double bonusPersentByWorkExperienceByYear, double maxBonusPersentByWorkExperience, double bonusPersentForWorkers)
        {

            BonusPersentByWorkExperienceByYear = bonusPersentByWorkExperienceByYear;
            MaxBonusPersentByWorkExperience = maxBonusPersentByWorkExperience;
            BonusPersentForWorkers = bonusPersentForWorkers;
        }
        public double MaxBonusPersentByWorkExperience { get; }
        public double BonusPersentByWorkExperienceByYear { get; }
        public double BonusPersentForWorkers { get; }
    }

    public interface IParametersCalculation
    {
        double MaxBonusPersentByWorkExperience { get; }
        double BonusPersentByWorkExperienceByYear { get; }
        double BonusPersentForWorkers { get; }
    }
}
