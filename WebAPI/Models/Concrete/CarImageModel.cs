/*Created By Engin Yenice
enginyenice2626@gmail.com*/

using Microsoft.AspNetCore.Http;
using WebAPI.Models.Abstract;

namespace WebAPI.Models.Concrete
{
    public class CarImageModel : IModel
    {
        public int carID { get; set; }
        public IFormFile image { get; set; }
    }
}