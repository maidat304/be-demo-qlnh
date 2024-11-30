using System;
using System.Collections.Generic;

namespace be_demo_qlnh.Models;

public partial class Voucher
{
    public string CodeVoucher { get; set; } = null!;

    public string? Mota { get; set; }

    public byte? Phantram { get; set; }

    public string? Loaima { get; set; }

    public byte? Soluong { get; set; }

    public int? Diem { get; set; }

    public virtual ICollection<Hoadon> Hoadons { get; set; } = new List<Hoadon>();
}
