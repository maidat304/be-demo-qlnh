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
    [Route("api/customer")]
    [ApiController]
    public class KhachhangController : ControllerBase
    {
        private readonly ModelContext _context;
        public KhachhangController(ModelContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var khachhang = await _context.Khachhangs.ToListAsync();
            return Ok(new
            {
                success = true,
                data = khachhang
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] KhachhangDTO khachhangDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { success = false, error = "Thông tin không hợp lệ" });

            // Lấy IdKh lớn nhất từ bảng Khachhangs
            int maxId = await _context.Khachhangs.MaxAsync(k => (int?)k.IdKh) ?? 0;

            // Tạo khách hàng mới với IdKh = maxId + 1
            var khachhang = new Khachhang
            {
                IdKh = maxId + 1,
                Tenkh = khachhangDTO.Tenkh,
                Ngaythamgia = DateTime.Now,
                Doanhso = khachhangDTO.Doanhso,
                Diemtichluy = khachhangDTO.Diemtichluy
            };

            _context.Khachhangs.Add(khachhang);
            await _context.SaveChangesAsync();

            return Ok(new { success = true, message = "Thêm thành công", id = khachhang.IdKh });
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] KhachhangDTO khachhangDTO)
        {
            var khachhang = await _context.Khachhangs.FindAsync(id);
            if (khachhang == null)
            {
                return NotFound(new { success = false, error = "Không tìm thấy" });
            }
            if (!ModelState.IsValid)
                return BadRequest(new { success = false, error = "Thông tin không hợp lệ" });

            khachhang.Tenkh = khachhangDTO.Tenkh;
            khachhang.Doanhso = khachhangDTO.Doanhso;
            khachhang.Diemtichluy = khachhangDTO.Diemtichluy;

            await _context.SaveChangesAsync();

            return Ok(new { success = true, message = "Cập nhật thành công" });
        }

    }
}