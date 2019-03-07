namespace AutoParking.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DB : DbContext
    {
        public DB(string connectionString)
            : base(string.Format("name={0}",connectionString))
        {
        }

        public virtual DbSet<BienSoDen> BienSoDens { get; set; }
        public virtual DbSet<BlackBox> BlackBoxes { get; set; }
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Computer> Computers { get; set; }
        public virtual DbSet<Functional> Functionals { get; set; }
        public virtual DbSet<Log> Logs { get; set; }
        public virtual DbSet<Part> Parts { get; set; }
        public virtual DbSet<SetCard> SetCards { get; set; }
        public virtual DbSet<SmartCard> SmartCards { get; set; }
        public virtual DbSet<TicketLog> TicketLogs { get; set; }
        public virtual DbSet<TicketMonth> TicketMonths { get; set; }
        public virtual DbSet<UserCar> UserCars { get; set; }
        public virtual DbSet<WorkAssign> WorkAssigns { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Part>()
                .Property(e => e.Sign)
                .IsFixedLength();
        }
    }
}
