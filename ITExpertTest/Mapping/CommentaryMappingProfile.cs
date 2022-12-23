using AutoMapper;
using ITExpertTest.Commands;
using ITExpertTest.Models.Dtos;
using ITExpertTest.Models.Entities;

namespace ITExpertTest.Mapping;

public class CommentaryMappingProfile: Profile
{
    public CommentaryMappingProfile()
    {
        CreateMap<Commentary, CommentaryDto>(MemberList.Destination);
        CreateMap<AddCommentaryToTodoByIdCommand, Commentary>(MemberList.Source);
    }
}