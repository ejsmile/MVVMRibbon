using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVVMRibbon.DataModels
{
    public class Employee
    {
        protected bool _isCanHead;

        [Key, Display(AutoGenerateField = false)]
        public long ID { get; set; }

        [Required, StringLength(30, MinimumLength = 5)]
        public string Name { get; set; }

        [Required, DataType(DataType.Date)]
        [Display(Name = "Date of employment ")]
        public DateTime DateOfEmployment { get; set; }

        [Required]
        public double BaseRate { get; set; }

        [Display(AutoGenerateField = false)]
        public long? HeadID { get; set; }

        [Display(Name = "Boss")]
        [ForeignKey("HeadID")]
        public virtual Employee Head { get; set; }

        [DefaultValue("false"), Display(AutoGenerateField = false)]
        public virtual bool IsCanHead {
            get { return _isCanHead; }
            set { _isCanHead = value; } 
        }

        public Employee()
        {
            _isCanHead = false;
            DateOfEmployment = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        }

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            var employeeObj = obj as Employee;
            return employeeObj != null && ID.Equals(employeeObj.ID);
        }

        public override int GetHashCode()
        {
            return this.ID.GetHashCode();
        }
    }
}
