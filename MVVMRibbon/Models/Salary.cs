using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace MVVMRibbon.DataModels
{
    public class Salary
    {

        [Key, Display(AutoGenerateField = false)]
        public long ID { get; set; }

        [Required, DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        public double Money { get; set; }

        [Display(AutoGenerateField = false)]
        public long EmployeeID { get; set; }
        [Display(Name = "Employee")]
        public virtual Employee Employee { get; set; }

        public Salary()
        {
            Date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        }

        public override string ToString()
        {
            return Date.ToString("dd/M/yyyy", CultureInfo.InvariantCulture) + " " + (Employee == null? "n/d" : Employee.Name);
        }
    }
}
