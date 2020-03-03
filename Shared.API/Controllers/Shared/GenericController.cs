using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shared.API.Helpers.Shared;
using Shared.Core.HelperModels;
using Shared.Services.GenericService;

namespace Shared.API.Controllers.Shared
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public abstract class GenericController<TEntity, VMEntity> : ControllerBase where TEntity : class, IBaseModel,
        new() where VMEntity : class, IBaseModel
    {
        private readonly GenericService<TEntity, VMEntity> _genericService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="genericService"></param>
        protected GenericController(GenericService<TEntity, VMEntity> genericService)
        {
            _genericService = genericService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAll")]
        [ProducesResponseType(typeof(SharedResponse<IEnumerable<object>>), 200)]
        public async Task<IActionResult> GetAll()
        {
            var genericList = (await _genericService.GetGenericToDisplayList()).ToList();
            return new SharedResponseResult<IEnumerable<VMEntity>>(genericList, genericList.Count(),HttpStatusCode.OK,false,"");
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(SharedResponse<object>), 200)]
        public async Task<IActionResult> GetById(int id)
        {
            var generic = await _genericService.GetGenericByIdToDisplay(id);
            return new SharedResponseResult<VMEntity>(generic);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidateModelAsyncActionFilter))]
        [ProducesResponseType(typeof(SharedResponse<object>), 200)]
        public async Task<IActionResult> Post([FromBody] VMEntity obj)
        {
            var model = await _genericService.CreateNewGeneric(obj);
            return new SharedResponseResult<VMEntity>(model, true, "generic was created successfully  ");
        }

        [HttpPut]
        [ServiceFilter(typeof(ValidateModelAsyncActionFilter))]
        [ProducesResponseType(typeof(SharedResponse<object>), 200)]
        public async Task<IActionResult> Put([FromBody] VMEntity obj)
        {
            var model = await _genericService.UpdateGeneric(obj);
            return new SharedResponseResult<VMEntity>(model, true, "generic was created successfully  ");
        }

        [HttpDelete]
        [ProducesResponseType(typeof(bool), 200)]
        public async Task<bool> Delete(int id)
        {
            var generic = await _genericService.DeleteGeneric(id);
            return generic;
        }
    }
}