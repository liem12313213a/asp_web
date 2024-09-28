using System.ComponentModel.DataAnnotations;

namespace BaiKiemTraSo2.Models
{
    public class LopHoc
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên lớp học không được để trống")]
        [Display(Name = "Tên Lớp Học")]
        public string TenLopHoc { get; set; }

        [Required(ErrorMessage = "Năm nhập học không được để trống")]
        [Display(Name = "Năm học")]
        public DateTime NamNhapHoc { get; set; }

        [Required(ErrorMessage = "Năm ra trường không được để trống")]
        [Display(Name = "Năm ra trường")]
        public DateTime NamRaTruong { get; set; }

        [Required(ErrorMessage = "Số lượng sinh viên không được để trống")]
        [Display(Name = "Số lượng")]
        public int SoLuongSinhVien { get; set; }
    }
}