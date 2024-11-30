using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using be_demo_qlnh.DTOs;
using be_demo_qlnh.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace be_demo_qlnh.Controllers
{
    [Route("api")]
    [ApiController]
    public class loginDTOController : ControllerBase
    {
        public readonly ModelContext _context;
        public loginDTOController(ModelContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { success = false, error = "Thông tin không hợp lệ" });

            // Tìm người dùng trong cơ sở dữ liệu
            var user = await _context.Nguoidungs
                .FirstOrDefaultAsync(u => u.Email == loginDTO.Email && u.Matkhau == loginDTO.Matkhau);

            if (user == null)
            {
                return Unauthorized(new { success = false, error = "Email hoặc mật khẩu không đúng" });
            }

            // Trả về thông tin người dùng cơ bản
            return Ok(new
            {
                success = true,
                message = "Đăng nhập thành công",
                data = new
                {
                    email = loginDTO.Email
                }
            });
        }

    }
}