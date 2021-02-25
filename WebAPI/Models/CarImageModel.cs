/*Created By Engin Yenice
enginyenice2626@gmail.com*/

using Microsoft.AspNetCore.Http;

namespace WebAPI.Models
{
    public class CarImageModel
    {
        public int carID { get; set; }
        public IFormFile image { get; set; }
    }
}