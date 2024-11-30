using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using be_demo_qlnh.DTOs;
using be_demo_qlnh.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace be_demo_qlnh.Controllers
{
    [Route("api/voucher")]
    [ApiController]
    public class VoucherController : ControllerBase
    {
        private readonly ModelContext _context;
        public VoucherController(ModelContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var voucher = await _context.Vouchers.ToListAsync();
            return Ok(new
            {
                success = true,
                data = voucher
            });
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] VoucherDTO voucherDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { success = false, error = "Thông tin không hợp lệ" });

            var voucher = new Voucher
            {
                CodeVoucher = voucherDTO.CodeVoucher,
                Mota = voucherDTO.Mota,
                Phantram = voucherDTO.Phantram,
                Loaima = voucherDTO.Loaima,
                Soluong = voucherDTO.Soluong,
                Diem = voucherDTO.Diem

            };

            _context.Vouchers.Add(voucher);
            await _context.SaveChangesAsync();

            return Ok(new { success = true, message = "Thêm thành công" });
        }

        [HttpPut("{CodeVoucher}")]
        public async Task<IActionResult> Update([FromRoute] string CodeVoucher, [FromBody] Voucher voucherDTO)
        {
            var voucher = await _context.Vouchers.FindAsync(CodeVoucher);
            if (voucher == null)
            {
                return NotFound(new { success = false, error = "Không tìm thấy" });
            }
            if (!ModelState.IsValid)
                return BadRequest(new { success = false, error = "Thông tin không hợp lệ" });

            voucher.CodeVoucher = voucherDTO.CodeVoucher;
            voucher.Mota = voucherDTO.Mota;
            voucher.Phantram = voucherDTO.Phantram;
            voucher.Soluong = voucherDTO.Soluong;
            voucher.Diem = voucherDTO.Diem;

            await _context.SaveChangesAsync();

            return Ok(new { success = true, message = "Cập nhật thành công" });
        }

        [HttpDelete("{CodeVoucher}")]
        public async Task<ActionResult> Delete([FromRoute] string CodeVoucher)
        {
            var voucher = await _context.Vouchers.FindAsync(CodeVoucher);
            if (voucher == null)
            {
                return NotFound(new { success = false, message = "voucher an noi found" });
            }

            _context.Vouchers.Remove(voucher);
            await _context.SaveChangesAsync();
            return Ok(new { success = true, message = "Xóa thành công" });
        }
    }
}