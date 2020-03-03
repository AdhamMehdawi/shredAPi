using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Shared.Core.Entities;
using Shared.Core.Interfaces;
using Shared.Core.Interfaces.IAttachmentRepo;
using Shared.GeneralHelper.ViewModels.AttachmentViewModel;

namespace Shared.API.Helpers.FileManagement
{
    /// <inheritdoc />
    public class FileHelper : IFileHelper
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IAttachmentFileRepo _attachmentFileRepo;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hostingEnvironment"></param>
        /// <param name="attachmentFileRepo"></param>
        /// <param name="unitOfWork"></param>
        public FileHelper(IHostingEnvironment hostingEnvironment, IAttachmentFileRepo attachmentFileRepo,
            IUnitOfWork unitOfWork)
        {
            _hostingEnvironment = hostingEnvironment;
            _attachmentFileRepo = attachmentFileRepo;
            _unitOfWork = unitOfWork;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public async Task<Guid> SaveFile(IFormFile file)
        {
            var ms = new MemoryStream();
            file.OpenReadStream().CopyTo(ms);

            var attachmentFile = new AttachmentFiles
            {
                FileContentData = ms.ToArray().ToString(),
                FileExtension = Path.GetExtension(file.FileName),
                FileName = file.FileName,
                FileSize = file.Length
            };
            await _attachmentFileRepo.AddAsync(attachmentFile);
            await _unitOfWork.CompleteAsync();
            return attachmentFile.Id;

            //var folderPath = Path.Combine(_hostingEnvironment.WebRootPath, "UploadedFiles");
            //if (!Directory.Exists(folderPath))
            //    Directory.CreateDirectory(folderPath);
            //var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
            //var filePath = Path.Combine(folderPath, fileName);
            //if (file.Length > 0)
            //{
            //    using (var stream = new FileStream(filePath, FileMode.Create))
            //    {
            //        await file.CopyToAsync(stream);
            //    }
            //}
            //var res = new AttachmentResponseViewModel
            //{
            //    FileName = file.FileName,
            //    ServerFileName = fileName
            //};
            //return res;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void DeleteFile(int id)
        {
            //var filePath = _hostingEnvironment.ContentRootPath + "/wwwroot/UploadedFiles/" + file;
            //File.Delete(filePath);
            _attachmentFileRepo.Delete(id);
            _unitOfWork.CompleteAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ext"></param>
        /// <returns></returns>
        public string GetContentType(string ext)
        {
            var types = GetMimeTypes();
            return types[ext.ToLower()];
        }

        private Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.ms-word"},
                {".xls", "application/vnd.ms-excel"},
                {".xlsx", "application/vnd.openxmlformatsofficedocument.spreadsheetml.sheet"},
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".csv", "text/csv"}
            };
        }

        public async Task<DownloadAttachmentViewModel> DownloadFileAsync(Guid fileId)
        {
            var file = await _attachmentFileRepo.GetAsync(c => c.Id == fileId);
            var bytesArray = Convert.ToByte(file.FileContentData);
            var memory = new MemoryStream(bytesArray) { Position = 0 };
            return new DownloadAttachmentViewModel
            {
                MemoryStream = memory,
                ContentType = GetContentType(file.FileExtension),
                FileName = file.FileName
            };

            //var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", filename);
            //var memory = new MemoryStream();
            //using (var stream = new FileStream(path, FileMode.Open))
            //{
            //    await stream.CopyToAsync(memory);
            //}
            //memory.Position = 0;
            //return new DownloadAttachmentViewModel
            //{
            //    MemoryStream = memory,
            //    ContentType = GetContentType(path),
            //    FileName = Path.GetFileName(path)
            //};
        }
    }
}
