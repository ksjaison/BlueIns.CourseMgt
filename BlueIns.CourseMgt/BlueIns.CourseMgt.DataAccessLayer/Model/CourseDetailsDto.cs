namespace BlueIns.CourseMgt.DataAccessLayer.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Base class of data model class for setting and getting Task related values.
    /// </summary>
    public class CourseDetailsDto : Base
    {
        /// <summary>
        /// Gets or Sets Task Id.
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int CourseId { get; set; }

        /// <summary>
        /// Gets or Sets FirstName.
        /// </summary>
        [Required]
        [StringLength(50)]
        public string CourseName { get; set; }

        /// <summary>
        /// Gets or Sets SurName.
        /// </summary>
        [Required]
        [StringLength(50)]
        public string TeacherName { get; set; }

        /// <summary>
        /// Gets or Sets start date.
        /// </summary>
        [Required]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Gets or Sets end date.
        /// </summary>
        [Required]
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Gets or NoofSeats.
        /// </summary>
        [Required]
        public int NoofSeats { get; set; }

        /// <summary>
        /// Gets or Sets LastUpdatedDate.
        /// </summary>
        public DateTime LastUpdatedDate { get; set; }

    }
}
