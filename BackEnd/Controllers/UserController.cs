using AutoMapper;
using BackEnd.DTO.CustomerDTO;
using BackEnd.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //private readonly UserManager<User> _userManager;
        //private readonly RoleManager<IdentityRole> _roleManager;
        //private readonly IMapper _mapper;

        //public UserController(UserManager<User> userManager)
        //{
        //    _userManager = userManager;
        //}


        //[HttpGet]
        //public async Task<List<ReadUserDto>> Get()
        //{
        //    User user = await _userManager.FindByIdAsync(id);
        //    if (user == null)
        //        return null;
        //    return _mapper.Map<ReadUserDto>(user);
        //    var user = await _context.categories.ToListAsync();
        //    if (category == null)
        //        return BadRequest("Category not found.");

        //    var response = _mapper.Map<List<ReadCategoryDto>>(category);
        //    return Ok(response);

        //}
    }
}
