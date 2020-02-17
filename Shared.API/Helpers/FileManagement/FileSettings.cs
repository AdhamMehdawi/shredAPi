using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Shared.Services.ViewModels.ServicesViewModel;

namespace Shared.API.Helpers.FileManagement
{
    public class FileSettings
    {
        public int MaxByte { get; set; }
        public string[] AcceptedFileTypes { get; set; }

        public bool IsSupported(string fileName)
        {
            return AcceptedFileTypes.Any(c => c == Path.GetExtension(fileName).ToLower());
        }

        public CustomValidationModel IsValidFile(IFormFile file)
        {
            var result = new CustomValidationModel
            {
                Result = true
            };
            if (file == null)
            {
                result.Message = "Null File";
                result.Result = false;
            }
            else
            {
                if (file.Length == 0)
                {
                    result.Message = "Empty File";
                    result.Result = false;
                }
                if (!IsSupported(file.FileName))
                {
                    result.Message = "Is not supported file extension";
                    result.Result = false;
                }
                if (file.Length <= MaxByte) return result;
                result.Message = "File greater than allowed size 50 MB  ";
                result.Result = false;
            }
            return result;
        }
    }
}
