using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;

namespace QuizSever
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Questions, QuestionDto>();
            CreateMap<Quiz, QuizDto>();
            CreateMap<QuizForCreationDto, Quiz>();
            CreateMap<QuestionForCreationsDto, Questions>();
            CreateMap<UserDto, User>();
        }
    }
}