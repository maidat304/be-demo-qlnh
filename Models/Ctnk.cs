using System;
using System.Collections.Generic;

namespace be_demo_qlnh.Models;

public partial class Ctnk
{
    public int? IdNk { get; set; }

    public int? IdNl { get; set; }

    public byte? Soluong { get; set; }

    public int? Thanhtien { get; set; }

    public virtual Phieunk? IdNkNavigation { get; set; }

    public virtual Nguyenlieu? IdNlNavigation { get; set; }
}
