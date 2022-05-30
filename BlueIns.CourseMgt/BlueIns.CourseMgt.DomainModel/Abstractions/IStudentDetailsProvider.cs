namespace BlueIns.CourseMgt.DomainModel.Abstractions
{
    using System.Collections.Generic;
    using BlueIns.CourseMgt.DomainModel;

    /// <summary>
    /// Business service or provider class interface.
    /// </summary>
    public interface IStudentDetailsProvider
    {
        /// <summary>
        /// Fetch all Student details.
        /// </summary>
        /// <returns>Returns the Domain model class object.</returns>
        public IEnumerable<StudentDetailsDomain> GetStudentDetails();

        /// <summary>
        /// Fetch task details using Student Id.
        /// </summary>
        /// <param name="taskId">Student Id parameter.</param>
        /// <returns>Returns the Domain model class object value.</returns>
        StudentDetailsDomain GetStudentDetailsById(int studentId);

        /// <summary>
        /// Add new Student.
        /// </summary>
        /// <param name="studentDetailsDomain">Domain class object.</param>
        /// <returns>Domain class object return after insert value to database.</returns>
        StudentDetailsDomain CreateStudentDetails(StudentDetailsDomain studentDetailsDomain);

        /// <summary>
        /// Modify Student.
        /// </summary>
        /// <param name="studentId">Student Id parameter.</param>
        /// <returns>Return true or false status after insert value to database.</returns>
        bool DeleteStudentdetails(int studentId);

        /// <summary>
        /// Modify Student.
        /// </summary>
        /// <param name="studentId">Student Id parameter.</param>
        /// <returns>Domain class object return after modifying the value to database.</returns>
        StudentDetailsDomain UpdateStudentDetails(StudentDetailsDomain studentDetailsDomain);
    }
}
