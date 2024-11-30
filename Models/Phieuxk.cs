using System;
using System.Collections.Generic;

namespace be_demo_qlnh.Models;

public partial class Phieuxk
{
    public int IdXk { get; set; }

    public int? IdNv { get; set; }

    public DateTime? Ngayxk { get; set; }

    public virtual Nhanvien? IdNvNavigation { get; set; }
}
