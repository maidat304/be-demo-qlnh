using System;
using System.Collections.Generic;

namespace be_demo_qlnh.Models;

public partial class Nguoidung
{
    public int IdNd { get; set; }

    public string? Email { get; set; }

    public string? Matkhau { get; set; }

    public string? Verifycode { get; set; }

    public string? Trangthai { get; set; }

    public string? Vaitro { get; set; }

    public virtual ICollection<Khachhang> Khachhangs { get; set; } = new List<Khachhang>();

    public virtual ICollection<Nhanvien> Nhanviens { get; set; } = new List<Nhanvien>();
}
