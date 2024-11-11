using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class NhaCungCap
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Tên nhà cung cấp")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Không được để rỗng địa chỉ!")]
        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Không được để rỗng Số điện thoại!")]
        [Display(Name = "Số điện thoại")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Không được để rỗng Email!")]
        [Display(Name = "Email")]
        public string Email { get; set; }

    }
}