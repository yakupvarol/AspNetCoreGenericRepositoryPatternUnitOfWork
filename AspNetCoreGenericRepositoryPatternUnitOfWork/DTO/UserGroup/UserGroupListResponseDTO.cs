using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreGenericRepositoryPatternUnitOfWork.DTO.UserGroup
{
    public class UserGroupListResponseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Code { get; set; }
        public bool Isactive { get; set; }
        public bool Isdelete { get; set; }
        public int Count { get; set; }
    }
}
