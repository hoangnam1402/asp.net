using AutoMapper;
using BackEnd.DTO.CustomerDTO;
using BackEnd.Model;
using ClassLibrary.Interface;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Service
{
    public class ClassCustomer : ICustomerClass
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;

        public ClassCustomer(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public async Task<User> GetById(string id)
        {
            User user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return null;
            return user;
        }

        public async Task<IdentityResult> Register(CreateUserDto request, string role)
        {
            var roleCheck = await _roleManager.FindByNameAsync(role);
            if (roleCheck == null)
            {
                return IdentityResult.Failed(
                   new IdentityError[] {
                      new IdentityError{
                         Code = "0002",
                         Description = "This role doesn't exist"
                      }
                   }
                   );
            }
            else
            {
                var user = new User
                {
                    UserName = request.Name,
                    Name = request.Name,
                    PhoneNumber = request.PhoneNumber,
                    PhoneNumberConfirmed = true,
                    Address = request.Address,
                };
                var result = await _userManager.CreateAsync(user, request.Password);

                result = _userManager.AddToRoleAsync(user, role).Result;

                result =
                _userManager.AddClaimsAsync(
                    user,
                    new Claim[]
                    {
                            new Claim(JwtClaimTypes.Name, user.UserName),
                            new Claim(JwtClaimTypes.Role, role)
                    }
                ).Result;
                return result;
            }

        }
    }
}