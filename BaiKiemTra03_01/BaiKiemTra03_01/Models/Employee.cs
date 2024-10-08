using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace BaiKiemTra03_01.Models
{
    public class Employee
    {
        [Key] // Đánh dấu đây là khóa chính
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Tên nhân viên là bắt buộc.")]
        [StringLength(100, ErrorMessage = "Tên nhân viên không được vượt quá 100 ký tự.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Chức vụ là bắt buộc.")]
        [StringLength(50, ErrorMessage = "Chức vụ không được vượt quá 50 ký tự.")]
        public string Position { get; set; }

        [Required(ErrorMessage = "Ngày vào làm là bắt buộc.")]
        [DataType(DataType.Date)]
        public DateTime EmploymentDate { get; set; } = DateTime.Now;

        [Required]
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")] // Liên kết khóa ngoại với bảng Department
        [ValidateNever]
        public Department Department { get; set; }
        
        
        
        
    }
}
