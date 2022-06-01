using AutoMapper;
using EducationalSystem.ApiModels;
using EducationalSystem.Infrastructure.Entities;
using System.Globalization;

namespace EducationalSystem.Mapper
{
    public class ApiToEntityProfile : Profile
    {
        public ApiToEntityProfile()
        {
            CreateMap<SignUpModel, UserEntity>()
                .ForMember(u => u.UserName, opt => opt.MapFrom(su => su.Email))
                .ForMember(u => u.CreatedDate, opt => opt.MapFrom(su => DateTime.Now));

            CreateMap<UserEntity, UserViewModel>()
                .ForMember(uv => uv.MemberFrom, opt => opt.MapFrom(u => u.CreatedDate))
                .ForMember(uv => uv.Role, opt => opt.MapFrom(u => string.Join(", ", u.UserRoles.Select(x => x.Role.Name))));

            CreateMap<PostCourseModel, CourseEntity>()
                .ForMember(e => e.CreatedDate, opt => opt.MapFrom(pc => DateTime.Now))
                .ForMember(e => e.BeginsAt, opt => opt.MapFrom(pc => new DateTime(2022, 6, 12)))
                .ForMember(e => e.EndAt, opt => opt.MapFrom(pc => new DateTime(2022,9,12)));
                //.ForMember(e => e.BeginsAt, opt => opt.MapFrom(pc => DateTime.ParseExact(pc.BeginsAt, "dd/MM/YYYY", CultureInfo.InvariantCulture)))
                //.ForMember(e => e.EndAt, opt => opt.MapFrom(pc => DateTime.ParseExact(pc.EndAt, "dd/MM/YYYY", CultureInfo.InvariantCulture)));

            CreateMap<PostRegistrationModel, RegistrationEntity>()
                .ForMember(e => e.RegistrationDate, opt => opt.MapFrom(pr => DateTime.Now));
        }
    }
}
