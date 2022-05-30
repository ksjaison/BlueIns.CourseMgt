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
    /// Initializes a new instance of the <see cref="StudentDetailsController"/> class.
    /// </summary>
    public class StudentDetailsController : Controller
    {
        private readonly IStudentDetailsProvider _studentdetails;

        // Create a field to store the mapper object
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="StudentDetailsController"/> class.
        /// </summary>
        /// <param name="istudentdetails">Student Details Provider interface.</param>
        /// <param name="mapper">IMapper object.</param>
        public StudentDetailsController(IStudentDetailsProvider istudentdetails, IMapper mapper)
        {
            this._studentdetails = istudentdetails;
            this._mapper = mapper;
        }

        private string GetSessionString()
        {
            string strUserName = this.HttpContext.Session.GetString("userName");
            return strUserName;
        }

        // GET: StudentDetails
        public async Task<ActionResult<IEnumerable<StudentDetailsViewModel>>> Index()
        {
            //if (this.GetSessionString() == null)
            //{
            //    return this.RedirectToAction("Index", "Home");
            //}

            var studentDetails = this._studentdetails.GetStudentDetails().ToList();

            if (studentDetails.Any())
            {
                var model = this._mapper.Map<List<StudentDetailsViewModel>>(studentDetails);
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
        /// <param name="studentdetails">Web model view object.</param>
        /// <returns>A <see cref="Student{TResult}"/> representing the result of the asynchronous operation.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName, SurName, Gender, DOB, Address1, Address2, Address3")] StudentDetailsViewModel studentdetails)
        {
            //if (this.GetSessionString() == null)
            //{
            //    return this.RedirectToAction("Index", "Home");
            //}

            if (this.ModelState.IsValid)
            {
                var model = this._mapper.Map<StudentDetailsViewModel, StudentDetailsDomain>(studentdetails);
                model.LastUpdatedDate = DateTime.Now;
                this._studentdetails.CreateStudentDetails(model);
                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(studentdetails);
        }

        // GET: StudentDetails/Edit/5
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

            var model = this._mapper.Map<StudentDetailsDomain, StudentDetailsViewModel>(this._studentdetails.GetStudentDetailsById(id));
            if (model == null)
            {
                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(model);
        }

        // POST: StudentDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FirstName, SurName, Gender, DOB, Address1, Address2, Address3")] StudentDetailsViewModel studentdetails)
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
                var model = this._mapper.Map<StudentDetailsViewModel, StudentDetailsDomain>(studentdetails);
                model.Id = id;
                model.LastUpdatedDate = DateTime.Now;
                this._studentdetails.UpdateStudentDetails(model);
                return this.RedirectToAction(nameof(this.Index));
            }
            else
            {
                return this.View(studentdetails);
            }
        }

        // GET: StudentDetails/Delete/5
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

            var model = this._mapper.Map<StudentDetailsDomain, StudentDetailsViewModel>(this._studentdetails.GetStudentDetailsById(id));
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
        // POST: StudentDetails/Delete/5
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

            this._studentdetails.DeleteStudentdetails(id);

            var studentDetails = this._studentdetails.GetStudentDetails().ToList();
            var model = this._mapper.Map<List<StudentDetailsViewModel>>(studentDetails);
            return this.RedirectToAction(nameof(this.Index));
        }
    }
}
