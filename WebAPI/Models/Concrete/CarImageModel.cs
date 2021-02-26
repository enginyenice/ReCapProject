/*Created By Engin Yenice
enginyenice2626@gmail.com*/

using Microsoft.AspNetCore.Http;
using WebAPI.Models.Abstract;

namespace WebAPI.Models.Concrete
{
    public class CarImageModel : IModel
    {
        public int Id { get; set; }
        public int CarID { get; set; }
        public string ImagePath { get; set; }
        public IFormFile Image { get; set; }
    }
}