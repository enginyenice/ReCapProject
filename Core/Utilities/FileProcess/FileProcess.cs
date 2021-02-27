/*Created By Engin Yenice
enginyenice2626@gmail.com*/

using Core.Utilities.Results;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace Core.Utilities.FileProcess
{
    public class FileProcess : IFileProcess
    {
        private readonly IHostingEnvironment environment;

        public FileProcess(IHostingEnvironment environment)
        {
            this.environment = environment;
        }

        public IResult Delete(string filePath)
        {
            File.Delete(filePath);
            return new SuccessResult();
        }

        public IDataResult<string> Upload(string directoryName, IFormFile file)
        {
            FolderControl(directoryName);
            if (file != null && file.Length > 0)
            {
                string fileName = Guid.NewGuid().ToString("D") + Path.GetExtension(file.FileName).ToLower();
                var filePath = Path.Combine(environment.ContentRootPath, directoryName, fileName);
                using (var stream = File.Create(filePath))
                {
                    file.CopyTo(stream);
                    stream.Flush();
                }

                return new SuccessDataResult<string>(Path.Combine(directoryName, fileName), "");
            }
            return new ErrorDataResult<string>();
        }

        private void FolderControl(string directoryName)
        {
            var directoryPath = Path.Combine(environment.ContentRootPath, directoryName);
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
        }
    }
}