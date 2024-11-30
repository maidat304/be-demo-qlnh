using System;
using System.Collections.Generic;

namespace be_demo_qlnh.Models;

public partial class Khachhang
{
    public int IdKh { get; set; }

    public string? Tenkh { get; set; }

    public DateTime? Ngaythamgia { get; set; }

    public int? Doanhso { get; set; }

    public short? Diemtichluy { get; set; }

    public int? IdNd { get; set; }

    public virtual ICollection<Hoadon> Hoadons { get; set; } = new List<Hoadon>();

    public virtual Nguoidung? IdNdNavigation { get; set; }
}
