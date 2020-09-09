using AspNetCoreGenericRepositoryPatternUnitOfWork.Core.EFRepository;
using AspNetCoreGenericRepositoryPatternUnitOfWork.DTO.Mapper;
using AspNetCoreGenericRepositoryPatternUnitOfWork.DTO.Menu;
using AspNetCoreGenericRepositoryPatternUnitOfWork.DTO.UserGroup;
using AspNetCoreGenericRepositoryPatternUnitOfWork.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreGenericRepositoryPatternUnitOfWork.Data
{
    public interface IUserGroupDal: IEntityRepository<UserGroup>
    {
        IQueryable<UserGroupListResponseDTO> All();
        Task<IEnumerable<UserGroupListResponseDTO>> IQueryableAsync();
        Task<IEnumerable<UserGroupListResponseDTO>> AllAsync();
        Task<UserGroup> GetIdAsync(int id);
        Task<UserGroupListResponseDTO> FirstAsync(UserGroupListRequestDTO src);
        IQueryable<UserGroup> FindWhere(UserGroupListRequestDTO src);
        Task<IEnumerable<UserGroupListResponseDTO>> FindWhereAsync(UserGroupListRequestDTO src);
        Task<IList<UserGroupListResponseDTO>> ListAsync(UserGroupListRequestDTO src);
        Task<ICollection<UserGroupListResponseDTO>> ListByAsync(UserGroupListRequestDTO src);
        object Count(UserGroupListRequestDTO src);
        Task<bool> ExitByAsync(UserGroupListRequestDTO src);
        Task<IList<UserGroupListResponseDTO>> DistinctAsync();
        Task<IEnumerable<UserGroupListResponseDTO>> GetSQLAsync(UserGroupListRequestDTO src);
        UserGroupListResponseDTO GetIdSQL(UserGroupListRequestDTO src);
        IQueryable<object> SelectObjectAsync(UserGroupListRequestDTO src);

        IQueryable<MapperUserGroupListResponseDTO> IncludeMany(UserGroupListRequestDTO src);
        Task<IEnumerable<UserGroup>> IncludeAsync(UserGroupListRequestDTO src);
        Task<IEnumerable<UserGroup>> IncludeWhereIfAsync(UserGroupListRequestDTO src);
        IQueryable<UserGroup> SkipTake();
        IQueryable<UserGroup> ThenByDescending();
        IQueryable<UserGroup> ThenInclude();
        IQueryable<object> GroupJoinBy();
        IQueryable<object> JoinBy();
        IQueryable<object> SelectManyBy();
        IQueryable<object> GroupBy();
        Task<int> SumByAsync();
        void Other();
        IQueryable<MenuUserAuthorizationListDTO> AuthorizationUserGroupEdit(MenuUserGroupAuthorizationRequestDTO src);


        int OneSaveDTO(UserGroupCreateEditDTO dt);
        Task<int> OneSaveAsync(UserGroup dt);
        Task<bool> SaveManyAsync(UserGroupCreateEditDTO dt);
        IEnumerable<UserGroup> SaveRange(IList<UserGroup> dt);
        Task<IEnumerable<UserGroup>> SaveRangeDTOAsync(IList<UserGroupCreateEditDTO> dt);
        Task<int> OneToManySaveAsync(UserGroup dt);
        Task<bool> ManyToManySaveAsync(IList<UserGroup> dt);
        Task<int> InsertDTOAsync(UserGroupCreateEditDTO dt);


        int UpdateDTO(UserGroupCreateEditDTO dt);
        bool OneUpdate(UserGroupCreateEditDTO dt);
        Task<bool> OneUpdateAsync(UserGroupCreateEditDTO dt);
        bool UpdateBase(UserGroupCreateEditDTO dt);
        IEnumerable<UserGroup> UpdateRangeBy(IList<UserGroup> dt);
        UserGroup UpdateModel(UserGroup dt);
        bool UpdateMany(IList<UserGroup> dt);
        Task<bool> UpdateManyDTOAsync(IList<UserGroupCreateEditDTO> dt);
        Task<int> OneToManyUpdateAsync(UserGroup dt);
        Task<bool> ManyToManyUpdateAsync(IList<UserGroup> dt);

        bool DeleteModel(UserGroup dt);
        bool RemoveModel(UserGroup dt);
        int RemoveRangeBy(IList<UserGroup> dt);
        void FindAndRemoveBy(int id);
        Task<bool> FindAndRemoveDTOByAsync(UserGroupListRequestDTO src);

        Task<bool> AllBoolAsync();
        UserGroup BySingle();
    }
}
