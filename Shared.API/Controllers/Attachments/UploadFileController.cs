using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Shared.API.Helpers.FileManagement;
using Shared.API.Helpers.Shared;
using WorkflowProject.Helpers.FileManagement;

namespace Shared.API.Controllers.Attachments
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadFileController : Controller
    {
        private readonly IFileHelper _fileHelper;
        private readonly FileSettings _fileSettings;

        public UploadFileController(IFileHelper fileHelper, IOptionsSnapshot<FileSettings> options)
        {
            _fileHelper = fileHelper;
            _fileSettings = options.Value;
        }

        /// <summary>
        /// upload file
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(SharedResponse<Guid>), 200)]
        [HttpPost]
        public async Task<IActionResult> Post(IFormFile file)
        {
            var validateFile = _fileSettings.IsValidFile(file);
            if (!validateFile.Result) return BadRequest(validateFile.Message);
            var result = await _fileHelper.SaveFile(file);
            return new SharedResponseResult<Guid>(result,
                    "The file has been uploaded successfully  ");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(typeof(AcceptedResult), 200)]
        public IActionResult Delete(int id)
        {
            _fileHelper.DeleteFile(id);
            return Accepted();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="ShredValidationException"></exception>
        [HttpGet]
        [ProducesResponseType(typeof(FileStreamResult), 200)]
        public async Task<IActionResult> Download(Guid  id)
        {
            var fileData = await _fileHelper.DownloadFileAsync(id);
            if(fileData == null)
                throw new ShredValidationException("filename not present");
            return File(fileData.MemoryStream, fileData.ContentType, fileData.FileName);
        }

    }
}