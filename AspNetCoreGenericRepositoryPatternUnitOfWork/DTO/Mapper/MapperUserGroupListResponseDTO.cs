using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static AspNetCoreGenericRepositoryPatternUnitOfWork.DTO.Mapper.MapperUserListResponseDTO;

namespace AspNetCoreGenericRepositoryPatternUnitOfWork.DTO.Mapper
{
    public class MapperUserGroupListResponseDTO
    {
        //public MapperUserGroupListResponseDTO()
        //{
        //    Users = new List<MapperUserListResponseDTO>();
        //}
        public int Id { get; set; }
        public string Name { get; set; }
        public int Code { get; set; }
        public bool Isactive { get; set; }
        public bool Isdelete { get; set; }
        public int Count { get; set; }
        public virtual IList<MapperUserListResponseDTO> Users { get; set; } = new List<MapperUserListResponseDTO>();
        public virtual IList<MapperMenuUserAuthorizationListDTO> UserAuthorizations { get; set; } = new List<MapperMenuUserAuthorizationListDTO>();
    }
}
