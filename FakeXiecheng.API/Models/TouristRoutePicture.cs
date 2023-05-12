using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.ComponentModel.DataAnnotations.Schema;
namespace FakeXiecheng.API.Models
{
    public class TouristRoutePicture
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }              //编号
        [MaxLength(100)]
        public string Url { get; set;}           //链接
        [ForeignKey("TouristRouteId")]
        public Guid TouristRouteId { get; set; } //与旅游路线的外键联系
        public TouristRoute TouristRoute { get; set; }
    }
}
