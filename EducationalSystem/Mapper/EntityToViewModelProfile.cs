using AutoMapper;
using EducationalSystem.ApiModels;
using EducationalSystem.Infrastructure.Entities;

namespace EducationalSystem.Mapper
{
    public class EntityToViewModelProfile : Profile
    {
        public EntityToViewModelProfile()
        {
            CreateMap<CategoryEntity, CategoryViewModel>();

            CreateMap<CourseEntity, CourseViewModel>()
                .ForMember(c => c.Creator, opt => opt.MapFrom(e => e.CreatedBy))
                .ForMember(c => c.CreatedAt, opt => opt.MapFrom(e => e.CreatedDate))
                .ForMember(c => c.Category, opt => opt.MapFrom(e => e.Category))
                .ReverseMap();

            CreateMap<RegistrationEntity, RegistrationViewModel>()
                .ForMember(vm => vm.Course, opt => opt.MapFrom(e => e.Course));

            CreateMap<UserEntity, CreatorViewModel>()
                .ForMember(c => c.UserId, opt => opt.MapFrom(u => u.Id));
        }
    }
}
