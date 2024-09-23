using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace BaiTapVN03.Models
{
    public class NhaCungCap
    {
        public int Id { get; set; }
        public string Ten { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        //public string ImageUrl {  get; set; }
    }
}
