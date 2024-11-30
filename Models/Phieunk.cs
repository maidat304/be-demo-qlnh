using System;
using System.Collections.Generic;

namespace be_demo_qlnh.Models;

public partial class Phieunk
{
    public int IdNk { get; set; }

    public int? IdNv { get; set; }

    public DateTime? Ngaynk { get; set; }

    public int? Tongtien { get; set; }

    public virtual Nhanvien? IdNvNavigation { get; set; }
}
