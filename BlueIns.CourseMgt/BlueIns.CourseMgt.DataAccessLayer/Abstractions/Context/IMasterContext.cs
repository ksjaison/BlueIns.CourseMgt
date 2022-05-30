namespace BlueIns.CourseMgt.DataAccessLayer
{
    using BlueIns.CourseMgt.DataAccessLayer.Model;
    using BlueIns.CourseMgt.DomainModel;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// DB Context class interface.
    /// </summary>
    public interface IMasterContext
    {
        /// <summary>
        /// Gets or sets Student Details.
        /// </summary>
        DbSet<StudentDetailsDto> StudentDetails { get; set; }

        /// <summary>
        /// Gets or sets Course Details.
        /// </summary>
        DbSet<CourseDetailsDto> CourseDetails { get; set; }

        /// <summary>
        /// Gets or sets Reg Details.
        /// </summary>
        DbSet<RegDetailsDto> RegDetails { get; set; }
    }
}
