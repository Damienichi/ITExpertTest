using AutoMapper;
using ITExpertTest.Commands;
using ITExpertTest.Extensions;
using ITExpertTest.Models.Dtos;
using ITExpertTest.Models.Entities;
using ITExpertTest.Responses;
using Microsoft.OpenApi.Extensions;

namespace ITExpertTest.Mapping;

public class TodoMappingProfile: Profile
{
    public TodoMappingProfile()
    {
        CreateMap<Todo, TodoDto>(MemberList.Destination)
            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.GetDisplayName()))
            .ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.Color.GetDisplayName()))
            .ForMember(dest => dest.Hash, opt => opt.MapFrom(src => src.GetMd5HashFromTitle()));
        
        CreateMap<Todo, TodoResponse>(MemberList.Destination);
        
        CreateMap<CreateTodoCommand, Todo>(MemberList.Destination)
            .ForMember(dest => dest.CreationDate, opt => opt.MapFrom(src => DateTime.UtcNow));
    }
}