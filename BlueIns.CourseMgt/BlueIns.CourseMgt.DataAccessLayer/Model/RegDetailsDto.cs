namespace BlueIns.CourseMgt.DataAccessLayer.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using BlueIns.CourseMgt.DomainModel;

    /// <summary>
    /// Base class of data model class for setting and getting Task related values.
    /// </summary>
    public class RegDetailsDto : Base
    {
        /// <summary>
        /// Gets or Sets Task Id.
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int RegId { get; set; }

        /// <summary>
        /// Gets or Sets FirstName.
        /// </summary>
        [Required]
        [ForeignKey("Id")]
        public StudentDetailsDto Student { get; set; }

        /// <summary>
        /// Gets or Sets SurName.
        /// </summary>
        [Required]
        [ForeignKey("CourseId")]
        public CourseDetailsDto Course { get; set; }

        /// <summary>
        /// Gets or Sets LastUpdatedDate.
        /// </summary>
        public DateTime LastUpdatedDate { get; set; }
    }
}
