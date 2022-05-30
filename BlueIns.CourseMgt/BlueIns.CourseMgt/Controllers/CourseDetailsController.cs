namespace BlueIns.CourseMgt.Web.Controllers
{
    using System;
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
    /// Initializes a new instance of the <see cref="CourseDetailsController"/> class.
    /// </summary>
    public class CourseDetailsController : Controller
    {
        private readonly ICourseDetailsProvider _coursedetails;

        // Create a field to store the mapper object
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="CourseDetailsController"/> class.
        /// </summary>
        /// <param name="coursedetails">Student Details Provider interface.</param>
        /// <param name="mapper">IMapper object.</param>
        public CourseDetailsController(ICourseDetailsProvider coursedetails, IMapper mapper)
        {
            this._coursedetails = coursedetails;
            this._mapper = mapper;
        }

        private string GetSessionString()
        {
            string strUserName = this.HttpContext.Session.GetString("userName");
            return strUserName;
        }

        // GET: StudentDetails
        public async Task<ActionResult<IEnumerable<CourseDetailsViewModel>>> Index()
        {
            //if (this.GetSessionString() == null)
            //{
            //    return this.RedirectToAction("Index", "Home");
            //}

            var courseDetails = this._coursedetails.GetCourseDetails().ToList();

            if (courseDetails.Any())
            {
                var model = this._mapper.Map<List<CourseDetailsViewModel>>(courseDetails);
                return this.View(model);
            }

            return this.View();
        }

        // GET: StudentDetails/Create
        public IActionResult Create()
        {
            //if (this.GetSessionString() == null)
            //{
            //    return this.RedirectToAction("Index", "Home");
            //}

            return this.View();
        }

        // POST: StudentDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        /// <summary>
        /// New student creation (FirstName, SurName, Gender, DOB, Address1, Address2, Address3).
        /// </summary>
        /// <param name="coursedetails">Web model view object.</param>
        /// <returns>A <see cref="Course{TResult}"/> representing the result of the asynchronous operation.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CourseName, TeacherName, StartDate, EndDate, NoofSeats")] CourseDetailsViewModel coursedetails)
        {
            //if (this.GetSessionString() == null)
            //{
            //    return this.RedirectToAction("Index", "Home");
            //}

            //var corseNameExistorNot = this._coursedetails.GetCourseDetailsByName(coursedetails.CourseName);
            //if (corseNameExistorNot.CourseName.ToString() == string.Empty)
            //{
            //    return this.NotFound();
            //}

            if (this.ModelState.IsValid)
            {
                var model = this._mapper.Map<CourseDetailsViewModel, CourseDetailsDomain>(coursedetails);
                model.LastUpdatedDate = DateTime.Now;
                this._coursedetails.CreateCourseDetails(model);
                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(coursedetails);
        }

        // GET: CourseDetails/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            //if (this.GetSessionString() == null)
            //{
            //    return this.RedirectToAction("Index", "Home");
            //}

            if (id == null)
            {
                return this.NotFound();
            }

            var model = this._mapper.Map<CourseDetailsDomain, CourseDetailsViewModel>(this._coursedetails.GetCourseDetailsById(id));
            if (model == null)
            {
                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(model);
        }

        // POST: CourseDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CourseName, TeacherName, StartDate, EndDate, NoofSeats")] CourseDetailsViewModel coursedetails)
        {
            //if (this.GetSessionString() == null)
            //{
            //    return this.RedirectToAction("Index", "Home");
            //}

            if (id == null)
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                var model = this._mapper.Map<CourseDetailsViewModel, CourseDetailsDomain>(coursedetails);
                model.CourseId = id;
                model.LastUpdatedDate = DateTime.Now;
                this._coursedetails.UpdateCourseDetails(model);
                return this.RedirectToAction(nameof(this.Index));
            }
            else
            {
                return this.View(coursedetails);
            }
        }

        // GET: CourseDetails/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            //if (this.GetSessionString() == null)
            //{
            //    return this.RedirectToAction("Index", "Home");
            //}

            if (id == null)
            {
                return this.NotFound();
            }

            var model = this._mapper.Map<CourseDetailsDomain, CourseDetailsViewModel>(this._coursedetails.GetCourseDetailsById(id));
            if (model == null)
            {
                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(model);
        }

        /// <summary>
        /// Performing delete action.
        /// </summary>
        /// <param name="id">Sending student id as parameter.</param>
        /// <returns>Page return to Student List grid.</returns>
        // POST: CourseDetails/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //if (this.GetSessionString() == null)
            //{
            //    return this.RedirectToAction("Index", "Home");
            //}

            if (id == null)
            {
                return this.NotFound();
            }

            this._coursedetails.DeleteCourseDetails(id);
            var courseDetails = this._coursedetails.GetCourseDetails().ToList();
            var model = this._mapper.Map<List<CourseDetailsViewModel>>(courseDetails);
            return this.RedirectToAction(nameof(this.Index));
        }
    }
}
