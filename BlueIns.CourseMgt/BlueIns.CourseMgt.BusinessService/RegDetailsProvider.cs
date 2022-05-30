namespace BlueIns.CourseMgt.BusinessService
{
    using System.Collections.Generic;
    using BlueIns.CourseMgt.DataAccessLayer.Abstractions.Repository;
    using BlueIns.CourseMgt.DomainModel;
    using BlueIns.CourseMgt.DomainModel.Abstractions;

    /// <summary>
    /// This Business service or provider class which pass value to Repository.
    /// </summary>
    public class RegDetailsProvider : IRegDetailsProvider
    {
        private readonly IRegDetailsRepository _regDetailsRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="RegDetailsProvider"/> class.
        /// </summary>
        /// <param name="regDetailsRepository">dddd.</param>
        public RegDetailsProvider(IRegDetailsRepository regDetailsRepository)
        {
            this._regDetailsRepository = regDetailsRepository;
        }

        /// <summary>
        /// This method is for creating the task.
        /// </summary>
        /// <param name="regDetailsDomain">Domain model parameter.</param>
        /// <returns>It returs domain model values.</returns>
        public RegDetailsDomain CreateRegDetails(RegDetailsDomain regDetailsDomain)
        {
            return this._regDetailsRepository.CreateRegDetails(regDetailsDomain);
        }

        /// <summary>
        /// This method is for deleting a selected task.
        /// </summary>
        /// <param name="regId">Reg Id parameter for deletion.</param>
        /// <returns>It returs domain model values.</returns>
        public bool DeleteRegdetails(int regId)
        {
            return this._regDetailsRepository.DeleteRegDetails(regId);
        }

        public bool DeleteRegDetails(int id)
        {
            return this._regDetailsRepository.DeleteRegDetails(id);
        }

        /// <summary>
        /// This method is for fetching all task details.
        /// </summary>
        /// <returns>Returns the Student details.</returns>
        public IEnumerable<RegDetailsDomain> GetRegDetailsByStudentId(int studentId)
        {
            return this._regDetailsRepository.GetRegDetailsByStudentId(studentId);
        }

        /// <summary>
        /// This method is for fetching single task details.
        /// </summary>
        /// <param name="regId">Reg Id parameter for deletion.</param>
        /// <returns>Returns single Student details based on student id.</returns>
        public RegDetailsDomain GetRegDetailsById(int regId)
        {
            return this._regDetailsRepository.GetRegDetailsById(regId);
        }

        /// <summary>
        /// This method is for fetching single task details.
        /// </summary>
        /// <param name="regName">Course Id parameter for deletion.</param>
        /// <returns>Returns single Student details based on student id.</returns>
        //public RegDetailsDomain GetRegDetailsByName(string regName)
        //{
        //    return this._regDetailsRepository.GetRegDetailsByName(regName);
        //}

        /// <summary>
        /// This method is for updating the task.
        /// </summary>
        /// <param name="regDetailsDomain">Domain model parameter.</param>
        /// <returns>It returs domain model values.</returns>
        public RegDetailsDomain UpdateRegDetails(RegDetailsDomain regDetailsDomain)
        {
            return this._regDetailsRepository.UpdateRegDetails(regDetailsDomain);
        }

        
    }
}
