using AutoMapper;
using BackEnd.DTO.CustomerDTO;
using BackEnd.Model;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    internal class ClassCustomer : ICustomerClass
    {
        //private readonly UserManager<Customer> _userManager;
        //private readonly RoleManager<IdentityRole> _roleManager;
        //private readonly IMapper _mapper;

        //public ClassCustomer(UserManager<Customer> userManager, RoleManager<IdentityRole> roleManager, IMapper mapper)
        //{
        //    _userManager = userManager;
        //    _roleManager = roleManager;
        //    _mapper = mapper;
        //}

        //public async Task<ReadCustomerDto> GetById(string id)
        //{
        //    Customer user = await _userManager.FindByIdAsync(id);
        //    if (user == null)
        //        return null;
        //    return _mapper.Map<ReadCustomerDto>(user);
        //}

        //public async Task<IdentityResult> Register(CreateCustomerDto request, string role)
        //{


        //    var user = new Customer
        //    {
        //        name = request.name,
        //        Address = request.Address,
        //        PhoneNumber = request.PhoneNumber,
        //        PhoneNumberConfirmed = true,
        //    };
        //    var result = await _userManager.CreateAsync(user, request.Password);


        //    result = _userManager.AddToRoleAsync(user, role).Result;

        //    result =
        //    _userManager.AddClaimsAsync(
        //        user,
        //        new Claim[]
        //        {
        //                new Claim(JwtClaimTypes.Name, user.name)
        //        }
        //    ).Result;
        //    return result;

        //}
    }
}