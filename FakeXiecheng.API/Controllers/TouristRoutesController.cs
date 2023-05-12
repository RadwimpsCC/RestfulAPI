using FakeXiecheng.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FakeXiecheng.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TouristRoutesController : ControllerBase
    {
        //创建私有变量
        private ITouristRouteRepository _touristRouteRepository { get; set; }

        //创建构建函数
        public TouristRoutesController(ITouristRouteRepository touristRouteRepository)
        {
            //给私有仓库赋值
            _touristRouteRepository = touristRouteRepository;
        }
        [HttpGet]
        public IActionResult GetTouristRoutes()
        {
           var routes= _touristRouteRepository.GetTouristRoutes();
            return Ok(routes);  
        }
    }
}
