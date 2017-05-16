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
using DevExpress.XtraBars;

namespace MVVMRibbon.Models.MyDbContextDataModel {
    /// <summary>
    /// A MyDbContextUnitOfWork instance that represents the run-time implementation of the IMyDbContextUnitOfWork interface.
    /// </summary>
    public class MyDbContextUnitOfWork : DbUnitOfWork<MyDbContext>, IMyDbContextUnitOfWork {

        public MyDbContextUnitOfWork(Func<MyDbContext> contextFactory)
            : base(contextFactory) {
        }

        IRepository<Employee, long> IMyDbContextUnitOfWork.Employees
        {
            get { return GetRepository(x => x.Set<Employee>(), x => x.ID); }
        }

        IRepository<Manager, long> IMyDbContextUnitOfWork.Manageres
        {
            get { return GetRepository(x => x.Set<Manager>(), x => x.ID); }
        }

        IRepository<Salesman, long> IMyDbContextUnitOfWork.Salesmanes
        {
            get { return GetRepository(x => x.Set<Salesman>(), x => x.ID); }
        }
        IRepository<Salary, long> IMyDbContextUnitOfWork.Salaries
        {
            get { return GetRepository(x => x.Set<Salary>(), x => x.ID); }
        }

        BarHeaderItem bhi = new BarHeaderItem() { Width = 100 };
    }
}
