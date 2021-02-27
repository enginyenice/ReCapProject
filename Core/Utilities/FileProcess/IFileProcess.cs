/*Created By Engin Yenice
enginyenice2626@gmail.com*/

using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;

namespace Core.Utilities.FileProcess
{
    public interface IFileProcess
    {
        /// <summary>
        /// Create File
        /// </summary>
        /// <param name="directoryPath">example 1: foldername <br></br> example 2: foldername/subfoldername/.... [unlimited]</param>
        /// <param name="file">IFromFile type</param>
        /// <returns>IDataResult.Data = Path of the file created.</returns>
        IDataResult<string> Upload(string directoryPath, IFormFile file);

        /// <summary>
        /// Delete File
        /// </summary>
        /// <param name="filePath">example 1: "foldername/filename" </param>
        /// <returns></returns>
        IResult Delete(string filePath);
    }
}