using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FakeXiecheng.API.Models
{
    public class TouristRoute
    {
        [Key]
        public Guid Id { get; set; }                    //编号
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }               //标题名称
        [Required]
        [MaxLength(1500)]
        public string Description { get; set; }         //描述
        [Column(TypeName ="decimal(18,2)")]
        public decimal OriginalPrice { get; set; }      //原价
        [Range(0.0,1.0)]
        public double? DiscountPresent { get; set; }    //折扣

        public DateTime CreateTime { get; set; }        //创建时间
        public DateTime? UpdateTime { get; set;}        //修改时间
        public DateTime? DepartureTime { get; set; }    //出发时间
        [MaxLength]
        public string Features { get; set; }            //卖点介绍
        [MaxLength]
        public string Fees { get; set; }                //费用说明
        [MaxLength]
        public string Notes { get; set; }               //注意事项

        public ICollection<TouristRoutePicture> TouristRoutePictures { get; set; }//一对多的关系，记得使用复数
        = new List<TouristRoutePicture>();

        public double? Rating { get; set; }

        public TravelDays? TravelDays { get; set; }

        public TripType? TripType { get; set; }

        public  DepartureCity? DepartureCity { get; set;}
    }
}
