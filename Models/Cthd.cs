using System;
using System.Collections.Generic;

namespace be_demo_qlnh.Models;

public partial class Cthd
{
    public int? IdHoadon { get; set; }

    public int? IdMonan { get; set; }

    public byte? Soluong { get; set; }

    public int? Thanhtien { get; set; }

    public virtual Hoadon? IdHoadonNavigation { get; set; }

    public virtual Monan? IdMonanNavigation { get; set; }
}
