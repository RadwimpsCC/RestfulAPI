using FakeXiecheng.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FakeXiecheng.API.Services
{
    //public class MockTouristRouteRepository : ITouristRouteRepository 
    //{
    //    private List<TouristRoute> _routes;     //定义列表用来保存假数据
        
    //    //创建构建函数，用来实例化路线
    //    public MockTouristRouteRepository()
    //    {
    //        //判断列表数据是否为空，为空加载初始数据
    //        if (_routes == null)
    //        {
    //            InitializeTouristRoutes();
    //        }
    //    }
    //    private void InitializeTouristRoutes()
    //    {
    //        _routes = new List<TouristRoute>
    //        {
    //            new TouristRoute {
    //                Id = Guid.NewGuid(),
    //                Title = "黄山",
    //                Description="黄山真好玩",
    //                OriginalPrice = 1299,
    //                Features = "<p>吃住行游购娱</p>",
    //                Fees = "<p>交通费用自理</p>",
    //                Notes="<p>小心危险</p>"
    //            },
    //            new TouristRoute {
    //                Id = Guid.NewGuid(),
    //                Title = "华山",
    //                Description="华山真好玩",
    //                OriginalPrice = 1299,
    //                Features = "<p>吃住行游购娱</p>",
    //                Fees = "<p>交通费用自理</p>",
    //                Notes="<p>小心危险</p>"
    //            }
    //        };
    //    }
    //    public TouristRoute GetTouristRoute(Guid touristRouteId)
    //    {
    //        return _routes.FirstOrDefault(n=>n.Id==touristRouteId);
    //    }

    //    public IEnumerable<TouristRoute> GetTouristRoutes()
    //    {
    //        return _routes;
    //    }
    //}
}
