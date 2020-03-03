using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Core.Entities;
using Shared.GeneralHelper.ViewModels.SystemLookupsVw;
using Shared.Services.GenericService;
 
namespace Shared.API.Controllers.Shared
{
    [Route("api/[controller]")]
    [ApiController]
    public class LookupTypesController : GenericController<LookupTypes, LookupTypeVw>
    {
        public LookupTypesController(GenericService<LookupTypes, LookupTypeVw>  genericService) : base(genericService)
        {
        }
    }
}