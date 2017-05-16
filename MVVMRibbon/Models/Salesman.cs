using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVVMRibbon.DataModels
{
    public class Salesman: Employee
    {
        public Salesman()
        {
            _isCanHead = true;
        }
    }
}
