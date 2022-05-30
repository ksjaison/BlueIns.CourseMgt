namespace BlueIns.CourseMgt.DataAccessLayer.Context
{
    using BlueIns.CourseMgt.DataAccessLayer.Model;
    using BlueIns.CourseMgt.DomainModel;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.InMemory.ValueGeneration.Internal;

    /// <summary>
    /// Master DB context class.
    /// </summary>
    public class MasterContext : DbContext, IMasterContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MasterContext"/> class.
        /// </summary>
        public MasterContext()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MasterContext"/> class.
        /// </summary>
        /// <param name="options">Base option parameter.</param>
        public MasterContext(DbContextOptions<MasterContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or sets Student details.
        /// </summary>
        public DbSet<StudentDetailsDto> StudentDetails { get; set; }

        public DbSet<CourseDetailsDto> CourseDetails { get; set; }

        public DbSet<RegDetailsDto> RegDetails { get; set; }


        /// <summary>
        /// On config method.
        /// </summary>
        /// <param name="optionsBuilder">DB Context option builder.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=StudentCourseRegSystem;Trusted_Connection=True;MultipleActiveResultSets=true";
            optionsBuilder.UseSqlServer(connectionString);
        }

        /// <summary>
        /// OnModelCreating.
        /// </summary>
        /// <param name="modelBuilder">Model builder parameter.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
