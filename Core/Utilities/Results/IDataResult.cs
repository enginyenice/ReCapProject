/*Created By Engin Yenice
enginyenice2626@gmail.com*/

namespace Core.Utilities.Results
{
    internal interface IDataResult<T> : IResult
    {
        T Data { get; }
    }
}