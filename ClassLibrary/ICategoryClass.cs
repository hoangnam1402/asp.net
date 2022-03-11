using BackEnd.DTO.CategoryDTO;
using BackEnd.DTO.CustomerDTO;
using BackEnd.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public interface ICategoryClass
    {
        Task<List<ReadCategoryDto>> GetCategories();
    }
}
