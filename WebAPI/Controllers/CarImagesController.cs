/*Created By Engin Yenice
enginyenice2626@gmail.com*/

using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Add([FromForm] CarImage carImage, [FromForm] IFormFile file)
        {
            if (file == null)
                file = new FormFile(null, -1, -1, "&&NotFound&&", "&&NotFound&&");

            var result = _carImageService.Add(carImage, file);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("update")]
        [DisableRequestSizeLimit]
        public IActionResult Update([FromForm] CarImage carImage, [FromForm] IFormFile file)
        {
            if (file == null)
                file = new FormFile(null, -1, -1, "&&NotFound&&", "&&NotFound&&");

            var result = _carImageService.Update(carImage, file);
            if (result.Success)
                return Ok(result);
            return BadRequest(result.Message);
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