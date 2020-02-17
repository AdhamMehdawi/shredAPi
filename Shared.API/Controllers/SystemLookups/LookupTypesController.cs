using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.API.Filters;
using Shared.Core.Interfaces;
using Shared.Services.ViewModels.Lookups;

namespace Shared.API.Controllers.SystemLookups
{
    [Produces("application/json")]
    [Route("api/LookupTypes"), Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme), TypeFilter(typeof(PermissionFilter))]
    public class LookupTypesController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _db;

        public LookupTypesController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _db = unitOfWork;
        }
        [HttpGet("GetWithChildren")]
        public async Task<List<LookupTypeViewModel>> GetAllWithChildren()
        {
            //try
            //{
            //    var types = await _db.LookupTypesRepository.GetAllWhereAsync(x => x.Editable, "Parent", "Lookups");
            //    var typesVM = _mapper.Map<List<LookupTypeViewModel>>(types);
            //    return typesVM;
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
            return null;
        }

        // GET: api/LookupTypes
        [HttpGet]
        public virtual async Task<List<LookupTypeViewModel>> Get()
        {
            //try
            //{
            //    var type = await _db.LookupTypesRepository.GetAllWithChildrenAsync();
            //    var typeResult = _mapper.Map<List<LookupTypeViewModel>>(type);
            //    return typeResult;
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
            return null;
        } 
    }
}
