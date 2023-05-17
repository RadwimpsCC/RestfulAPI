using FakeXiecheng.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace FakeXiecheng.API.Database
{
    public class AppDbContext: IdentityDbContext<IdentityUser>//DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            :base(options)
        { 
        
        }
        //映射
        public  DbSet<TouristRoute> TouristRoutes { get; set; }       
        public DbSet<TouristRoutePicture>  touristRoutePictures { get; set; }

        //重写数据模型
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //添加数据模型
            //modelBuilder.Entity<TouristRoute>().HasData(new TouristRoute() { 

            //    Id=Guid.NewGuid(),
            //    Title="Test",
            //    Description="1",
            //    OriginalPrice=0,
            //    CreateTime=DateTime.UtcNow

            //});
            //获取文件地址
            var touristRouteJsonData= File.ReadAllText(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)+@"/Database/touristRoutesMockData.json");
            IList<TouristRoute> touristRoutes = JsonConvert.DeserializeObject<IList<TouristRoute>>(touristRouteJsonData);
            modelBuilder.Entity<TouristRoute>().HasData(touristRoutes);


            var touristRoutePictureJsonData = File.ReadAllText(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"/Database/touristRoutePicturesMockData.json");
            IList<TouristRoutePicture> touristRoutePictures = JsonConvert.DeserializeObject<IList<TouristRoutePicture>>(touristRoutePictureJsonData);
            modelBuilder.Entity<TouristRoutePicture>().HasData(touristRoutePictures);

            base.OnModelCreating(modelBuilder); 
        }
    }
}
