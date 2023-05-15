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

        IEnumerable<TouristRoute> GetTouristRoutesByIDList(IEnumerable<Guid> ids);
        TouristRoutePicture GetPicture(int pictureId);
        void AddTouristRoute(TouristRoute touristRoute);

        void AddTouristRoutePicture(Guid touristRouteId, TouristRoutePicture touristRoutePicture);

        void DeleteTouristRoute(TouristRoute touristRoute);
        void DeleteTouristRoutes(IEnumerable<TouristRoute> touristRoutes);
        void DeleteTouristRoutePicture(TouristRoutePicture picture);
        bool Save();
    }
}
