using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVVMRibbon.DataModels
{
    public class Manager : Employee
    {
        public Manager()
        {
            _isCanHead = true;
        }
    }
}
