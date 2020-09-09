using AspNetCoreGenericRepositoryPatternUnitOfWork.Core.EFRepository;
using AspNetCoreGenericRepositoryPatternUnitOfWork.DTO.Mapper;
using AspNetCoreGenericRepositoryPatternUnitOfWork.DTO.Menu;
using AspNetCoreGenericRepositoryPatternUnitOfWork.DTO.UserGroup;
using AspNetCoreGenericRepositoryPatternUnitOfWork.Entities;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreGenericRepositoryPatternUnitOfWork.Data
{
    public class EfUserGroupDal : EfEntityRepositoryBase<UserGroup, EFContext>, IUserGroupDal
    {
        // https://www.tutorialsteacher.com/linq/linq-partitioning-operators-take-takewhile
        // https://entityframeworkcore.com/querying-data-include-theninclude
        // https://www.learnentityframeworkcore.com/model
        // https://www.entityframeworktutorial.net/efcore/conventions-in-ef-core.aspx
        // https://entityframework.net/include-with-where-clause

        private readonly IMapper _mapper;
        private readonly EFContext _context;

        public EfUserGroupDal(IMapper mapper, EFContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public IQueryable<UserGroupListResponseDTO> All()
        {
            return GetAllBy().ProjectTo<UserGroupListResponseDTO>(_mapper.ConfigurationProvider);
        }

        public async Task<IEnumerable<UserGroupListResponseDTO>> IQueryableAsync()
        {
            return await GetAllBy().ProjectTo<UserGroupListResponseDTO>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<IEnumerable<UserGroupListResponseDTO>> AllAsync()
        {
            return _mapper.Map<IEnumerable<UserGroupListResponseDTO>>(await GetAllIEnumerableAsync());
        }

        public async Task<UserGroup> GetIdAsync(int id)
        {
            return await GetByIdAsync(id);
        }

        public IQueryable<object> SelectObjectAsync(UserGroupListRequestDTO src)
        {
            return FindBy(x => x.Id == src.Id).Select(q => new { Id = q.Id, Name = q.Name, UserCount = q.Users.Count() });
        }

        public async Task<UserGroupListResponseDTO> FirstAsync(UserGroupListRequestDTO src)
        {
            return _mapper.Map<UserGroupListResponseDTO>(await FirstByAsync(x=> x.Id== src.Id &&  x.Name== src.Name));
        }

        public IQueryable<UserGroup> FindWhere(UserGroupListRequestDTO src)
        {
            return FindBy(x=> x.Id== src.Id || x.Name.Contains(src.Name)).OrderBy(x=> x.Name).OrderByDescending(x=> x.Id);
        }

        public async Task<IEnumerable<UserGroupListResponseDTO>> FindWhereAsync(UserGroupListRequestDTO src)
        {
            return _mapper.Map<IEnumerable<UserGroupListResponseDTO>>((await FindByIEnumerableAsync(x => x.Id == src.Id || x.Name.Contains(src.Name))).OrderByDescending(x => x.Name).OrderByDescending(x => x.Id));
        }

        public async Task<IList<UserGroupListResponseDTO>> ListAsync(UserGroupListRequestDTO src)
        {
            return _mapper.Map<IList<UserGroupListResponseDTO>>((await FindByIListAsync(x => x.Isactive == src.Isactive)).OrderByDescending(x => x.Name));
        }

        public async Task<ICollection<UserGroupListResponseDTO>> ListByAsync(UserGroupListRequestDTO src)
        {
            return _mapper.Map<ICollection<UserGroupListResponseDTO>>((await FindByIListAsync(x => x.Isactive == src.Isactive)).Select(x=> new UserGroupListResponseDTO { Id= x.Id, Name= x.Name }));
        }

        public IQueryable<UserGroup> FindWhereIf(UserGroupListRequestDTO src)
        {
            return FindBy(c => ((src.Id == 0) || c.Id == src.Id) && ((src.Name == null) || c.Name == src.Name)).OrderBy(x => x.Name).OrderByDescending(x => x.Id);
        }

        public object Count(UserGroupListRequestDTO src)
        {
            return CountByFind(x => x.Name.Contains(src.Name));
        }

        public async Task<bool> ExitByAsync(UserGroupListRequestDTO src)
        {
            // Isactive alanındaki verilerden bir tanesi bile, true ise sonuç true, hepsi false ise false döner
            //return await AnyByAsync(x => x.Id == src.Id);
            return await AnyByAsync(x => x.Isactive == true);
        }

        public IQueryable<MapperUserGroupListResponseDTO> IncludeMany(UserGroupListRequestDTO src)
        {
            //var aa = FindBy(x => x.Id == src.Id && x.LngId == src.lngid).Where(c => c.Contents.Any(i => i.IsActive == true)).OrderByDescending(x => x.Id).ThenBy(x => x.Contents.OrderByDescending(y => y.Id)).ProjectTo<CategoryDTO.ResponseList>(_mapper.ConfigurationProvider);
           /*
            var bb = FindBy(x => x.Id == src.Id && x.LngId == src.lngid).Where(c => c.Contents.Any(i => i.IsActive == true))
                .Select(x => new CategoryDTO.ResponseList
                {
                    Contents = x.Contents.Where(y => y.Id == 66).OrderByDescending(y => y.Id).Select(y => new CategoryDTO.Content { Id = y.Id, Name = y.Name, Picture = y.Picture, ShortContent = y.ShortContent, TitleSeoUrl = y.TitleSeoUrl }
                    )
                });
                */
            // var cc=  db.Contents.Include(e => e.ContentComments).Where(c => c.ContentComments.Any(i => i.IsActive ==true));
            //var dd = IncludeBy(e => e.ContentFeatures, e => e.ContentComments).Where(c => c.ContentComments.Any(i => i.IsActive == true)).Where(x => x.Id == src.contentid && x.LngId == src.lngid).Select(x => new { n = x.Name, c = x.ContentComments.OrderBy(g => g.Id).ToList() });
            return IncludeBy(e => e.Users, e => e.UserAuthorizations).Where(x=> x.Isactive== src.Isactive).OrderByDescending(x=> x.Name).ProjectTo<MapperUserGroupListResponseDTO>(_mapper.ConfigurationProvider);
        }

        public async Task<IEnumerable<UserGroup>> IncludeAsync(UserGroupListRequestDTO src)
        {
            //src?.Isactive

            /*
              return books.Select(p => new BookListDto
    {
        BookId = p.BookId,                      
        Title = p.Title,                        
        Price = p.Price,                        
        PublishedOn = p.PublishedOn,            
        ActualPrice = p.Promotion == null      
                ? p.Price                       
                : p.Promotion.NewPrice,         
        PromotionPromotionalText =              
                p.Promotion == null            
                  ? null                       
                  : p.Promotion.PromotionalText,
        AuthorNamesOrdered = p.AuthorsLink
                .OrderBy(q => q.Order)
                .Select(q => q.Author.Name),
        ReviewsCount = p.Reviews.Count,        
        ReviewsAverageVotes =                  
            p.Reviews.Select(y => (double?)y.NumStars).Average() 
    });
             */

            return _mapper.Map<IEnumerable<UserGroup>>((await IncludeIEnumerableAsync(x => x.Users)).Where(x => x.Isactive == src?.Isactive).OrderBy(x=> x.Name).ThenByDescending(x=> x.Id));
        }

        public async Task<IEnumerable<UserGroup>> IncludeWhereIfAsync(UserGroupListRequestDTO src)
        {
            return _mapper.Map<IEnumerable<UserGroup>>(
                (await IncludeIEnumerableAsync(x => x.Users))
                .Where(e => src.Id == 0 || e.Id == src.Id)
                .Where(e => src.Name == null || e.Name == src.Name)
                .Where(x => x.Isactive == src.Isactive).OrderBy(x => x.Name).ThenByDescending(x => x.Id));
        }

        public async Task<IList<UserGroupListResponseDTO>> DistinctAsync()
        {
            return _mapper.Map<IList<UserGroupListResponseDTO>>((await GetAllIListAsync()).Distinct());
        }

        public async Task<IEnumerable<UserGroupListResponseDTO>> GetSQLAsync(UserGroupListRequestDTO src)
        {
            //return await RawSql(@"SELECT ID,NAME,RANK,ISACTIVE,ISDELETE FROM USER_GROUPS WHERE NAME = {0}", src.Name).OrderBy(x => x.Name).Select(x => new UserGroupListResponseDTO { Name= x.Name }).ToListAsync();
            return await RawSql(@"SELECT ID,NAME,RANK,ISACTIVE,ISDELETE FROM USER_GROUPS WHERE ISACTIVE = {0}", src.Id).OrderBy(x=> x.Name).ProjectTo<UserGroupListResponseDTO>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public UserGroupListResponseDTO GetIdSQL(UserGroupListRequestDTO src)
        {
            //return RawSql(@"SELECT USER_GROUPS.ISACTIVE,USER_GROUPS.ISDELETE, USER_GROUPS.NAME, USER_GROUPS.ID, USERS.ID AS userid, USERS.EMAIL, USERS.LAST_NAME FROM USER_GROUPS INNER JOIN USERS ON USER_GROUPS.ID = USERS.GROUPID", src.Id).ProjectTo<UserGroupListResponseDTO>(_mapper.ConfigurationProvider).FirstOrDefault();
            return RawSql(@"SELECT ID,NAME,RANK,ISACTIVE,ISDELETE FROM USER_GROUPS WHERE ID = {0}", src.Id).ProjectTo<UserGroupListResponseDTO>(_mapper.ConfigurationProvider).FirstOrDefault();
        }

        public IQueryable<object> GroupJoinBy()
        {
            var qry = _context.Users.GroupJoin(
            _context.UserGroups,
            user => user.Groupid,
            usergroup => usergroup.Id,
            (x, y) => new { user = x, usergroup = y })
            .SelectMany(
            x => x.usergroup.DefaultIfEmpty(),
            //(x, y) => new  { user = x.user, usergroup = y });
            (x, y) => new { x.user.Groupid, x.user.Id, x.user.FirstName, x.user.LastName, y.Name, y.Rank });
            return qry;
        }

        public IQueryable<object> JoinBy()
        {
            return _context.Users.Join(_context.UserGroups, c => c.Groupid, cm => cm.Id, (c, cm) => new { User = c, UserGroup = cm }).Select(x => x.User); 
        }

        public IQueryable<object> SelectManyBy()
        {
            //return _context.Users.SelectMany(x => _context.UserGroups, (x, n) => new { user = x, usergroup = n }); 
            return _context.Users.SelectMany(x => _context.UserGroups, (x, n) => new { x.Groupid, x.Id, x.FirstName, x.LastName, n.Name, n.Rank });
        }

        public IQueryable<MenuUserAuthorizationListDTO> AuthorizationUserGroupEdit(MenuUserGroupAuthorizationRequestDTO src)
        {
           
            var result = _context.BackendMenus.Where(x => x.Isactive == true).OrderBy(x => x.Id).GroupJoin(_context.UserAuthorizations.Where(x => x.Groupid == src.Groupid), s => s.Id, a => a.BakendMenuId, (s, a) => new { s, a }).SelectMany(m => m.a.DefaultIfEmpty(), (m, s) =>
             new MenuUserAuthorizationListDTO
             {
                 BakendMenuId = m.s.Id,
                 Groupid = s.Groupid,
                 Name = m.s.Name,
                 Islist = s.Islist ?? false,
                 Issave = s.Issave ?? false,
                 Isupdate = s.Isupdate ?? false,
                 Isdelete = s.Isdelete ?? false,
             });
            return result;
        }

        public IQueryable<object> GroupBy()
        {
            return GetAllBy().GroupBy(x=> x.Name).Select(g => new { Name = g.Key, Count = g.Count() });
        }

        public IQueryable<UserGroup> SkipTake()
        {
            return GetAllBy().Skip(10).Take(5);
        }

        public IQueryable<UserGroup> ThenByDescending()
        {
            return GetAllBy().OrderBy(x => x.Name).ThenByDescending(x => x.Isactive).OrderByDescending(x => x.Id);
        }

        public IQueryable<UserGroup> ThenInclude()
        {
            return _dbset.Include(x => x.Users).ThenInclude(x => x.Usertype);
        }

        public async Task<int> SumByAsync()
        {
            return await GetAllBy().SumAsync(x => x.Id);
        }

        public async Task<bool> AllBoolAsync()
        {
            // Tüm Kayıtlar Isactive true ise sonuç true yoksa false
            return await AllByAsync(x=> x.Isactive==true);
        }

        public UserGroup BySingle()
        {
            //var dtArray = _context.Kategoris.Where(x => x.Durum == true && x.UstId == 2).Select(s => Convert.ToInt32(s.Id)).ToArray();
            //return await _context.Kayitlars.Where(x => x.Durum == 1 && dtArray.Contains((int)x.KtgId)).OrderBy(x => x.Sira).OrderByDescending(x => x.Id).ProjectTo<ContentDTO.List>(_mapper.ConfigurationProvider).Take(5).ToListAsync();

            //Single Sadece 1 kayıt olmalıdır. 1 den fazla kayıt varsa hata verecektir. Kayıt yoksa da hata verir.
            //return await _dbset.SingleAsync(x => x.Id == 1);
            //return _dbset.Single(x => x.Id == 1);


            // SingleOrDefault sadece 1 kayıt olmalıdır.1 den fazla kayıt varsa hata verecektir. Kayıt yoksa da hata vermez null döner.
            //return await _dbset.SingleOrDefaultAsync(x => x.Id == 1);
            //return _dbset.SingleOrDefault(x => x.Id == 1);

            return SingleBy(x => x.Id == 1); 

            //First sistemde 10 kayıt olsada sadece ilk kaydı getirir. sonuç kümesi boş ise hata verir.
            //return await _dbset.FirstAsync(x => x.Id == 1);
            //return _dbset.First(x => x.Id == 1);

            //First sistemde 10 kayıt olsada sadece ilk kaydı getirir. sonuç kümesi boş ise hata vermez null degeri döner.
            //return await _dbset.FirstOrDefaultAsync(x => x.Id == 1);
            //return _dbset.FirstOrDefault(x => x.Id == 1);
        }

        public void Other()
        {
            var ToArray = GetAllBy().ToArray();
            var Skip = GetAllBy().Skip(3);
            var Take = GetAllBy().Take(3);
            var Max = GetAllBy().Max(x => x.Id);
            var Min = GetAllBy().Min(x => x.Id);
            var Sum = GetAllBy().Sum(x => x.Id);
            var Average = GetAllBy().Average(x => x.Id);
            //var Aggregate = GetAllBy().Aggregate((a, b) => a.Id * b.Id);
        }


        /// <summary>
        /// Create, Add, Insert, Save
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>

        public int OneSaveDTO(UserGroupCreateEditDTO dt)
        {
            var result = Add(_mapper.Map<UserGroup>(dt));
            _uow.Commit();
            return result.Id;
        }

        public async Task<int> OneSaveAsync(UserGroup dt)
        {
            var result = await AddAsync(dt);
            await _uow.CommitAsync();
            return result.Id;
        }

        public async Task<bool> SaveManyAsync(UserGroupCreateEditDTO dt)
        {
            await AddVoidAsync(_mapper.Map<UserGroup>(dt));
            await AddVoidAsync(_mapper.Map<UserGroup>(dt));
            await AddVoidAsync(_mapper.Map<UserGroup>(dt));
            return await _uow.CommitAsync(); ;
        }

        public IEnumerable<UserGroup> SaveRange(IList<UserGroup> dt)
        {
            var result= AddRange(dt);
            _uow.Commit();
            return result;
        }

        public async Task<IEnumerable<UserGroup>> SaveRangeDTOAsync(IList<UserGroupCreateEditDTO> dt)
        {
            var result = await AddRangeAsync(_mapper.Map<IList<UserGroup>>(dt));
            await _uow.CommitAsync();
            return result;
        }

        public async Task<int> OneToManySaveAsync(UserGroup dt)
        {
            var result = await AddAsync(dt);
            await _uow.CommitAsync();
            return result.Id;
        }

        public async Task<bool> ManyToManySaveAsync(IList<UserGroup> dt)
        {
            await AddVoidRangeAsync(dt);
            return await _uow.CommitAsync();
        }

        public async Task<int> InsertDTOAsync(UserGroupCreateEditDTO dt)
        {
            var result = Insert(_mapper.Map<UserGroup>(dt));
            await _uow.CommitAsync();
            return result.Id;
        }


        /// <summary>
        /// Edit, Update
        /// </summary>
        /// <param name="dt"></param>
        /// 

        public int UpdateDTO(UserGroupCreateEditDTO dt)
        {
            var result = Update(_mapper.Map(dt, FirstBy(p => p.Id == dt.Id)));
            _uow.Commit();
            return result.Id;
        }

        public bool OneUpdate(UserGroupCreateEditDTO dt)
        {
            UpdateVoid(dt, dt.Id);
            return _uow.Commit();
        }

        public async Task<bool> OneUpdateAsync(UserGroupCreateEditDTO dt)
        {
            var result = await UpdateAsync(dt, x=> x.Id== dt.Id);
            return await _uow.CommitAsync();
        }

        public UserGroup UpdateModel(UserGroup dt)
        {
            var result=Update(dt);
            _uow.Commit();
            return result;
        }

        public bool UpdateBase(UserGroupCreateEditDTO dt)
        {
            bool result = false;
            var _dt = FirstBy(x => x.Id == dt.Id);
            if (_dt != null)
            {
                _dt.Name = dt.Name;
                UpdateVoid(_dt);
                result = _uow.Commit();
            }
            return result;
        }

        public IEnumerable<UserGroup> UpdateRangeBy(IList<UserGroup> dt)
        {
            var result = UpdateRange(dt);
            _uow.Commit();
            return result;
        }

        public bool UpdateMany(IList<UserGroup> dt)
        {
            foreach (var item in dt)
            {
                UpdateVoid(item);
            }
            return _uow.Commit();
        }

        public async Task<bool> UpdateManyDTOAsync(IList<UserGroupCreateEditDTO> dt)
        {
            foreach (var item in dt)
            {
                await UpdateVoidAsync(item, (p => p.Id == item.Id));
            }
            return await _uow.CommitAsync(); 
        }

        public async Task<int> OneToManyUpdateAsync(UserGroup dt)
        {
            var result =  Update(dt);
            await _uow.CommitAsync();
            return result.Id;
        }

        public async Task<bool> ManyToManyUpdateAsync(IList<UserGroup> dt)
        {
            UpdateRange(dt);
            return await _uow.CommitAsync();
        }

        /// <summary>
        /// Delete, Remove
        /// </summary>
        /// <param name="dt"></param>
        /// 

        public bool DeleteModel(UserGroup dt)
        {
            Delete(dt);
            return _uow.Commit();
        }

        public bool RemoveModel(UserGroup dt)
        {
            Remove(dt);
            return _uow.Commit();
        }

        public int RemoveRangeBy(IList<UserGroup> dt)
        {
            RemoveRange(dt);
            return _uow.Save();
        }

        public void FindAndRemoveBy(int id)
        {
            FindAndRemoveVoid(id);
            _uow.Save();
        }

        public async Task<bool> FindAndRemoveDTOByAsync(UserGroupListRequestDTO src)
        {
            await FindAndRemoveAsync(x=> x.Id == src.Id && x.Isactive== src.Isactive);
            return await _uow.CommitAsync();
        }

    }
}
