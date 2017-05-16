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
using DevExpress.Mvvm;
using System.Collections;
using System.ComponentModel;
using DevExpress.Data.Linq;
using DevExpress.Data.Linq.Helpers;
using DevExpress.Data.Async.Helpers;

namespace MVVMRibbon.Models.MyDbContextDataModel {
    /// <summary>
    /// Provides methods to obtain the relevant IUnitOfWorkFactory.
    /// </summary>
    public static class UnitOfWorkSource {

        /// <summary>
        /// Returns the IUnitOfWorkFactory implementation.
        /// </summary>
        public static IUnitOfWorkFactory<IMyDbContextUnitOfWork> GetUnitOfWorkFactory() {
            return new DbUnitOfWorkFactory<IMyDbContextUnitOfWork>(() => new MyDbContextUnitOfWork(() => new MyDbContext()));
        }
    }
}