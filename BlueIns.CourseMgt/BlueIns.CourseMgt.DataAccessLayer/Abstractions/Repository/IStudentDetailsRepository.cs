namespace BlueIns.CourseMgt.DataAccessLayer.Abstractions.Repository
{
    using System.Collections.Generic;
    using BlueIns.CourseMgt.DomainModel;

    /// <summary>
    /// Repository class interface.
    /// </summary>
    public interface IStudentDetailsRepository
    {
        /// /// <summary>
        /// Fetch all student details.
        /// </summary>
        /// <returns>Returns the Domain model class object.</returns>
        public IEnumerable<StudentDetailsDomain> GetStudentDetails();

        /// <summary>
        /// Fetch student details using student Id.
        /// </summary>
        /// <param name="StudentId">student Id parameter.</param>
        /// <returns>Returns the Domain model class object value.</returns>
        StudentDetailsDomain GetStudentDetailsById(int StudentId);

        /// <summary>
        /// Add new student.
        /// </summary>
        /// <param name="studentDetailsDomain">Domain class object.</param>
        /// <returns>Domain class object return after insert value to database.</returns>
        StudentDetailsDomain CreateStudentDetails(StudentDetailsDomain studentDetailsDomain);

        /// <summary>
        /// Modify student.
        /// </summary>
        /// <param name="studentId">student Id parameter.</param>
        /// <returns>Return true or false status after insert value to database.</returns>
        bool DeleteStudentDetails(int studentId);

        /// <summary>
        /// Modify student.
        /// </summary>
        /// <param name="studentId">student Id parameter.</param>
        /// <returns>Domain class object return after modifying the value to database.</returns>
        StudentDetailsDomain UpdateStudentDetails(StudentDetailsDomain studentDetailsDomain);
    }
}
