using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaiKiemTra03_01.Models
{
    public class Department
    {
        [Key] // Đánh dấu đây là khóa chính
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên phòng ban là bắt buộc.")]
        [StringLength(100, ErrorMessage = "Tên phòng ban không được vượt quá 100 ký tự.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Số lượng nhân viên là bắt buộc.")]
        public int NumberOfEmployees { get; set; }

        [Required(ErrorMessage = "Mã quản lý là bắt buộc.")]
        public int ManagerId { get; set; }
    }
}
