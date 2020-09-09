using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreGenericRepositoryPatternUnitOfWork.DTO.UserGroup
{
    public class UserGroupListRequestDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Isactive { get; set; }
    }
}
