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
        public List<Product> GetProduct();

        public Product GetProductDetail(Guid id);
    }
}
