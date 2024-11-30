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
    [Route("api/staff")]
    [ApiController]
    public class NhanvienController : ControllerBase
    {
        private readonly ModelContext _context;
        public NhanvienController(ModelContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var nhanvien = await _context.Nhanviens.Where(nv => nv.Tinhtrang != "Nghi viec").ToListAsync();
            return Ok(new
            {
                success = true,
                data = nhanvien
            });
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] NhanvienDTO nhanvienDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { success = false, error = "Thông tin không hợp lệ" });

            var maxId = await _context.Nhanviens.MaxAsync(n => (int?)n.IdNv) ?? 0;
            var nhanvien = new Nhanvien
            {
                IdNv = maxId + 1,
                Chucvu = nhanvienDTO.Chucvu,
                IdNql = 100,
                Ngayvl = DateTime.Now,
                Sdt = nhanvienDTO.Sdt,
                Tennv = nhanvienDTO.Tennv,
                Tinhtrang = "Dang lam viec"
            };

            _context.Nhanviens.Add(nhanvien);
            await _context.SaveChangesAsync();

            return Ok(new { success = true, message = "Thêm thành công" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] NhanvienDTO nhanvienDTO)
        {
            var staff = await _context.Nhanviens.FindAsync(id);
            if (staff == null)
            {
                return NotFound(new { success = false, error = "Không tìm thấy" });
            }
            if (!ModelState.IsValid)
                return BadRequest(new { success = false, error = "Thông tin không hợp lệ" });

            staff.Chucvu = nhanvienDTO.Chucvu;
            staff.Sdt = nhanvienDTO.Sdt;
            staff.Tennv = nhanvienDTO.Tennv;

            await _context.SaveChangesAsync();

            return Ok(new { success = true, message = "Cập nhật thành công" });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            var nhanvien = await _context.Nhanviens.FindAsync(id);
            if (nhanvien == null)
            {
                return NotFound(new { success = false, message = "staff an noi found" });
            }

            nhanvien.Tinhtrang = "Nghi viec";
            await _context.SaveChangesAsync();
            return Ok(new { success = true, message = "Xóa thành công" });
        }
    }
}