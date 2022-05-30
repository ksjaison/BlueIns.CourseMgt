namespace BlueIns.CourseMgt.DomainModel
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Domain class for setting and getting Task items.
    /// </summary>
    public class RegDetailsDomain : Base
    {
        /// <summary>
        /// Gets or Sets Reg Id.
        /// </summary>
        public int RegId { get; set; }

        /// <summary>
        /// Gets or Sets FirstName.
        /// </summary>
        public StudentDetailsDomain Student { get; set; }

        /// <summary>
        /// Gets or Sets SurName.
        /// </summary>
        public CourseDetailsDomain Course { get; set; }

        public DateTime LastUpdatedDate { get; set; }
    }
}
