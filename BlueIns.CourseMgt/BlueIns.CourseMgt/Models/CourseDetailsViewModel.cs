namespace BlueIns.CourseMgt.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// This is class for item view model and setting and getting task related values.
    /// </summary>
    public class CourseDetailsViewModel
    {
        /// <summary>
        /// Gets or Sets Task Id.
        /// </summary>
        public int CourseId { get; set; }

        /// <summary>
        /// Gets or Sets FirstName.
        /// </summary>
        [Required(ErrorMessage = "Course Name is required")]
        public string CourseName { get; set; }

        /// <summary>
        /// Gets or Sets SurName.
        /// </summary>
        [Required(ErrorMessage = "Teacher is required")]
        public string TeacherName { get; set; }

        /// <summary>
        /// Gets or Sets Start Date.
        /// </summary>
        [Required(ErrorMessage = "Start Date is required")]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Gets or Sets End Date.
        /// </summary>
        [Required(ErrorMessage = "End date is required")]
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Gets or Sets NoofSeats.
        /// </summary>
        [Required(ErrorMessage = "Please enter number seats available")]
        public int NoofSeats { get; set; }

        public DateTime LastUpdatedDate { get; set; }

    }
}
