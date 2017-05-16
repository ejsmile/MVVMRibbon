using System.Data.Entity;
using MVVMRibbon.DataModels;
using SQLite.CodeFirst;

namespace MVVMRibbon.DataBase {
    [DbConfigurationType(typeof(MVVMRibbon.Common.DataModel.EntityFramework.MyDbSQLiteConfiguration))]
    public class MyDbContext : System.Data.Entity.DbContext {
        static MyDbContext() {
            Database.SetInitializer<MyDbContext>(null);
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var model = modelBuilder.Build(Database.Connection);
            ISqlGenerator sqlGenerator = new SqliteSqlGenerator();
            string sql = sqlGenerator.Generate(model.StoreModel);
            //IDatabaseCreator sqliteDatabaseCreator = new SqliteDatabaseCreator();
            //sqliteDatabaseCreator.Create(Database, model);
        }

        public DbSet<Employee> Employee { get; set; }
        public DbSet<Manager> Manager { get; set; }
        public DbSet<Salesman> Salesman { get; set; }
        public DbSet<Salary> Salary { get; set; }
    }
}