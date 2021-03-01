/*Created By Engin Yenice
enginyenice2626@gmail.com*/

using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Runtime.InteropServices;
using Core.Constants;

namespace Core.Utilities.Helpers
{
    public class FileProcess
    {
        public static IResult Delete(string filePath)
        {
            try
            {
                File.Delete(Path.Combine(DefaultNameOrPath.FullPath, filePath));
            }
            catch (Exception)
            {
                throw new ExternalException("Dosya bulunamadı.");
            }
            return new SuccessResult();
        }

        

        public static IDataResult<string> Upload(string directoryPath, IFormFile file)
        {
            FolderControl(directoryPath);
            if (file != null && file.Length > 0)
            {
                string fileName = Guid.NewGuid().ToString("D") + Path.GetExtension(file.FileName).ToLower();
                var filePath = Path.Combine(DefaultNameOrPath.FullPath, directoryPath, fileName);
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
                var path = Path.Combine(DefaultNameOrPath.FullPath, checkPath);
                if (!Directory.Exists(checkPath))
                {
                    Directory.CreateDirectory(path);
                }
            }
        }
    }
}