using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiSeyyedi.DTO.DTOs;
using WebApiSeyyedi.Services.ServiceInterfaces;

namespace WebApiSeyyedi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;
        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }



        [HttpGet]
        public async Task<ActionResult> Details(int? id)
        {
            CityDTO city = await _cityService.GetCity(id.Value);

            return new JsonResult(city);
        }



        [HttpPost]
        public async Task<ActionResult> Create(CityDTO city)
        {

            if (ModelState.IsValid)
            {
                await _cityService.AddCity(city);
                return new JsonResult(_cityService.GetCitys());
            }
            return new JsonResult(city);
        }



        [HttpPut]
        public async Task<ActionResult> Edit(CityDTO city)
        {
            var dataa = _cityService.GetCity(city.Id);
            if (dataa == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _cityService.UpdateCity(city);

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex.InnerException);
                }
                return new JsonResult(city);
            }
            return new JsonResult(city);
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int? id)
        {
            var data = await _cityService.GetCity(id.Value);
            return new JsonResult(data);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await _cityService.RemoveCity(id);
            CityDTO city = new CityDTO();
            return new JsonResult(city);
        }
    }
}
