namespace BlueIns.CourseMgt.Web.Controllers
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using BlueIns.CourseMgt.DomainModel;
    using BlueIns.CourseMgt.DomainModel.Abstractions;
    using BlueIns.CourseMgt.Web.Models;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Initializes a new instance of the <see cref="RegCourseController"/> class.
    /// </summary>
    public class RegCourseController : Controller
    {
        private readonly IRegDetailsProvider _regdetails;
        private readonly ICourseDetailsProvider _coursedetails;
        private readonly IStudentDetailsProvider _studentDetails;

        // Create a field to store the mapper object
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="RegDetailsController"/> class.
        /// </summary>
        /// <param name="coursedetails">Student Details Provider interface.</param>
        /// <param name="mapper">IMapper object.</param>
        public RegCourseController(IRegDetailsProvider regdetails, IMapper mapper, ICourseDetailsProvider coursedetails,IStudentDetailsProvider studentDetails)
        {
            this._regdetails = regdetails;
            this._mapper = mapper;
            this._coursedetails = coursedetails;
            this._studentDetails = studentDetails;
        }

        private string GetSessionString()
        {
            string strUserName = this.HttpContext.Session.GetString("userName");
            return strUserName;
        }

        /// <summary>
        /// New course map creation (Student Id, Course Id).
        /// </summary>
        /// <param name="studentdetails">Web model view object.</param>
        /// <returns>A <see cref="Student{TResult}"/> representing the result of the asynchronous operation.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Item1.Student,Item1.Course")] RegDetailsViewModel Regdetails)
        {

            StudentDetailsViewModel studeDetails = new StudentDetailsViewModel();
            CourseDetailsViewModel courseDetails = new CourseDetailsViewModel();

            if (this.ModelState.IsValid)
            {
                studeDetails.Id = 1;
                courseDetails.CourseId = 1;

                var model = this._mapper.Map<RegDetailsViewModel, RegDetailsDomain>(Regdetails);
                model.Student = this._mapper.Map<StudentDetailsViewModel, StudentDetailsDomain>(studeDetails);
                model.Course = this._mapper.Map<CourseDetailsViewModel, CourseDetailsDomain>(courseDetails);
                model.LastUpdatedDate = DateTime.Now;
                this._regdetails.CreateRegDetails(model);

                var regDetails = this._regdetails.GetRegDetailsByStudentId(studeDetails.Id).ToList();

                if (regDetails.Any())
                {
                    return this.View(Tuple.Create<RegDetailsViewModel, IEnumerable<RegDetailsViewModel>>(new RegDetailsViewModel(), this._mapper.Map<List<RegDetailsViewModel>>(regDetails)));
                }

                return this.View();
            }
            return this.View();
        }


        // GET: RegDetails
        public async Task<ActionResult<IEnumerable<RegDetailsViewModel>>> Index(int id)
        {
            var courseDetails = this._coursedetails.GetCourseDetails().ToList();

            Dictionary<int, string> alCity = new Dictionary<int, string>();

            if (courseDetails.Any())
            {
                foreach (var course in courseDetails)
                {
                    alCity.Add(course.CourseId, course.CourseName);
                }

                this.ViewData["Courses"] = alCity;
            }

            Dictionary<string, string> alStudent = new Dictionary<string, string>();
            var studentDetails = this._studentDetails.GetStudentDetailsById(id);

            IList<StudentDetailsDomain> studentList = new List<StudentDetailsDomain>();
            studentList.Add(new StudentDetailsDomain() { FirstName = studentDetails.FirstName });
            studentList.Add(new StudentDetailsDomain() { SurName = studentDetails.SurName });
            studentList.Add(new StudentDetailsDomain() { DOB = studentDetails.DOB });
            ViewData["students"] = studentList;

            var regDetails = this._regdetails.GetRegDetailsByStudentId(id).ToList();

            if (regDetails.Any())
            {
                return this.View(Tuple.Create<RegDetailsViewModel, IEnumerable<RegDetailsViewModel>>(new RegDetailsViewModel(), this._mapper.Map<List<RegDetailsViewModel>>(regDetails)));
            }

            return this.View();
        }
    }
}
