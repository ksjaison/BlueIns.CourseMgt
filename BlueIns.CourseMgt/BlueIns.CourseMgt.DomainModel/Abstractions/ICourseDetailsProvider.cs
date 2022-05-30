namespace BlueIns.CourseMgt.DomainModel.Abstractions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface ICourseDetailsProvider
    {
        public IEnumerable<CourseDetailsDomain> GetCourseDetails();

        CourseDetailsDomain GetCourseDetailsById(int id);
        CourseDetailsDomain GetCourseDetailsByName(string courseName);

        CourseDetailsDomain CreateCourseDetails(CourseDetailsDomain courseDetails);

        bool DeleteCourseDetails(int id);

        CourseDetailsDomain UpdateCourseDetails(CourseDetailsDomain courseDetails);

    }
}
