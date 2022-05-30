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
    public class StudentDetailsDto : Base
    {
        /// <summary>
        /// Gets or Sets Task Id.
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or Sets FirstName.
        /// </summary>
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or Sets SurName.
        /// </summary>
        [Required]
        [StringLength(50)]
        public string SurName { get; set; }

        /// <summary>
        /// Gets or Sets Gender.
        /// </summary>
        [Required]
        [StringLength(1)]
        public string Gender { get; set; }

        /// <summary>
        /// Gets or Sets Date of Birth.
        /// </summary>
        [Required]
        public DateTime DOB { get; set; }

        /// <summary>
        /// Gets or Sets Address1.
        /// </summary>
        [Required]
        [StringLength(100)]
        public string Address1 { get; set; }

        /// <summary>
        /// Gets or Sets Address2.
        /// </summary>
        [StringLength(100)]
        public string Address2 { get; set; }

        /// <summary>
        /// Gets or Sets Address3.
        /// </summary>
        [StringLength(100)]
        public string Address3 { get; set; }

        /// <summary>
        /// Gets or Sets LastUpdatedDate.
        /// </summary>
        public DateTime LastUpdatedDate { get; set; }

    }
}
