using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Migrations.History;
using galibelle.Models;

namespace galibelle.DAL
{
    
        [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
        public class MyDbContext : DbContext
        {
            public MyDbContext() : base("name=MySQLMoviesConnection")
            {
                this.Configuration.ValidateOnSaveEnabled = false;
                Database.SetInitializer<MyDbContext>(new MyDBInitializer());
            }

            static MyDbContext()
            {
                DbConfiguration.SetConfiguration(new MySql.Data.Entity.MySqlEFConfiguration());
            }

            public DbSet<Colores> Colores { get; set; }
            public DbSet<Modelos> Modelos{ get; set; }
            public DbSet<Pedidos> Pedidos{ get; set; }
            public DbSet<Stock_straps> Stock_straps{ get; set; }
            public DbSet<Stock_suelas> Stock_suelas{ get; set; }
            public DbSet<Straps>Straps{ get; set; }
            public DbSet<Sucursales> Sucursales{ get; set; }
            public DbSet<Suelas> Suelas{ get; set; }
            public DbSet<Textura> Textura{ get; set; }
            public DbSet<Tipo_strap> Tipo_strao{ get; set; }
            public DbSet<Usuarios> Usuarios{ get; set; }
            public DbSet<Vendido> Vendido{ get; set; }
            public DbSet<Ventas> Ventas{ get; set; }


            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);
                modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //modelBuilder.Entity<HistoryRow>().Property(h => h.MigrationId).HasMaxLength(100).IsRequired();
               //modelBuilder.Entity<HistoryRow>().Property(h => h.ContextKey).HasMaxLength(200).IsRequired();
            }

        }
    }
