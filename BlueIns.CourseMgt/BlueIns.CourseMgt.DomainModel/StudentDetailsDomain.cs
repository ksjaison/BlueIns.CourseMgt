namespace BlueIns.CourseMgt.DomainModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Domain class for setting and getting Task items.
    /// </summary>
    public class StudentDetailsDomain : Base
    {
        /// <summary>
        /// Gets or Sets Task Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or Sets FirstName.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or Sets SurName.
        /// </summary>
        public string SurName { get; set; }

        /// <summary>
        /// Gets or Sets Gender.
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// Gets or Sets Date of Birth.
        /// </summary>
        public DateTime DOB { get; set; }

        /// <summary>
        /// Gets or Sets Address1.
        /// </summary>
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
