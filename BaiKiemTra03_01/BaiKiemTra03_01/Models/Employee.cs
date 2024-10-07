using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BaiKiemTra03_01.Models
{
    public class Employee
    {

        [Key]  // Khóa chính
        public int EmployeeId { get; set; }  // Mã nhân viên

        [Required]
        [StringLength(100)]
        public string Name { get; set; }     // Tên nhân viên

        [Required]
        [StringLength(50)]
        public string Position { get; set; } // Chức vụ

        [ForeignKey("Department")]  // Khóa ngoại liên kết đến Department
        public int DepartmentId { get; set; }  // Mã phòng ban (khóa ngoại)

        [Required]
        public DateTime EmploymentDate { get; set; } // Ngày bắt đầu làm việc

        // Thuộc tính điều hướng (Navigation Property)
        public Department Department { get; set; }
    }
}
