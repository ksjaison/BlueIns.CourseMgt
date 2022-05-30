namespace BlueIns.CourseMgt.DataAccessLayer.Repository
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using BlueIns.CourseMgt.DataAccessLayer.Abstractions.Repository;
    using BlueIns.CourseMgt.DataAccessLayer.Context;
    using BlueIns.CourseMgt.DataAccessLayer.Model;
    using BlueIns.CourseMgt.DomainModel;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// This is Repository class.
    /// </summary>
    public class CourseDetailsRepository : ICourseDetailsRepository
    {
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="CourseDetailsRepository"/> class.
        /// </summary>
        /// <param name="mapper">IMapee object.</param>
        public CourseDetailsRepository(IMapper mapper)
        {
            this._mapper = mapper;
        }

        /// <summary>
        /// This method is for fetching all Student details.
        /// </summary>
        /// <returns>Returns the Student details.</returns>
        public IEnumerable<CourseDetailsDomain> GetCourseDetails()
        {
            using (var masterContext = new MasterContext())
            {
                var coursedetails = masterContext
                    .CourseDetails
                    .ToList();
                return this._mapper.Map<List<CourseDetailsDto>, List<CourseDetailsDomain>>(coursedetails);
            }
        }

        /// <summary>
        /// This method is for creating the student details..
        /// </summary>
        /// <param name="courseDetailsDomain">Domain model parameter.</param>
        /// <returns>Return to domain model.</returns>
        public CourseDetailsDomain CreateCourseDetails(CourseDetailsDomain courseDetailsDomain)
        {
            var courseDetails = this._mapper.Map<CourseDetailsDomain, CourseDetailsDto>(courseDetailsDomain);

            using (var masterContext = new MasterContext())
            {
                masterContext.CourseDetails.Add(courseDetails);
                masterContext.SaveChanges();
                return this._mapper.Map<CourseDetailsDto, CourseDetailsDomain>(courseDetails);
            }
        }

        /// /// <summary>
        /// This method is for updating the student.
        /// </summary>
        /// <param name="courseDetailsDomain">Domain model parameter.</param>
        /// <returns>Return to domain model.</returns>
        public CourseDetailsDomain UpdateCourseDetails(CourseDetailsDomain courseDetailsDomain)
        {
            using (var masterContext = new MasterContext())
            {

                var courseDetails = masterContext.CourseDetails.FirstOrDefault(a => a.CourseId == courseDetailsDomain.CourseId);
                var courseDetailsDto = this._mapper.Map<CourseDetailsDomain, CourseDetailsDto>(courseDetailsDomain);
                masterContext.Entry(courseDetails).CurrentValues.SetValues(courseDetailsDto);
                masterContext.SaveChanges();
                return this._mapper.Map<CourseDetailsDto, CourseDetailsDomain>(courseDetails);
            }
        }

        /// <summary>
        /// This method is for fetching single student details.
        /// </summary>
        /// <param name="courseId">student Id parameter for deletion.</param>
        /// <returns>Returns single student details based on student id.</returns>
        public CourseDetailsDomain GetCourseDetailsById(int courseId)
        {
            using (var masterContext = new MasterContext())
            {
                var courseDetails = masterContext.CourseDetails.FirstOrDefault(a => a.CourseId == courseId);
                return this._mapper.Map<CourseDetailsDto, CourseDetailsDomain>(courseDetails);
            }
        }

        /// <summary>
        /// This method is for deleting a selected student.
        /// </summary>
        /// <param name="courseId">course Id parameter for deletion.</param>
        /// <returns>Return bool value after delete.</returns>
        public bool DeleteCourseDetails(int courseId)
        {
            using (var masterContext = new MasterContext())
            {
                var courseDetails = masterContext.CourseDetails.FirstOrDefault(a => a.CourseId == courseId);
                masterContext.CourseDetails.Remove(courseDetails);
                masterContext.SaveChanges();
                return true;
            }
        }

        public CourseDetailsDomain GetCourseDetailsByName(string CourseName)
        {
            using (var masterContext = new MasterContext())
            {
                var courseDetails = masterContext.CourseDetails.FirstOrDefault(a => a.CourseName == CourseName);
                return this._mapper.Map<CourseDetailsDto, CourseDetailsDomain>(courseDetails);
            }
        }
    }
}
