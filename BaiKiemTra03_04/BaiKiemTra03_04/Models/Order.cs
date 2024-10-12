using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using BaiKiemTra03_04.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BaiKiemTra03_04.Models
{
    public class Order
    {
        [Key]
        public int order_Id { get; set; }

        [Required(ErrorMessage = "vui lòng nhập ngày đặt hàng")]
        [Display(Name = "ngày đặt hàng")]
        public DateTime order_date { get; set; }

        [Required(ErrorMessage = "vui lòng nhập tổng giá trị")]
        [Display(Name = "tổng giá trị")]
        public int total_amount { get; set; }

        [Required(ErrorMessage = "vui lòng nhập mã nhà cung cấp ")]
        [Display(Name = "supplier")]

        public int supplier { get; set; }

        [Required(ErrorMessage = "vui lòng nhập tình trạng đơn hàng")]
        [Display(Name = "tình trạng đơn hàng")]
        public int order_status { get; set; }

        [ForeignKey("supplier")]
        [ValidateNever]
        public Supplier Supplier { get; set; }
    }
}
