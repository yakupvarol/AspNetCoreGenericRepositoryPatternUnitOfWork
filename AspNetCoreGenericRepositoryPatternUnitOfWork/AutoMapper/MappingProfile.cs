using AspNetCoreGenericRepositoryPatternUnitOfWork.DTO.Mapper;
using AspNetCoreGenericRepositoryPatternUnitOfWork.DTO.UserGroup;
using AspNetCoreGenericRepositoryPatternUnitOfWork.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreGenericRepositoryPatternUnitOfWork.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // CreateMap<UserListResponseDTO, User>().ReverseMap().ForMember(dest => dest.FullName, from => from.MapFrom(s => s.FirstName + " " + s.LastName));
            CreateMap<UserGroup, UserGroupListResponseDTO>().ReverseMap();
            CreateMap<UserGroup, UserGroupCreateEditDTO>().ReverseMap();
            CreateMap<UserGroup, MapperUserGroupListResponseDTO>();
            CreateMap<User, MapperUserListResponseDTO>();
            CreateMap<UserAuthorization, MapperMenuUserAuthorizationListDTO>();
        }
    }
}
