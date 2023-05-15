using FakeXiecheng.API.Models;
using System;
using System.Collections.Generic;

namespace FakeXiecheng.API.Services
{
    public interface ITouristRouteRepository
    {
        IEnumerable<TouristRoute> GetTouristRoutes(string keyword, string ratingOperator, int? ratingValue);         //返回一组旅游路线
        TouristRoute GetTouristRoute(Guid touristRouteId);      //返回单独的旅游路线

        bool TouristRouteExists(Guid touristRouteId);

        IEnumerable<TouristRoutePicture> GetPicturesByTouristRouteId(Guid touristRouteId);

        TouristRoutePicture GetPicture(int pictureId);
    }
}
