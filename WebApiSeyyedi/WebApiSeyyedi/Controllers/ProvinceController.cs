using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiSeyyedi.DTO.DTOs;
using WebApiSeyyedi.Services.ServiceInterfaces;

namespace WebApiSeyyedi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProvinceController : ControllerBase
    {
        private readonly IProvinceService _provinceService;
        public ProvinceController(IProvinceService provinceService)
        {
            _provinceService = provinceService;
        }

        

        [HttpGet]
        public async Task<ActionResult> Details(int? id)
        {
            ProvinceDTO province = await _provinceService.GetProvince(id.Value);

            return new JsonResult(province);
        }

        

        [HttpPost]
        public async Task<ActionResult> Create(ProvinceDTO province)
        {

            if (ModelState.IsValid)
            {
                await _provinceService.AddProvince(province);
                return new JsonResult(_provinceService.GetProvinces());
            }
            return new JsonResult(province);
        }

       

        [HttpPut]
        public async Task<ActionResult> Edit(ProvinceDTO province)
        {
            var data = _provinceService.GetProvince(province.Id);
            if (data == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _provinceService.UpdateProvince(province);

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex.InnerException);
                }
                return new JsonResult(province);
            }
            return new JsonResult(province);
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int? id)
        {
            var data = await _provinceService.GetProvince(id.Value);
            return new JsonResult(data);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await _provinceService.RemoveProvince(id);
            ProvinceDTO province = new ProvinceDTO();
            return new JsonResult(province);
        }
    }
}
