﻿/*Created By Engin Yenice
enginyenice2626@gmail.com*/

using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Add(CarImage carImage)
        {
            return Ok(_carImageService.Add(carImage));
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