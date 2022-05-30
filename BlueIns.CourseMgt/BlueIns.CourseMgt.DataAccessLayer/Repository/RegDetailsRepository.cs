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
    using Microsoft.EntityFrameworkCore.Storage;

    /// <summary>
    /// This is Repository class.
    /// </summary>
    public class RegDetailsRepository : IRegDetailsRepository
    {
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="RegDetailsRepository"/> class.
        /// </summary>
        /// <param name="mapper">IMapee object.</param>
        public RegDetailsRepository(IMapper mapper)
        {
            this._mapper = mapper;
        }

        /// <summary>
        /// This method is for fetching all Student details.
        /// </summary>
        /// <returns>Returns the Student details.</returns>
        public IEnumerable<RegDetailsDomain> GetRegDetailsByStudentId(int studentId)
        {
            using (var masterContext = new MasterContext())
            {
                var regdetails = masterContext
                    .RegDetails
                    .Include(a => a.Student)
                    .Include(a => a.Course)
                    .Where(a => a.Student.Id == studentId)
                    .ToList();
                return this._mapper.Map<List<RegDetailsDto>, List<RegDetailsDomain>>(regdetails);
            }
        }

        /// <summary>
        /// This method is for creating the student details..
        /// </summary>
        /// <param name="regDetailsDomain">Domain model parameter.</param>
        /// <returns>Return to domain model.</returns>
        public RegDetailsDomain CreateRegDetails(RegDetailsDomain regDetailsDomain)
        {
            var regDetails = this._mapper.Map<RegDetailsDomain, RegDetailsDto>(regDetailsDomain);

            StudentDetailsDto stu = new StudentDetailsDto { Id = regDetailsDomain.Student.Id };
            CourseDetailsDto cou = new CourseDetailsDto { CourseId = regDetailsDomain.Course.CourseId };

            regDetails.Course.CourseId = cou.CourseId;
            regDetails.Student.Id = stu.Id;


            using (var masterContext = new MasterContext())
            {
                masterContext.RegDetails.Add(regDetails);
                //masterContext.Database.ExecuteSqlRaw("CreateRegDetails @p0, @p1", parameters: new[] { regDetails.Course.CourseId, regDetails.Student.Id });

                masterContext.SaveChanges();

                //masterContext.Database.ExecuteSqlCommand($"CreateRegDetails {regDetails.Course.CourseId}, {regDetails.Student.Id}");

                return this._mapper.Map<RegDetailsDto, RegDetailsDomain>(regDetails);
            }
        }

        /// /// <summary>
        /// This method is for updating the student.
        /// </summary>
        /// <param name="regDetailsDomain">Domain model parameter.</param>
        /// <returns>Return to domain model.</returns>
        public RegDetailsDomain UpdateRegDetails(RegDetailsDomain regDetailsDomain)
        {
            using (var masterContext = new MasterContext())
            {

                var regDetails = masterContext.RegDetails.FirstOrDefault(a => a.RegId == regDetailsDomain.RegId);
                var regDetailsDto = this._mapper.Map<RegDetailsDomain, RegDetailsDto>(regDetailsDomain);
                masterContext.Entry(regDetails).CurrentValues.SetValues(regDetailsDto);
                masterContext.SaveChanges();
                return this._mapper.Map<RegDetailsDto, RegDetailsDomain>(regDetails);
            }
        }

        /// <summary>
        /// This method is for fetching single student details.
        /// </summary>
        /// <param name="regId">student Id parameter for deletion.</param>
        /// <returns>Returns single student details based on student id.</returns>
        public RegDetailsDomain GetRegDetailsById(int regId)
        {
            using (var masterContext = new MasterContext())
            {
                var regDetails = masterContext.RegDetails.FirstOrDefault(a => a.RegId == regId);
                return this._mapper.Map<RegDetailsDto, RegDetailsDomain>(regDetails);
            }
        }

        /// <summary>
        /// This method is for deleting a selected student.
        /// </summary>
        /// <param name="regId">reg Id parameter for deletion.</param>
        /// <returns>Return bool value after delete.</returns>
        public bool DeleteRegDetails(int regId)
        {
            using (var masterContext = new MasterContext())
            {
                var regDetails = masterContext.RegDetails.FirstOrDefault(a => a.RegId == regId);
                masterContext.RegDetails.Remove(regDetails);
                masterContext.SaveChanges();
                return true;
            }
        }

        //public RegDetailsDomain GetRegDetailsByName(string RegName)
        //{
        //    using (var masterContext = new MasterContext())
        //    {
        //        var regDetails = masterContext.RegDetails.FirstOrDefault(a => a.RegName == RegName);
        //        return this._mapper.Map<RegDetailsDto, RegDetailsDomain>(regDetails);
        //    }
        //}
    }
}
