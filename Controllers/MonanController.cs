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
    [Route("api/menu")]
    public class MonanController : ControllerBase
    {
        private readonly ModelContext _context;
        public MonanController(ModelContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var monan = await _context.Monans.ToListAsync();
            return Ok( new {
                success = true,
                data = monan
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MonanDTO monanDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { success = false, error = "Thông tin không hợp lệ" });

            var maxIdMonan = await _context.Monans.MaxAsync(x => (int?)x.IdMonan) ?? 0;
            var monan = new Monan
            {
                IdMonan = maxIdMonan + 1,
                Tenmon = monanDTO.Tenmon,
                Dongia = monanDTO.Dongia,
                Loai = monanDTO.Loai,
                Trangthai = "Dang kinh doanh"
            };

            _context.Monans.Add(monan);
            await _context.SaveChangesAsync();

            return Ok(new { success = true, message = "Thêm thành công" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] MonanDTO monanDTO)
        {
            var monan = await _context.Monans.FindAsync(id);
            if (monan == null)
            {
                return NotFound(new { success = false, error = "Không tìm thấy" });
            }
            if (!ModelState.IsValid)
                return BadRequest(new { success = false, error = "Thông tin không hợp lệ" });

            monan.Tenmon = monanDTO.Tenmon;
            monan.Dongia = monanDTO.Dongia;
            monan.Loai = monanDTO.Loai;
            monan.Trangthai = "Dang kinh doanh";

            await _context.SaveChangesAsync();

            return Ok(new { success = true, message = "Cập nhật thành công" });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            var monan = await _context.Monans.FindAsync(id);
            if (monan == null)
            {
                return NotFound(new { success = false, message = "Mon an noi found"});
            }

            monan.Trangthai = "Ngung kinh doanh";
            await _context.SaveChangesAsync();
            return Ok(new { success = true, message = "Xóa thành công" });
        }
    }
}