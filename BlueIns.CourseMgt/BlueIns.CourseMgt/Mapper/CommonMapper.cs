namespace BlueIns.CourseMgt.Web.Mapper
{
    using AutoMapper;
    using BlueIns.CourseMgt.DataAccessLayer.Model;
    using BlueIns.CourseMgt.DomainModel;
    using BlueIns.CourseMgt.Web.Models;

    /// <summary>
    /// This class helps auto mapping.
    /// </summary>
    public class CommonMapper : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommonMapper"/> class.
        /// </summary>
        public CommonMapper()
        {
            this.CreateMap<StudentDetailsDto, StudentDetailsViewModel>().ReverseMap();
            this.CreateMap<StudentDetailsDomain, StudentDetailsDto>().ReverseMap();
            this.CreateMap<StudentDetailsDto, StudentDetailsDomain>().ReverseMap();
            this.CreateMap<StudentDetailsDomain, StudentDetailsViewModel>().ReverseMap();

            this.CreateMap<CourseDetailsDto, CourseDetailsViewModel>().ReverseMap();
            this.CreateMap<CourseDetailsDomain, CourseDetailsDto>().ReverseMap();
            this.CreateMap<CourseDetailsDto, CourseDetailsDomain>().ReverseMap();
            this.CreateMap<CourseDetailsDomain, CourseDetailsViewModel>().ReverseMap();

            this.CreateMap<RegDetailsDto, RegDetailsViewModel>().ReverseMap();
            this.CreateMap<RegDetailsViewModel, RegDetailsDomain>().ReverseMap();
            this.CreateMap<RegDetailsDomain, RegDetailsViewModel>().ReverseMap();
            this.CreateMap<RegDetailsDomain, RegDetailsDto>().ReverseMap();
            this.CreateMap<RegDetailsDto, RegDetailsDomain>().ReverseMap();
            

            //this.CreateMap<RegDetailsDto, RegDetailsDomain>()
            //    .ForMember(a => a.CreatedBy, b => b.Ignore())
            //    .ForMember(a => a.UpdatedBy, b => b.Ignore());
            //this.CreateMap<RegDetailsDomain, RegDetailsDto>()
            //    .ForMember(a => a.CreatedBy, b => b.Ignore())
            //    .ForMember(a => a.UpdatedBy, b => b.Ignore());

        }
    }
}
