namespace BlueIns.CourseMgt.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// This is class for item view model and setting and getting task related values.
    /// </summary>
    public class StudentDetailsViewModel
    {
        /// <summary>
        /// Gets or Sets Task Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or Sets FirstName.
        /// </summary>
        [Required(ErrorMessage = "Fisrt Name is required")]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or Sets SurName.
        /// </summary>
        [Required(ErrorMessage = "Surname is required")]
        public string SurName { get; set; }

        /// <summary>
        /// Gets or Sets Gender.
        /// </summary>
        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; }

        /// <summary>
        /// Gets or Sets Date of Birth.
        /// </summary>
        [Required(ErrorMessage = "Date of birth is required")]
        public DateTime DOB { get; set; }

        /// <summary>
        /// Gets or Sets Address1.
        /// </summary>
        [Required(ErrorMessage = "Address is required")]
        public string Address1 { get; set; }

        /// <summary>
        /// Gets or Sets Address2.
        /// </summary>
        public string Address2 { get; set; }

        /// <summary>
        /// Gets or Sets Address3.
        /// </summary>
        public string Address3 { get; set; }

        /// <summary>
        /// Gets or Sets LastUpdatedDate.
        /// </summary>
        public DateTime LastUpdatedDate { get; set; }

    }
}
