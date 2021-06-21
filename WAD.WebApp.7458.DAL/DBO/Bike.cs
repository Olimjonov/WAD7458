using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WAD.WebApp._7458.DAL.DBO
{
    public class Bike
    {
        [Display(Name = "Id")]
        public int BikeId { get; set; }

        [Required]
        [MinLength(4)]
        [Display(Name = "Bike Name")]
        public string BikeName { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        [Display(Name = "Brand")]
        public int BrandId { get; set; }

        public Brand Brand { get; set; }

        [Display(Name = "Model Year")]
        [MaxLength(4)]
        public int ModelYear { get; set; }
        
        [Required]
        public int Price { get; set; }

        [Display(Name = "Photo Byte")]
        public byte[] BinaryPhoto { get; set; }

        [Display(Name = "Photo")]
        [DataType(DataType.Upload)]
        [NotMapped]
        public IFormFile BikePhoto { get; set; }

        [Display(Name = "Arrived Date")]
        [Required]
        public DateTime ArrivedDate { get; set; }

        [Display(Name = "Is Returnable")]
        public bool IsReturnable { get; set; }

    }
}
