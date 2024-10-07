using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BaiKiemTra03_01.Models
{
    public class Department
    {
        [Key]  // Khóa chính
        public int DepartmentId { get; set; } // Mã phòng ban

        [Required]
        [StringLength(100)]
        public string DepartmentName { get; set; } // Tên phòng ban

        public int NumberOfEmployees { get; set; } // Số lượng nhân viên

        [ForeignKey("Manager")]  // Khóa ngoại liên kết đến Employee nếu có người quản lý
        public int? ManagerId { get; set; }  // Mã quản lý phòng ban (có thể null nếu không có)

        // Thuộc tính điều hướng
        public Employee Manager { get; set; }

        // Thuộc tính điều hướng để truy xuất danh sách nhân viên thuộc phòng ban này
        public ICollection<Employee> Employees { get; set; }
    }
}
