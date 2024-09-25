using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Project.Models
{
    public class TheLoai
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage="Không được để trống Tên thể loại!")]
        [Display(Name="Thể loại")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Không đúng định dạng ngày!")]
        [Display(Name = "Ngày tạo")]
        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
    public class SanPham
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        public string? Description { get; set; }
        public string? ImageuRL { get; set; }
        [Required]
        public int TheLoaiId { get; set; }
        [ForeignKey("TheLoaiId")]
        public TheLoai TheLoai { get; set; }
    }
}
