using FakeXiecheng.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System;
using System.Linq;
using System.Collections;
using FakeXiecheng.API.Dtos;
using System.Collections.Generic;

namespace FakeXiecheng.API.Controllers
{
    [Route("api/touristRoutes/{touristRouteId}/pictures")]
    [ApiController]
    public class TouristRoutePicturesController : ControllerBase
    {
        private ITouristRouteRepository _touristRouteRepository;
        public IMapper _mapper;
        public TouristRoutePicturesController(ITouristRouteRepository touristRouteRepository,IMapper mapper) 
        {
            _touristRouteRepository = touristRouteRepository ??
                 throw new ArgumentNullException(nameof(touristRouteRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));

        }

        [HttpGet]
        public IActionResult GetPictureListForTouristRoute(Guid touristRouteId)
        {
            if (!_touristRouteRepository.TouristRouteExists(touristRouteId))
            {
                return NotFound("旅游线路不存在");
            }

            var picturesFromRepo = _touristRouteRepository.GetPicturesByTouristRouteId(touristRouteId);
            if (picturesFromRepo == null || picturesFromRepo.Count() <= 0)
            {
                return NotFound("照片不存在");
            }

            return Ok(_mapper.Map<IEnumerable<TouristRoutePictureDto>>(picturesFromRepo));

        }
        [HttpGet("{pictureId}")]
        public IActionResult GetPicture(Guid touristRouteId, int pictureId)
        {
            if (!_touristRouteRepository.TouristRouteExists(touristRouteId))
            { 
                return NotFound("旅游路线不存在");
            }
            var pictureFromRepo = _touristRouteRepository.GetPicture(pictureId);
            if (pictureFromRepo == null)
            {
                return NotFound("旅游图片不存在");
            }
            return Ok(_mapper.Map<TouristRoutePictureDto>(pictureFromRepo));
        
        }

    }
}
