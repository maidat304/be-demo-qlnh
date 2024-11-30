using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace be_demo_qlnh.DTOs
{
    public class VoucherDTO
    {
        public string CodeVoucher { get; set; } = null!;

        public string? Mota { get; set; }

        public byte? Phantram { get; set; }

        public string? Loaima { get; set; }

        public byte? Soluong { get; set; }

        public int? Diem { get; set; }
    }
}