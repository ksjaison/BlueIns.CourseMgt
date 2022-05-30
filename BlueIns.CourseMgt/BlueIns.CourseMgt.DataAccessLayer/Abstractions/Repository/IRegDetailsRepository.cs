namespace BlueIns.CourseMgt.DataAccessLayer.Abstractions.Repository
{
    using System.Collections.Generic;
    using BlueIns.CourseMgt.DomainModel;

    /// <summary>
    /// Repository class interface.
    /// </summary>
    public interface IRegDetailsRepository
    {
        /// /// <summary>
        /// Fetch all Course details.
        /// </summary>
        /// <returns>Returns the Domain model class object.</returns>
        public IEnumerable<RegDetailsDomain> GetRegDetailsByStudentId(int studentId);

        /// <summary>
        /// Fetch Course details using Course Id.
        /// </summary>
        /// <param name="RegId">Course Id parameter.</param>
        /// <returns>Returns the Domain model class object value.</returns>
        RegDetailsDomain GetRegDetailsById(int regId);

        /// <summary>
        /// Fetch Course details using Course Id.
        /// </summary>
        /// <param name="regName">Course Id parameter.</param>
        /// <returns>Returns the Domain model class object value.</returns>
        //RegDetailsDomain GetRegDetailsByName(string regName);

        /// <summary>
        /// Add new Course.
        /// </summary>
        /// <param name="regDetailsDomain">Domain class object.</param>
        /// <returns>Domain class object return after insert value to database.</returns>
        RegDetailsDomain CreateRegDetails(RegDetailsDomain regDetailsDomain);

        /// <summary>
        /// Modify course.
        /// </summary>
        /// <param name="regId">course Id parameter.</param>
        /// <returns>Return true or false status after insert value to database.</returns>
        bool DeleteRegDetails(int regId);

        /// <summary>
        /// Modify course.
        /// </summary>
        /// <param name="regId">course Id parameter.</param>
        /// <returns>Domain class object return after modifying the value to database.</returns>
        RegDetailsDomain UpdateRegDetails(RegDetailsDomain regDetailsDomain);
    }
}
