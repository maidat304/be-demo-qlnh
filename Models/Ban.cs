using System;
using System.Collections.Generic;

namespace be_demo_qlnh.Models;

public partial class Ban
{
    public int IdBan { get; set; }

    public string? Tenban { get; set; }

    public string? Vitri { get; set; }

    public string? Trangthai { get; set; }

    public virtual ICollection<Hoadon> Hoadons { get; set; } = new List<Hoadon>();
}
