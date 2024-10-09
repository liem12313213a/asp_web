using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BaiKiemTra03_04.Models
{
    public class Supplier
    {
        [Key]
        public int supplier_Id { get; set; }

        [Required(ErrorMessage = "vui lòng nhập tên nhà cung cấp")]
        [Display(Name = "tên nhà cung cấp")]
        public string? supplier_name { get; set; }

        [Required(ErrorMessage = "vui lòng nhập địa chỉ nhà cung cấp ")]
        [Display(Name = "address")]
        public string? address { get; set; }

        [Required(ErrorMessage = "vui lòng nhập số điện thoại")]
        [Display(Name = "số điện thoại")]
        public int phone_number { get; set; }

        [Required(ErrorMessage = "vui lòng nhập email")]
        [Display(Name = "email")]
        public string? email { get; set; }

    }
}
