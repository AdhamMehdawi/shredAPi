using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Shared.Services.ViewModels.AttachmentViewModel;

namespace WorkflowProject.Helpers.FileManagement
{
    /// <summary>
    /// 
    /// </summary>
    public interface IFileHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        Task<Guid> SaveFile(IFormFile file);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileId"></param>
        void DeleteFile(int fileId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        string GetContentType(string path);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileId"></param>
        /// <returns></returns>
        Task<DownloadAttachmentViewModel> DownloadFileAsync(Guid fileId);
    }
}