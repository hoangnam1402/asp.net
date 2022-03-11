using BackEnd.DTO.ProductDTO;
using BackEnd.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public interface IProductClass
    {
        Task<List<ReadProductDto>> GetProduct();

        Task<ReadProductDto> GetProductDetail(Guid id);
    }
}
