using System;
using System.Collections.Generic;

namespace be_demo_qlnh.Models;

public partial class Kho
{
    public int? IdNl { get; set; }

    public byte? Slton { get; set; }

    public virtual Nguyenlieu? IdNlNavigation { get; set; }
}
