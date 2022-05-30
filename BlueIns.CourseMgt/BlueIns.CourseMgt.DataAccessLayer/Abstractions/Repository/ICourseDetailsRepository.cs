namespace BlueIns.CourseMgt.DataAccessLayer.Abstractions.Repository
{
    using System.Collections.Generic;
    using BlueIns.CourseMgt.DomainModel;

    /// <summary>
    /// Repository class interface.
    /// </summary>
    public interface ICourseDetailsRepository
    {
        /// /// <summary>
        /// Fetch all Course details.
        /// </summary>
        /// <returns>Returns the Domain model class object.</returns>
        public IEnumerable<CourseDetailsDomain> GetCourseDetails();

        /// <summary>
        /// Fetch Course details using Course Id.
        /// </summary>
        /// <param name="CourseId">Course Id parameter.</param>
        /// <returns>Returns the Domain model class object value.</returns>
        CourseDetailsDomain GetCourseDetailsById(int CourseId);

        /// <summary>
        /// Fetch Course details using Course Id.
        /// </summary>
        /// <param name="CourseName">Course Id parameter.</param>
        /// <returns>Returns the Domain model class object value.</returns>
        CourseDetailsDomain GetCourseDetailsByName(string CourseName);

        /// <summary>
        /// Add new Course.
        /// </summary>
        /// <param name="courseDetailsDomain">Domain class object.</param>
        /// <returns>Domain class object return after insert value to database.</returns>
        CourseDetailsDomain CreateCourseDetails(CourseDetailsDomain courseDetailsDomain);

        /// <summary>
        /// Modify course.
        /// </summary>
        /// <param name="courseId">course Id parameter.</param>
        /// <returns>Return true or false status after insert value to database.</returns>
        bool DeleteCourseDetails(int courseId);

        /// <summary>
        /// Modify course.
        /// </summary>
        /// <param name="courseId">course Id parameter.</param>
        /// <returns>Domain class object return after modifying the value to database.</returns>
        CourseDetailsDomain UpdateCourseDetails(CourseDetailsDomain courseDetailsDomain);
    }
}
