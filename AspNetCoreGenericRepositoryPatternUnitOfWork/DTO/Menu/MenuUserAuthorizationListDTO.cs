using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreGenericRepositoryPatternUnitOfWork.DTO.Menu
{
    public class MenuUserAuthorizationListDTO
    {
        public int BakendMenuId { get; set; }
        public int Groupid { get; set; }
        public string Name { get; set; }
        public bool Issave { get; set; }
        public bool Isupdate { get; set; }
        public bool Islist { get; set; }
        public bool Isdelete { get; set; }
    }
}
