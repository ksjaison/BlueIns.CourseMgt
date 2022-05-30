namespace BlueIns.CourseMgt.DomainModel.Abstractions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IRegDetailsProvider
    {
        public IEnumerable<RegDetailsDomain> GetRegDetailsByStudentId(int studentId);

        RegDetailsDomain GetRegDetailsById(int id);
        //RegDetailsDomain GetRegDetailsByName(string courseName);

        RegDetailsDomain CreateRegDetails(RegDetailsDomain regDetails);

        bool DeleteRegDetails(int id);

        RegDetailsDomain UpdateRegDetails(RegDetailsDomain regDetails);

    }
}
