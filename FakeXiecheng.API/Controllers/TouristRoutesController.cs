using FakeXiecheng.API.Dtos;
using FakeXiecheng.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using AutoMapper;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using FakeXiecheng.API.ResourceParameters;

namespace FakeXiecheng.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TouristRoutesController : ControllerBase
    {
        private readonly IMapper _mapper;   
        //创建私有变量
        private ITouristRouteRepository _touristRouteRepository { get; set; }

        //创建构建函数
        public TouristRoutesController(ITouristRouteRepository touristRouteRepository,IMapper mapper)
        {
            //给私有仓库赋值
            _touristRouteRepository = touristRouteRepository;
            _mapper = mapper;
        }

        // api/touristRoutes?keyword=传入的参数
        [HttpGet]
        [HttpHead]
        public IActionResult GerTouristRoutes(
              [FromQuery] TouristRouteResourceParamaters paramaters
          //[FromQuery] string keyword,
          //string rating // 小于lessThan, 大于largerThan, 等于equalTo lessThan3, largerThan2, equalTo5 
          )// FromQuery vs FromBody
        {
            var touristRoutesFromRepo = _touristRouteRepository.GetTouristRoutes(paramaters.Keyword, paramaters.RatingOperator, paramaters.RatingValue);
            if (touristRoutesFromRepo == null || touristRoutesFromRepo.Count() <= 0)
            {
                return NotFound("没有旅游路线");
            }
            var touristRoutesDto = _mapper.Map<IEnumerable<TouristRouteDto>>(touristRoutesFromRepo);
            return Ok(touristRoutesDto);
        }


        [HttpGet("{touristRouteId}")]
        [HttpHead]
        public IActionResult GetTouristRouteById(Guid touristRouteId)
        {
            var touristRouteFromRepo = _touristRouteRepository.GetTouristRoute(touristRouteId);
            if (touristRouteFromRepo == null)
            {
                return NotFound($"旅游路线{touristRouteId}找不到");
            }
            //var touristRouteDto = new TouristRouteDto()
            //{
            //    Id = touristRouteFromRepo.Id,
            //    Title = touristRouteFromRepo.Title,
            //    Description = touristRouteFromRepo.Description,
            //    Price = touristRouteFromRepo.OriginalPrice * (decimal)(touristRouteFromRepo.DiscountPresent ?? 1),
            //    CreateTime = touristRouteFromRepo.CreateTime,
            //    UpdateTime = touristRouteFromRepo.UpdateTime,
            //    Features = touristRouteFromRepo.Features,
            //    Fees = touristRouteFromRepo.Fees,
            //    Notes = touristRouteFromRepo.Notes,
            //    Rating = touristRouteFromRepo.Rating,
            //    TravelDays = touristRouteFromRepo.TravelDays.ToString(),
            //    TripType = touristRouteFromRepo.TripType.ToString(),
            //    DepartureCity = touristRouteFromRepo.DepartureCity.ToString()
            //};
            var touristRouteDto = _mapper.Map<TouristRouteDto>(touristRouteFromRepo);
            return Ok(touristRouteDto);
        }
    }
}
