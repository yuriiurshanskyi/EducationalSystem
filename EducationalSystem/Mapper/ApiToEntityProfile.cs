using AutoMapper;
using EducationalSystem.ApiModels;
using EducationalSystem.Infrastructure.Entities;

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
                .ForMember(uv => uv.MemberFrom, opt => opt.MapFrom(u => u.CreatedDate));

            CreateMap<PostCourseModel, CourseEntity>()
                .ForMember(e => e.CreatedDate, opt => opt.MapFrom(pc => DateTime.Now));

            CreateMap<PostRegistrationModel, RegistrationEntity>()
                .ForMember(e => e.RegistrationDate, opt => opt.MapFrom(pr => DateTime.Now));
        }
    }
}
