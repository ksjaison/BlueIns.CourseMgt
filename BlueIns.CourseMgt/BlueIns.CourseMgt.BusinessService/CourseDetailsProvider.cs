namespace BlueIns.CourseMgt.BusinessService
{
    using System.Collections.Generic;
    using BlueIns.CourseMgt.DataAccessLayer.Abstractions.Repository;
    using BlueIns.CourseMgt.DomainModel;
    using BlueIns.CourseMgt.DomainModel.Abstractions;

    /// <summary>
    /// This Business service or provider class which pass value to Repository.
    /// </summary>
    public class CourseDetailsProvider : ICourseDetailsProvider
    {
        private readonly ICourseDetailsRepository _courseDetailsRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CourseDetailsProvider"/> class.
        /// </summary>
        /// <param name="courseDetailsRepository">dddd.</param>
        public CourseDetailsProvider(ICourseDetailsRepository courseDetailsRepository)
        {
            this._courseDetailsRepository = courseDetailsRepository;
        }

        /// <summary>
        /// This method is for creating the task.
        /// </summary>
        /// <param name="courseDetailsDomain">Domain model parameter.</param>
        /// <returns>It returs domain model values.</returns>
        public CourseDetailsDomain CreateCourseDetails(CourseDetailsDomain courseDetailsDomain)
        {
            return this._courseDetailsRepository.CreateCourseDetails(courseDetailsDomain);
        }

        /// <summary>
        /// This method is for deleting a selected task.
        /// </summary>
        /// <param name="courseId">Course Id parameter for deletion.</param>
        /// <returns>It returs domain model values.</returns>
        public bool DeleteCoursedetails(int courseId)
        {
            return this._courseDetailsRepository.DeleteCourseDetails(courseId);
        }

        public bool DeleteCourseDetails(int id)
        {
            return this._courseDetailsRepository.DeleteCourseDetails(id);
        }

        /// <summary>
        /// This method is for fetching all task details.
        /// </summary>
        /// <returns>Returns the Student details.</returns>
        public IEnumerable<CourseDetailsDomain> GetCourseDetails()
        {
            return this._courseDetailsRepository.GetCourseDetails();
        }

        /// <summary>
        /// This method is for fetching single task details.
        /// </summary>
        /// <param name="courseId">Course Id parameter for deletion.</param>
        /// <returns>Returns single Student details based on student id.</returns>
        public CourseDetailsDomain GetCourseDetailsById(int coursetId)
        {
            return this._courseDetailsRepository.GetCourseDetailsById(coursetId);
        }

        /// <summary>
        /// This method is for fetching single task details.
        /// </summary>
        /// <param name="courseName">Course Id parameter for deletion.</param>
        /// <returns>Returns single Student details based on student id.</returns>
        public CourseDetailsDomain GetCourseDetailsByName(string courseName)
        {
            return this._courseDetailsRepository.GetCourseDetailsByName(courseName);
        }

        /// <summary>
        /// This method is for updating the task.
        /// </summary>
        /// <param name="courseDetailsDomain">Domain model parameter.</param>
        /// <returns>It returs domain model values.</returns>
        public CourseDetailsDomain UpdateCourseDetails(CourseDetailsDomain courseDetailsDomain)
        {
            return this._courseDetailsRepository.UpdateCourseDetails(courseDetailsDomain);
        }
    }
}
