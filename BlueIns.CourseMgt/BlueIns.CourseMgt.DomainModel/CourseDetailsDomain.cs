namespace BlueIns.CourseMgt.DomainModel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Domain class for setting and getting Task items.
    /// </summary>
    public class CourseDetailsDomain : Base
    {
        /// <summary>
        /// Gets or Sets Task Id.
        /// </summary>
        public int CourseId { get; set; }

        /// <summary>
        /// Gets or Sets FirstName.
        /// </summary>
        public string CourseName { get; set; }

        /// <summary>
        /// Gets or Sets SurName.
        /// </summary>
        public string TeacherName { get; set; }

        /// <summary>
        /// Gets or Sets SurName.
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Gets or Sets SurName.
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Gets or Sets NoofSeats.
        /// </summary>
        public int NoofSeats { get; set; }

        /// <summary>
        /// Gets or Sets SurName.
        /// </summary>
        public DateTime LastUpdatedDate { get; set; }

    }
}
