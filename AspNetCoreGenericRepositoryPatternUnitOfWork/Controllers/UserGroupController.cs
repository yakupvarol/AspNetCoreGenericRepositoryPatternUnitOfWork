using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreGenericRepositoryPatternUnitOfWork.Business;
using AspNetCoreGenericRepositoryPatternUnitOfWork.DTO.Menu;
using AspNetCoreGenericRepositoryPatternUnitOfWork.DTO.UserGroup;
using AspNetCoreGenericRepositoryPatternUnitOfWork.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreGenericRepositoryPatternUnitOfWork.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserGroupController : ControllerBase
    {
        private readonly IUserGroupService _userGroupService;

        public UserGroupController(IUserGroupService userGroupService)
        {
            _userGroupService = userGroupService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            //var All = _userGroupService.All();
            //var IQueryableAsync = await _userGroupService.IQueryableAsync();
            //var AllAsync = await _userGroupService.AllAsync();
            //var GetIdAsync = await _userGroupService.GetIdAsync(1);
            //var FirstAsync = await _userGroupService.FirstAsync(new UserGroupListRequestDTO { Id=1, Name= "Group 1" });
            //var FindWhere = _userGroupService.FindWhere(new UserGroupListRequestDTO { Id = 1, Name = "Group" });
            //var FindWhereAsync = await _userGroupService.FindWhereAsync(new UserGroupListRequestDTO { Id = 1, Name = "Gr" });
            //var Count = _userGroupService.Count(new UserGroupListRequestDTO { Name = "Gr" });
            //var ListAsync = await _userGroupService.ListAsync(new UserGroupListRequestDTO { Isactive=true });
            //var ListByAsync = await _userGroupService.ListByAsync(new UserGroupListRequestDTO { Isactive = true });
            //var ExitByAsync = await _userGroupService.ExitByAsync(new UserGroupListRequestDTO { Id=33838 });
            //var IncludeMany = _userGroupService.IncludeMany(new UserGroupListRequestDTO { Isactive=true });
            //var IncludeAsync = await _userGroupService.IncludeAsync(new UserGroupListRequestDTO { Isactive=true });
            //var IncludeWhereIfAsync = await _userGroupService.IncludeWhereIfAsync(new UserGroupListRequestDTO { Isactive = true });
            //var DistinctAsync = await _userGroupService.DistinctAsync();
            //var GetSQLAsync = await _userGroupService.GetSQLAsync(new UserGroupListRequestDTO { Isactive = true });
            //var GetSQL = _userGroupService.GetIdSQL(new UserGroupListRequestDTO { Id = 1 });
            //var SelectObjectAsync = _userGroupService.SelectObjectAsync(new UserGroupListRequestDTO { Id = 1 });
            //var GroupJoinBy = _userGroupService.GroupJoinBy();
            //var JoinBy = _userGroupService.JoinBy();
            //var SelectManyBy = _userGroupService.SelectManyBy();
            //var GroupBy = _userGroupService.GroupBy();
            //var AuthorizationUserGroupEdit = _userGroupService.AuthorizationUserGroupEdit(new MenuUserGroupAuthorizationRequestDTO { Groupid = 1012 });
            //var SumByAsync = await _userGroupService.SumByAsync();
            //_userGroupService.Other();
            //var ThenInclude = _userGroupService.ThenInclude();
            //var SkipTake = _userGroupService.SkipTake();
            //var ThenByDescending = _userGroupService.ThenByDescending();
            //var AllBoolAsync = await _userGroupService.AllBoolAsync();
            //var SingleBy = _userGroupService.BySingle();


            return Ok();
        }

        public async Task<IActionResult> InsertAsync()
        {
            //var InsertDTOAsync = await _userGroupService.InsertDTOAsync(new UserGroupCreateEditDTO { Name = "Eyüp Ensar", Rank = "15" });
            //var OneSaveDTO=  _userGroupService.OneSaveDTO(new UserGroupCreateEditDTO { Name = "Eyüp Ensar", Rank = "15" });
            //var OneSaveAsync = await _userGroupService.OneSaveAsync(new UserGroup { Name = "Nehir Zümra", Rank = "25", Isactive = true, IsautomaticCategory = true, Isdelete = false });
            //var OneSaveDTO = await _userGroupService.SaveManyAsync(new UserGroupCreateEditDTO { Name = "Eyüp Ensar", Rank = "15" });

            /*
            // AddRange
            var dt = new List<UserGroup>
            {
                new UserGroup { Name = "Eyüp Ensar 1", Rank = "151" },
                new UserGroup { Name = "Eyüp Ensar 2", Rank = "152" },
                new UserGroup { Name = "Eyüp Ensar 3", Rank = "153" },
                new UserGroup { Name = "Eyüp Ensar 4", Rank = "154" }
            };
            var SaveRange = _userGroupService.SaveRange(dt);
            */


            /*
            // AddRangeAsync
            var dt = new List<UserGroupCreateEditDTO>
            {
               new UserGroupCreateEditDTO { Name = "Eyüp Ensar 11", Rank = "2151" },
               new UserGroupCreateEditDTO { Name = "Eyüp Ensar 12", Rank = "2152" },
               new UserGroupCreateEditDTO { Name = "Eyüp Ensar 13", Rank = "2153" },
               new UserGroupCreateEditDTO { Name = "Eyüp Ensar 14", Rank = "2154" }
            };
            var SaveRangeDTOAsync = await _userGroupService.SaveRangeDTOAsync(dt);
            */


            /*
            // OneToManySaveAsync
            var dt = new UserGroup { Name = "Eyüp Ensar 1", Rank = "151", 
                UserAuthorizations = new List<UserAuthorization> 
                { 
                    new UserAuthorization { Isdelete = true, BakendMenuId=1, Issave = true, Islist = false, Isupdate = true },
                    new UserAuthorization { Isdelete = true, BakendMenuId=2, Issave = true, Islist = true, Isupdate = false },
                }
            };
            var OneToManySaveAsync = await _userGroupService.OneToManySaveAsync(dt);
           */


            /*
            // ManyToManySaveAsync
            var dt = new List<UserGroup>
            {
                new UserGroup { Name = "Eyüp Ensar 12", Rank = "751", UserAuthorizations = new List<UserAuthorization> { new UserAuthorization { Isdelete = true, BakendMenuId=1, Issave = true, Islist = false, Isupdate = true }, new UserAuthorization { Isdelete = true, BakendMenuId=2, Issave = true, Islist = true, Isupdate = false } } },
                new UserGroup { Name = "Eyüp Ensar 2", Rank = "851", UserAuthorizations = new List<UserAuthorization> { new UserAuthorization { Isdelete = true, BakendMenuId=1, Issave = true, Islist = false, Isupdate = true }, new UserAuthorization { Isdelete = true, BakendMenuId=2, Issave = true, Islist = true, Isupdate = false } } },
            };
            var ManyToManySaveAsync = await _userGroupService.ManyToManySaveAsync(dt);
            */

            return Ok();
        }

        public async Task<IActionResult> UpdateAsync()
        {
            //var UpdateDTO = _userGroupService.UpdateDTO(new UserGroupCreateEditDTO {Id= 4227, Name = "Eyüp Ensar", Rank = "15" });
            //var OneUpdate = _userGroupService.OneUpdate(new UserGroupCreateEditDTO { Id = 4224, Name = "Zümra 9", Rank = "15" });
            //var OneUpdateAsync = await _userGroupService.OneUpdateAsync(new UserGroupCreateEditDTO { Id = 4227, Name = "Eyüp 3", Rank = "15" });
            //var UpdateBase= _userGroupService.UpdateBase(new UserGroupCreateEditDTO { Id = 4227, Name = "Nehir Zümra", Rank = "15" });
            //var UpdateModel = _userGroupService.UpdateModel(new UserGroup { Id = 4227, Name = "Nehir Zümra", Rank = "15", Isactive=true, IsautomaticCategory=false, Isdelete=true });

            /*
            // AddRange
            var dt = new List<UserGroup>
            {
                new UserGroup { Id=4216, Name = "Eyüp 1", Rank = "1" },
                new UserGroup { Id=4217, Name = "Eyüp 2", Rank = "2" },
                new UserGroup { Id=4218, Name = "Eyüp 3", Rank = "3" },
                new UserGroup { Id=4219, Name = "Eyüp 4", Rank = "4" }
            };
            var UpdateRangeBy = _userGroupService.UpdateRangeBy(dt);
            */


            /*
            // Update Many
            var dt = new List<UserGroup>
            {
                new UserGroup { Id=4216, Name = "1Eyüp 1", Rank = "1", Isactive=true, IsautomaticCategory=false, Isdelete=true },
                new UserGroup { Id=4217, Name = "2Eyüp 2", Rank = "2", Isactive=true, IsautomaticCategory=false, Isdelete=true },
                new UserGroup { Id=4218, Name = "3Eyüp 3", Rank = "3", Isactive=true, IsautomaticCategory=false, Isdelete=true },
                new UserGroup { Id=4219, Name = "4Eyüp 4", Rank = "4", Isactive=true, IsautomaticCategory=false, Isdelete=true }
            };
            var UpdateMany = _userGroupService.UpdateMany(dt);
            */

            /*
            // Update Many
            var dt = new List<UserGroupCreateEditDTO>
            {
                new UserGroupCreateEditDTO { Id=4216, Name = "Eyüp 11", Rank = "11" },
                new UserGroupCreateEditDTO { Id=4217, Name = "Eyüp 21", Rank = "21"},
                new UserGroupCreateEditDTO { Id=4218, Name = "Eyüp 31", Rank = "31"},
                new UserGroupCreateEditDTO { Id=4219, Name = "Eyüp 41", Rank = "14"}
            };
            var UpdateManyDTOAsync = await _userGroupService.UpdateManyDTOAsync(dt);
            */

            /*
            // OneToManyUpdateAsync
            var dt = new UserGroup {Id= 4227, Name = "Eyüp Ensar 1", Rank = "151", Isdelete=true, Isactive=true, IsautomaticCategory=false,
                UserAuthorizations = new List<UserAuthorization> 
                { 
                    new UserAuthorization { Isdelete = true, BakendMenuId=1, Issave = true, Islist = false, Isupdate = true },
                    new UserAuthorization { Isdelete = true, BakendMenuId=2, Issave = true, Islist = true, Isupdate = false },
                }
            };
            var OneToManyUpdateAsync = await _userGroupService.OneToManyUpdateAsync(dt);
            */


            /*           
            // ManyToManyUpdateAsync
            var dt = new List<UserGroup>
            {
                new UserGroup {Id= 4224, Name = "1 Eyüp Ensar 12", Rank = "751", UserAuthorizations = new List<UserAuthorization> { new UserAuthorization { Isdelete = true, BakendMenuId=1, Issave = true, Islist = false, Isupdate = true }, new UserAuthorization { Isdelete = true, BakendMenuId=2, Issave = true, Islist = true, Isupdate = false } } },
                new UserGroup {Id= 4227, Name = "2 Eyüp Ensar 2", Rank = "851", UserAuthorizations = new List<UserAuthorization> { new UserAuthorization { Isdelete = true, BakendMenuId=1, Issave = true, Islist = false, Isupdate = true }, new UserAuthorization { Isdelete = true, BakendMenuId=2, Issave = true, Islist = true, Isupdate = false } } },
            };
            var ManyToManySaveAsync = await _userGroupService.ManyToManyUpdateAsync(dt);
            */

            return Ok();
        }

        public async Task<IActionResult> DeleteAsync()
        {

            //var DeleteModel = _userGroupService.DeleteModel(new UserGroup { Id = 4041 });
            //var RemoveModel = _userGroupService.RemoveModel(new UserGroup { Id = 4227 });
            //_userGroupService.FindAndRemoveBy(4013);
            //var FindAndRemoveDTOByAsync = await _userGroupService.FindAndRemoveDTOByAsync(new UserGroupListRequestDTO { Id= 4040, Isactive= true } );

            /*
            // DeleteRange
            var dt = new List<UserGroup>
            {
               new UserGroup { Id=4037 },
               new UserGroup { Id=4038},
               new UserGroup { Id=4039},
               new UserGroup { Id=4043}
            };
            var RemoveRangeBy = _userGroupService.RemoveRangeBy(dt);
            */

            return Ok();
        }
    }
}