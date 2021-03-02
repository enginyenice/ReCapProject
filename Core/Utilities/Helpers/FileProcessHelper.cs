﻿/*Created By Engin Yenice
enginyenice2626@gmail.com*/

using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Runtime.InteropServices;
using Core.Constants;

namespace Core.Utilities.Helpers
{
    public class FileProcessHelper
    {
        /// <summary>
        /// Delete File
        /// </summary>
        /// <param name="filePath">The path to the file to be deleted.
        /// Example: folderName/file.png
        /// Example: folderName/subFolderName1/subFolderName2/[unlimited]/file.png
        /// </param>
        /// <returns></returns>
        /// <exception cref="ExternalException"></exception>
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
        /// <summary>
        /// Upload file
        /// </summary>
        /// <param name="directoryPath">The folder to be saved.
        /// Example: folderName
        ///Example: folderName/subFolderName1/subFolderName2/.... [unlimeted]
        /// </param>
        /// <param name="file">IFromFile</param>
        /// <returns>
        /// IDataResult.Data => The path to the uploaded file.
        /// IDataResult.Success => Registration status (True or False)
        /// IDataResult.Message => Returning message
        /// </returns>
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

                return new SuccessDataResult<string>(data:Path.Combine(directoryPath, fileName));
            }
            return new ErrorDataResult<string>();
        }
        /// <summary>
        /// FolderControl
        /// </summary>
        /// <param name="directoryPath">example 1: foldername <br></br> example 2: foldername/subfoldername/.... [unlimited]</param>
        private static void FolderControl(string directoryPath)
        {
            if (!Directory.Exists(Path.Combine(DefaultNameOrPath.FullPath,directoryPath)))
            {
                Directory.CreateDirectory(Path.Combine(DefaultNameOrPath.FullPath,directoryPath));
            }
        }
    }
}