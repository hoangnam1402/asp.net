using BackEnd.DTO.CustomerDTO;
using BackEnd.Model;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Interface
{
    public interface ICustomerClass
    {
        Task<IdentityResult> Register(CreateUserDto request, string role);

        Task<User> GetById(string id);
    }
}
