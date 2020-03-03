using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Shared.API.Helpers.Shared;
using Shared.Core.Entities;
using Shared.GeneralHelper.ViewModels.SystemLookupsVw;
using Shared.Services.GenericService;
using Shared.Services.Lookup;
 
namespace Shared.API.Controllers.Shared
{
    /// <summary>
    /// 
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class LookupsController :   GenericController<Lookups, LookupVw>
    {
         private readonly LookupService _service;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="service"></param>
        /// <param name="genericService"></param>
        public LookupsController(LookupService service, GenericService<Lookups, LookupVw> genericService) : base(genericService)
        {
            _service = service;
        }
        [HttpPost("GetByType")]
        [ProducesResponseType(typeof(SharedResponse<IEnumerable<LookupVw>>), 200)]
        public IActionResult GetByType(List<int> types)
        {
            var lookups = _service.GetLookupsToDisplayList(types);
            return new SharedResponseResult<IEnumerable<LookupVw>>(lookups);
        }

        [HttpPost("GetAllType")]
        [ProducesResponseType(typeof(SharedResponse<IEnumerable<LookupTypeVw>>), 200)]
        public IActionResult GetAllType()
        {
            var lookups = _service.GetLookupsToDisplayList();
            return new SharedResponseResult<IEnumerable<LookupTypeVw>>(lookups);
        }
    }
}