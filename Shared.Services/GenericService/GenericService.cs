using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Shared.Core.HelperModels;
using Shared.Core.Interfaces;

namespace Shared.Services.GenericService
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="VMEntity"></typeparam>
    public class GenericService<TEntity, VMEntity> where TEntity : class, IBaseModel, new() where VMEntity : class, IBaseModel
    {
        private readonly IRepo<TEntity> _rep;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rep"></param>
        /// <param name="mapper"></param>
        /// <param name="unitOfWork"></param>
        public GenericService(IRepo<TEntity> rep, IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _rep = rep;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<VMEntity>> GetGenericToDisplayList()
        {
            var arrEntity = await _rep.GetAllAsync();
            return _mapper.Map<IEnumerable<VMEntity>>(arrEntity);

        }

        public async Task<VMEntity> GetGenericByIdToDisplay(int id)
        {
            var arrEntity = await _rep.GetAsyncById(id);
            return _mapper.Map<VMEntity>(arrEntity);

        }

        public async Task<VMEntity> CreateNewGeneric(VMEntity genericmodel)
        {
            var toInsert = _mapper.Map<TEntity>(genericmodel);
            await _rep.AddAsync(toInsert);
            await _unitOfWork.CompleteAsync();
            return _mapper.Map<VMEntity>(toInsert);
        }


        public async Task<VMEntity> UpdateGeneric(VMEntity genericmodel)
        {
            var toupdate = _mapper.Map<TEntity>(genericmodel);
            _rep.Update(toupdate);
            await _unitOfWork.CompleteAsync();
            return _mapper.Map<VMEntity>(toupdate);
        }


        public async Task<bool> DeleteGeneric(int id)
        {
            var todelete = await _rep.GetAsyncById(id);
            todelete.IsDeleted = true;
            _rep.Update(todelete);
            await _unitOfWork.CompleteAsync();
            return true;
        }

    }
}
