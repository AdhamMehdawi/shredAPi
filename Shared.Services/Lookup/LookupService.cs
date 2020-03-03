
using Shared.Core.Entities;
using Shared.Core.Interfaces;
using System.Collections.Generic;
using AutoMapper;
using Shared.GeneralHelper.ViewModels.SystemLookupsVw;

namespace Shared.Services.Lookup
{
    /// <summary>
    /// 
    /// </summary>
    public class LookupService
    {
        readonly IRepo<Lookups> _rep;
        readonly IRepo<LookupTypes> _typeRep;
        private readonly IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rep"></param>
        /// <param name="mapper"></param>
        /// <param name="typeRep"></param>
        public LookupService(IRepo<Lookups> rep, IMapper mapper,
            IRepo<LookupTypes> typeRep)
        {
            _rep = rep;
            _mapper = mapper;
            _typeRep = typeRep;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="types"></param>
        /// <returns></returns>
        public List<LookupVw> GetLookupsToDisplayList(List<int> types)
        {
            var res = _rep.GetAllWhere(x => types.Contains(x.LookupType.Id) && x.IsDeleted == false);
            return _mapper.Map<List<LookupVw>>(res);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<LookupTypeVw> GetLookupsToDisplayList()
        {
            var res = _typeRep.GetAllWhere(x => !x.IsDeleted);
            return _mapper.Map<List<LookupTypeVw>>(res);
        }
    }
}
