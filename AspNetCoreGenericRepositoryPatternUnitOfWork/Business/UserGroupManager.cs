using AspNetCoreGenericRepositoryPatternUnitOfWork.Data;
using AspNetCoreGenericRepositoryPatternUnitOfWork.DTO.Mapper;
using AspNetCoreGenericRepositoryPatternUnitOfWork.DTO.Menu;
using AspNetCoreGenericRepositoryPatternUnitOfWork.DTO.UserGroup;
using AspNetCoreGenericRepositoryPatternUnitOfWork.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreGenericRepositoryPatternUnitOfWork.Business
{
    public class UserGroupManager : IUserGroupService
    {
        private IUserGroupDal _userGroupDal;
      
        public UserGroupManager(IUserGroupDal userGroupDal)
        {
            _userGroupDal = userGroupDal;
        }

        public IList<UserGroupListResponseDTO> All()
        {
            return _userGroupDal.All().ToList();
        }

        public async Task<IEnumerable<UserGroupListResponseDTO>> AllAsync()
        {
            return await _userGroupDal.AllAsync();
        }

        public IEnumerable<MenuUserAuthorizationListDTO> AuthorizationUserGroupEdit(MenuUserGroupAuthorizationRequestDTO src)
        {
            return _userGroupDal.AuthorizationUserGroupEdit(src);
        }

        public object Count(UserGroupListRequestDTO src)
        {
            return _userGroupDal.Count(src);
        }

        public async Task<IList<UserGroupListResponseDTO>> DistinctAsync()
        {
            return await _userGroupDal.DistinctAsync();
        }

        public Task<bool> ExitByAsync(UserGroupListRequestDTO src)
        {
            return _userGroupDal.ExitByAsync(src);
        }

        public IEnumerable<UserGroup> FindWhere(UserGroupListRequestDTO src)
        {
            return _userGroupDal.FindWhere(src);
        }

        public Task<IEnumerable<UserGroupListResponseDTO>> FindWhereAsync(UserGroupListRequestDTO src)
        {
            return _userGroupDal.FindWhereAsync(src);
        }

        public async Task<UserGroupListResponseDTO> FirstAsync(UserGroupListRequestDTO src)
        {
            return await _userGroupDal.FirstAsync(src);
        }

        public async Task<UserGroup> GetIdAsync(int id)
        {
            return await _userGroupDal.GetIdAsync(id);
        }

        public UserGroupListResponseDTO GetIdSQL(UserGroupListRequestDTO src)
        {
            return _userGroupDal.GetIdSQL(src);
        }

        public Task<IEnumerable<UserGroupListResponseDTO>> GetSQLAsync(UserGroupListRequestDTO src)
        {
            return _userGroupDal.GetSQLAsync(src);
        }

        public IEnumerable<object> GroupBy()
        {
            return _userGroupDal.GroupBy();
        }

        public IEnumerable<object> GroupJoinBy()
        {
            return _userGroupDal.GroupJoinBy();
        }

        public async Task<IEnumerable<UserGroup>> IncludeAsync(UserGroupListRequestDTO src)
        {
            return await _userGroupDal.IncludeAsync(src);
        }

        public IEnumerable<MapperUserGroupListResponseDTO> IncludeMany(UserGroupListRequestDTO src)
        {
            return _userGroupDal.IncludeMany(src);
        }

        public Task<IEnumerable<UserGroup>> IncludeWhereIfAsync(UserGroupListRequestDTO src)
        {
            return _userGroupDal.IncludeWhereIfAsync(src);
        }

        public async Task<int> InsertDTOAsync(UserGroupCreateEditDTO dt)
        {
            return await _userGroupDal.InsertDTOAsync(dt);
        }

        public async Task<IEnumerable<UserGroupListResponseDTO>> IQueryableAsync()
        {
            return await _userGroupDal.IQueryableAsync();
        }

        public IEnumerable<object> JoinBy()
        {
            return _userGroupDal.JoinBy();
        }

        public async Task<IList<UserGroupListResponseDTO>> ListAsync(UserGroupListRequestDTO src)
        {
            return await _userGroupDal.ListAsync(src);
        }

        public async Task<ICollection<UserGroupListResponseDTO>> ListByAsync(UserGroupListRequestDTO src)
        {
            return await _userGroupDal.ListByAsync(src);
        }

        public async Task<bool> ManyToManySaveAsync(IList<UserGroup> dt)
        {
            return await _userGroupDal.ManyToManySaveAsync(dt);
        }

        public async Task<int> OneSaveAsync(UserGroup dt)
        {
            return await _userGroupDal.OneSaveAsync(dt);
        }

        public int OneSaveDTO(UserGroupCreateEditDTO dt)
        {
            return _userGroupDal.OneSaveDTO(dt);
        }

        public async Task<int> OneToManySaveAsync(UserGroup dt)
        {
            return await _userGroupDal.OneToManySaveAsync(dt);
        }

        public void Other()
        {
            _userGroupDal.Other();
        }

        public async Task<bool> SaveManyAsync(UserGroupCreateEditDTO dt)
        {
            return await _userGroupDal.SaveManyAsync(dt);
        }

        public IEnumerable<UserGroup> SaveRange(IList<UserGroup> dt)
        {
            return _userGroupDal.SaveRange(dt);
        }

        public async Task<IEnumerable<UserGroup>> SaveRangeDTOAsync(IList<UserGroupCreateEditDTO> dt)
        {
            return await _userGroupDal.SaveRangeDTOAsync(dt);
        }

        public IEnumerable<object> SelectManyBy()
        {
            return _userGroupDal.SelectManyBy();
        }

        public IEnumerable<object> SelectObjectAsync(UserGroupListRequestDTO src)
        {
            return _userGroupDal.SelectObjectAsync(src).ToList();
        }

        public async Task<int> SumByAsync()
        {
            return await _userGroupDal.SumByAsync();
        }



        public int UpdateDTO(UserGroupCreateEditDTO dt)
        {
            return _userGroupDal.UpdateDTO(dt);
        }

        public async Task<bool> OneUpdateAsync(UserGroupCreateEditDTO dt)
        {
            return await _userGroupDal.OneUpdateAsync(dt);
        }

        public bool OneUpdate(UserGroupCreateEditDTO dt)
        {
            return _userGroupDal.OneUpdate(dt);
        }

        public bool UpdateBase(UserGroupCreateEditDTO dt)
        {
            return _userGroupDal.UpdateBase(dt);
        }

        public IEnumerable<UserGroup> UpdateRangeBy(IList<UserGroup> dt)
        {
            return _userGroupDal.UpdateRangeBy(dt);
        }

        public bool UpdateMany(IList<UserGroup> dt)
        {
            return _userGroupDal.UpdateMany(dt);
        }

        public async Task<bool> UpdateManyDTOAsync(IList<UserGroupCreateEditDTO> dt)
        {
            return await _userGroupDal.UpdateManyDTOAsync(dt);
        }

        public UserGroup UpdateModel(UserGroup dt)
        {
            return _userGroupDal.UpdateModel(dt);
        }

        public async Task<int> OneToManyUpdateAsync(UserGroup dt)
        {
            return await _userGroupDal.OneToManyUpdateAsync(dt);
        }

        public async Task<bool> ManyToManyUpdateAsync(IList<UserGroup> dt)
        {
            return await _userGroupDal.ManyToManyUpdateAsync(dt);
        }

        public bool DeleteModel(UserGroup dt)
        {
            return _userGroupDal.DeleteModel(dt);
        }

        public bool RemoveModel(UserGroup dt)
        {
            return _userGroupDal.RemoveModel(dt);
        }

        public int RemoveRangeBy(IList<UserGroup> dt)
        {
            return _userGroupDal.RemoveRangeBy(dt);
        }

        public void FindAndRemoveBy(int id)
        {
            _userGroupDal.FindAndRemoveBy(id);
        }

        public Task<bool> FindAndRemoveDTOByAsync(UserGroupListRequestDTO src)
        {
            return _userGroupDal.FindAndRemoveDTOByAsync(src);
        }

        public IEnumerable<UserGroup> ThenInclude()
        {
            return _userGroupDal.ThenInclude();
        }

        public IEnumerable<UserGroup> SkipTake()
        {
            return _userGroupDal.SkipTake();
        }

        public IEnumerable<UserGroup> ThenByDescending()
        {
            return _userGroupDal.ThenByDescending();
        }

        public async Task<bool> AllBoolAsync()
        {
            return await _userGroupDal.AllBoolAsync();
        }

        public UserGroup BySingle()
        {
            return _userGroupDal.BySingle();
        }
    }
}
