/*Created By Engin Yenice
enginyenice2626@gmail.com*/

using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;

namespace Core.Utilities.FileProcess
{
    public interface IFileProcess
    {
        IDataResult<string> Upload(string directoryPath, IFormFile file);

        IResult Delete(string filePath);
    }
}