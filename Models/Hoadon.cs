using System;
using System.Collections.Generic;

namespace be_demo_qlnh.Models;

public partial class Hoadon
{
    public int IdHoadon { get; set; }

    public int? IdKh { get; set; }

    public int? IdBan { get; set; }

    public DateTime? Ngayhd { get; set; }

    public int? Tienmonan { get; set; }

    public string? CodeVoucher { get; set; }

    public int? Tiengiam { get; set; }

    public int? Tongtien { get; set; }

    public string? Trangthai { get; set; }

    public virtual Voucher? CodeVoucherNavigation { get; set; }

    public virtual Ban? IdBanNavigation { get; set; }

    public virtual Khachhang? IdKhNavigation { get; set; }
}
