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
        private readonly ICarImageService _carImageService;

        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }

        [HttpPost("add")]
        [DisableRequestSizeLimit]
        public IActionResult Add([FromForm] CarImageModel carImageModel)
        {
            string tempPath = CreateImage(carImageModel);
            return Ok(_carImageService.Add(new CarImage { CarID = carImageModel.CarID, ImagePath = tempPath }));
        }

        [HttpPost("update")]
        [DisableRequestSizeLimit]
        public IActionResult Update([FromForm] CarImageModel carImageModel)
        {
            string tempPath = CreateImage(carImageModel);
            return Ok(_carImageService.Update(new CarImage { Id = carImageModel.Id, CarID = carImageModel.CarID, ImagePath = tempPath }));
        }

        private string CreateImage(CarImageModel carImageModel)
        {
            string tempPath = "";
            if (carImageModel.Image != null && carImageModel.Image.Length > 0)
            {
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(carImageModel.Image.FileName).ToLower();
                var filePath = Path.Combine(Path.GetTempPath(), fileName);

                using var stream = System.IO.File.Create(filePath);
                carImageModel.Image.CopyTo(stream);
                tempPath = stream.Name;
                stream.Flush();
            }

            return tempPath;
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