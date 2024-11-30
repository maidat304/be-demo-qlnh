using System;
using System.Collections.Generic;

namespace be_demo_qlnh.Models;

public partial class Nhanvien
{
    public int IdNv { get; set; }

    public string? Tennv { get; set; }

    public DateTime? Ngayvl { get; set; }

    public string? Sdt { get; set; }

    public string? Chucvu { get; set; }

    public int? IdNd { get; set; }

    public int? IdNql { get; set; }

    public string? Tinhtrang { get; set; }

    public virtual Nguoidung? IdNdNavigation { get; set; }

    public virtual Nhanvien? IdNqlNavigation { get; set; }

    public virtual ICollection<Nhanvien> InverseIdNqlNavigation { get; set; } = new List<Nhanvien>();

    public virtual ICollection<Phieunk> Phieunks { get; set; } = new List<Phieunk>();

    public virtual ICollection<Phieuxk> Phieuxks { get; set; } = new List<Phieuxk>();
}
