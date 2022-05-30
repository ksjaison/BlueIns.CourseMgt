namespace BlueIns.CourseMgt.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using BlueIns.CourseMgt.DomainModel;

    /// <summary>
    /// This is class for item view model and setting and getting task related values.
    /// </summary>
    public class RegDetailsViewModel
    {
        /// <summary>
        /// Gets or Sets Task Id.
        /// </summary>
        public int RegId { get; set; }

        /// <summary>
        /// Gets or Sets FirstName.
        /// </summary>
        public StudentDetailsViewModel Student { get; set; }

        /// <summary>
        /// Gets or Sets SurName.
        /// </summary>
        public CourseDetailsViewModel Course { get; set; }

        public DateTime LastUpdatedDate { get; set; }

    }
}
