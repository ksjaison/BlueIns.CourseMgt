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
    public class StudentDetailsRepository : IStudentDetailsRepository
    {
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="StudentDetailsRepository"/> class.
        /// </summary>
        /// <param name="mapper">IMapee object.</param>
        public StudentDetailsRepository(IMapper mapper)
        {
            this._mapper = mapper;
        }

        /// <summary>
        /// This method is for fetching all Student details.
        /// </summary>
        /// <returns>Returns the Student details.</returns>
        public IEnumerable<StudentDetailsDomain> GetStudentDetails()
        {
            using (var masterContext = new MasterContext())
            {
                var studentdetails = masterContext
                    .StudentDetails
                    .ToList();
                return this._mapper.Map<List<StudentDetailsDto>, List<StudentDetailsDomain>>(studentdetails);
            }
        }

        /// <summary>
        /// This method is for creating the student details..
        /// </summary>
        /// <param name="studentDetailsDomain">Domain model parameter.</param>
        /// <returns>Return to domain model.</returns>
        public StudentDetailsDomain CreateStudentDetails(StudentDetailsDomain studentDetailsDomain)
        {
            var studentDetails = this._mapper.Map<StudentDetailsDomain, StudentDetailsDto>(studentDetailsDomain);

            using (var masterContext = new MasterContext())
            {
                masterContext.StudentDetails.Add(studentDetails);
                masterContext.SaveChanges();
                return this._mapper.Map<StudentDetailsDto, StudentDetailsDomain>(studentDetails);
            }
        }

        /// /// <summary>
        /// This method is for updating the student.
        /// </summary>
        /// <param name="studentDetailsDomain">Domain model parameter.</param>
        /// <returns>Return to domain model.</returns>
        public StudentDetailsDomain UpdateStudentDetails(StudentDetailsDomain studentDetailsDomain)
        {
            using (var masterContext = new MasterContext())
            {

                var studentDetails = masterContext.StudentDetails.FirstOrDefault(a => a.Id == studentDetailsDomain.Id);
                var studentDetailsDto = this._mapper.Map<StudentDetailsDomain, StudentDetailsDto>(studentDetailsDomain);
                masterContext.Entry(studentDetails).CurrentValues.SetValues(studentDetailsDto);
                masterContext.SaveChanges();
                return this._mapper.Map<StudentDetailsDto, StudentDetailsDomain>(studentDetails);
            }
        }

        /// <summary>
        /// This method is for fetching single student details.
        /// </summary>
        /// <param name="studentId">student Id parameter for deletion.</param>
        /// <returns>Returns single student details based on student id.</returns>
        public StudentDetailsDomain GetStudentDetailsById(int studentId)
        {
            using (var masterContext = new MasterContext())
            {
                var studentDetails = masterContext.StudentDetails.FirstOrDefault(a => a.Id == studentId);
                return this._mapper.Map<StudentDetailsDto,StudentDetailsDomain>(studentDetails);
            }
        }

        /// <summary>
        /// This method is for deleting a selected student.
        /// </summary>
        /// <param name="studentId">student Id parameter for deletion.</param>
        /// <returns>Return bool value after delete.</returns>
        public bool DeleteStudentDetails(int studentId)
        {
            using (var masterContext = new MasterContext())
            {
                var studentDetails = masterContext.StudentDetails.FirstOrDefault(a => a.Id == studentId);
                masterContext.StudentDetails.Remove(studentDetails);
                masterContext.SaveChanges();
                return true;
            }
        }
    }
}
