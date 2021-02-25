/*Created By Engin Yenice
enginyenice2626@gmail.com*/

using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using WebAPI.Models.Concrete;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        private ICarImageService _carImageService;

        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }

        [HttpPost("add")]
        [DisableRequestSizeLimit]
        public IActionResult Add([FromForm] CarImageModel carImageModel)
        {
            string tempPath = "";
            if (carImageModel.image != null && carImageModel.image.Length > 0)
            {
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(carImageModel.image.FileName).ToLower();
                var filePath = Path.Combine(Path.GetTempPath(), fileName);

                using (var stream = System.IO.File.Create(filePath))
                {
                    carImageModel.image.CopyTo(stream);
                    tempPath = stream.Name;
                }
            }

            return Ok(_carImageService.Add(new CarImage { CarID = carImageModel.carID, ImagePath = tempPath }));
        }

        [HttpPost("update")]
        [DisableRequestSizeLimit]
        public IActionResult Update([FromForm] CarImageModel carImageModel)
        {
            string tempPath = "";
            if (carImageModel.image != null && carImageModel.image.Length > 0)
            {
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(carImageModel.image.FileName).ToLower();
                var filePath = Path.Combine(Path.GetTempPath(), fileName);

                using (var stream = System.IO.File.Create(filePath))
                {
                    carImageModel.image.CopyTo(stream);
                    tempPath = stream.Name;
                }
            }

            return Ok(_carImageService.Update(new CarImage { CarID = carImageModel.carID, ImagePath = tempPath }));
        }

        [HttpPost("delete")]
        public IActionResult Delete(CarImage carImage)
        {
            return Ok(_carImageService.Delete(carImage));
        }

        [HttpGet("get")]
        public IActionResult Get()
        {
            return Ok(_carImageService.GetAll());
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            return Ok(_carImageService.GetAll());
        }

        [HttpGet("getallbycarid")]
        public IActionResult GetAllByCarId(int carId)
        {
            return Ok(_carImageService.GetAllByCarId(carId));
        }
    }
}