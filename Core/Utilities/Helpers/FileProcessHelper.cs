/*Created By Engin Yenice
enginyenice2626@gmail.com*/

using Core.Utilities.Results;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace Core.Utilities.FileProcess
{
    public class FileProcess
    {
        public static IResult Delete(string filePath)
        {
            try
            {
                File.Delete(Path.Combine(fullPath, filePath));
            }
            catch (Exception e)
            {
                throw new ExecutionEngineException("Dosya bulunamadı.");
            }
            return new SuccessResult();
        }

        public static string fullPath = Path.Combine(Environment.CurrentDirectory, "wwwroot");

        public static IDataResult<string> Upload(string directoryPath, IFormFile file)
        {
            FolderControl(directoryPath);
            if (file != null && file.Length > 0)
            {
                string fileName = Guid.NewGuid().ToString("D") + Path.GetExtension(file.FileName).ToLower();
                var filePath = Path.Combine(fullPath, directoryPath, fileName);
                using (var stream = File.Create(filePath))
                {
                    file.CopyTo(stream);
                    stream.Flush();
                }

                return new SuccessDataResult<string>(Path.Combine(directoryPath, fileName), "");
            }
            return new ErrorDataResult<string>();
        }

        /// <summary>
        /// FolderControl
        /// </summary>
        /// <param name="directoryPath">example 1: foldername <br></br> example 2: foldername/subfoldername/.... [unlimited]</param>
        private static void FolderControl(string directoryPath)
        {
            string[] directories = directoryPath.Split('/');
            string checkPath = "";

            foreach (var directory in directories)
            {
                checkPath += directory + "\\";
                var path = Path.Combine(fullPath, checkPath);
                if (!Directory.Exists(checkPath))
                {
                    Directory.CreateDirectory(path);
                }
            }
        }
    }
}