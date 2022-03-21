using BackEnd.DTO.OrderDTO;
using ClassLibrary.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Customer.Pages
{
    public class OrderModel : PageModel
    {
        private readonly IOrderClass _orderClass;
        private readonly IOrderItemClass _orderItemClass;

        public OrderModel(IOrderClass orderClass)
        {
            _orderClass = orderClass;

        }

        public ReadOrderDto Order { get; set; }


        public async Task<IActionResult> OnGet(Guid id)
        {
            Order = await _orderClass.GetOrderByIdAsync(id);

            if (Order == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}