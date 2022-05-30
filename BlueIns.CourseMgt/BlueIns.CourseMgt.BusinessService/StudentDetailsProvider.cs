namespace BlueIns.CourseMgt.BusinessService
{
    using System.Collections.Generic;
    using BlueIns.CourseMgt.DataAccessLayer.Abstractions.Repository;
    using BlueIns.CourseMgt.DomainModel;
    using BlueIns.CourseMgt.DomainModel.Abstractions;

    /// <summary>
    /// This Business service or provider class which pass value to Repository.
    /// </summary>
    public class StudentDetailsProvider : IStudentDetailsProvider
    {
        private readonly IStudentDetailsRepository _studentDetailsRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="StudentDetailsProvider"/> class.
        /// </summary>
        /// <param name="taskDetailsRepository">dddd.</param>
        public StudentDetailsProvider(IStudentDetailsRepository studentDetailsRepository)
        {
            this._studentDetailsRepository = studentDetailsRepository;
        }

        /// <summary>
        /// This method is for creating the task.
        /// </summary>
        /// <param name="studentDetailsDomain">Domain model parameter.</param>
        /// <returns>It returs domain model values.</returns>
        public StudentDetailsDomain CreateStudentDetails(StudentDetailsDomain studentDetailsDomain)
        {
            return this._studentDetailsRepository.CreateStudentDetails(studentDetailsDomain);
        }

        /// <summary>
        /// This method is for deleting a selected task.
        /// </summary>
        /// <param name="studentId">Student Id parameter for deletion.</param>
        /// <returns>It returs domain model values.</returns>
        public bool DeleteStudentdetails(int studentId)
        {
            return this._studentDetailsRepository.DeleteStudentDetails(studentId);
        }

        /// <summary>
        /// This method is for fetching all task details.
        /// </summary>
        /// <returns>Returns the Student details.</returns>
        public IEnumerable<StudentDetailsDomain> GetStudentDetails()
        {
            return this._studentDetailsRepository.GetStudentDetails();
        }

        /// <summary>
        /// This method is for fetching single task details.
        /// </summary>
        /// <param name="studentId">Student Id parameter for deletion.</param>
        /// <returns>Returns single Student details based on student id.</returns>
        public StudentDetailsDomain GetStudentDetailsById(int studentId)
        {
            return this._studentDetailsRepository.GetStudentDetailsById(studentId);
        }

        /// <summary>
        /// This method is for updating the task.
        /// </summary>
        /// <param name="studentDetailsDomain">Domain model parameter.</param>
        /// <returns>It returs domain model values.</returns>
        public StudentDetailsDomain UpdateStudentDetails(StudentDetailsDomain studentDetailsDomain)
        {
            return this._studentDetailsRepository.UpdateStudentDetails(studentDetailsDomain);
        }
    }
}
