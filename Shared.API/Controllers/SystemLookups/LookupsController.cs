using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.API.Filters;
using Shared.Core.Entities;
using Shared.Core.Interfaces;
using Shared.Services.ViewModels.Lookups;
using Shared.Services.ViewModels.ServicesViewModel;

namespace Shared.API.Controllers.SystemLookups
{
    [Produces("application/json")]
    [Route("api/Lookups"), Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme), TypeFilter(typeof(PermissionFilter))]
    public class LookupsController : Controller
    {
        private readonly UserService _usersService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public LookupsController(IMapper mapper, IUnitOfWork unitOfWork, UserService usersService)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _usersService = usersService;
        }

        [HttpGet("GetAll/{IsPrimary}")]
        public async Task<IEnumerable<LookupViewModel>> GetAll(int IsPrimary)
        {
            try
            {
                IEnumerable<Lookup> list = await _unitOfWork.LookupsRepository
                    .GetAllWhereAsync(x =>
                        IsPrimary == 0 ? x.IsPrimary == IsPrimary : (x.IsPrimary == null || x.IsPrimary == IsPrimary));

                List<LookupViewModel> listVm = _mapper.Map<List<LookupViewModel>>(list);
                return listVm;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetListByType/{id}")]
        public async Task<IEnumerable<LookupViewModel>> GetListByType(LookupTypes id)
        {
            try
            {
                IEnumerable<Lookup> list = await _unitOfWork.LookupsRepository.GetListByTypeAsync(id);

                List<LookupViewModel> listVM = _mapper.Map<List<LookupViewModel>>(list);
                return listVM;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("GetLookups")]
        public async Task<IEnumerable<LookupViewModel>> GetLookups([FromBody] Filter filter)
        {
            try
            {
                List<Lookup> list = await _unitOfWork.LookupsRepository
                    .GetAllWhereAsync(x => filter.Id.Contains(x.LookupTypeId));
                if (filter.IsPrimary == 1)
                    list = list.Where(x => x.IsPrimary == null || x.IsPrimary == filter.IsPrimary).ToList();

                List<LookupViewModel> listVm = _mapper.Map<List<LookupViewModel>>(list);
                return listVm;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<LookupViewModel> Post([FromBody] LookupViewModel lookupVm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    Response.StatusCode = 400;
                    throw new Exception();
                }

                Lookup lookup = _mapper.Map<Lookup>(lookupVm);
                lookup.CreatedBy = _usersService.Id;
                lookup.CreatedDate = DateTime.Now;
                lookup.UpdatedBy = _usersService.Id;
                lookup.UpdateDate = DateTime.Now;
                lookup.IsPrimary = 1;
                Lookup inserted = await _unitOfWork.LookupsRepository.AddAsync(lookup);
                LookupViewModel insertedVM = _mapper.Map<LookupViewModel>(inserted);
                return insertedVM;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("{id}")]
        public LookupViewModel Put([FromBody] LookupViewModel lookupVm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    Response.StatusCode = 400;
                    throw new Exception();
                }

                Lookup lookup = _mapper.Map<Lookup>(lookupVm);
                lookup.IsPrimary = 1;
                lookup.UpdatedBy = _usersService.Id;
                lookup.UpdateDate = DateTime.Now;
                Lookup updated = _unitOfWork.LookupsRepository.Update(lookup);
                LookupViewModel updatedVM = _mapper.Map<LookupViewModel>(updated);
                return updatedVM;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            try
            {
                return _unitOfWork.LookupsRepository.DeleteAsync(id).IsCompleted;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    public class Filter
    {
        public IList<int?> Id { get; set; }
        public int IsPrimary { get; set; }
    }
}