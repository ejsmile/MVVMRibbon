using System;
using System.Linq;
using System.Data;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Collections.Generic;
using MVVMRibbon.Common.Utils;
using MVVMRibbon.Common.DataModel;
using MVVMRibbon.Common.DataModel.EntityFramework;
using MVVMRibbon.DataBase;
using MVVMRibbon.DataModels;

namespace MVVMRibbon.Models.MyDbContextDataModel {
    /// <summary>
    /// IMyDbContextUnitOfWork extends the IUnitOfWork interface with repositories representing specific entities.
    /// </summary>
    public interface IMyDbContextUnitOfWork : IUnitOfWork {
       
        /// <summary>
        /// The Employee entities repository.
        /// </summary>
        IRepository<Employee, long> Employees { get; }

        /// <summary>
        /// The Manageres entities repository.
        /// </summary>
        IRepository<Manager, long> Manageres { get; }

        /// <summary>
        /// The Salesmanes entities repository.
        /// </summary>
        IRepository<Salesman, long> Salesmanes { get; }

        /// <summary>
        /// The repository entities repository.
        /// </summary>
        IRepository<Salary, long> Salaries { get; }
    }
}
