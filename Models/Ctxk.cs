using System;
using System.Collections.Generic;

namespace be_demo_qlnh.Models;

public partial class Ctxk
{
    public int? IdXk { get; set; }

    public int? IdNl { get; set; }

    public byte? Soluong { get; set; }

    public virtual Nguyenlieu? IdNlNavigation { get; set; }

    public virtual Phieuxk? IdXkNavigation { get; set; }
}
