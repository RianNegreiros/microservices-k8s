using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shopping.Interfaces;
using Shopping.Models;

namespace Shopping.Pages;

public class OrderModel : PageModel
{
    private readonly IOrderService _orderService;

    public OrderModel(IOrderService orderService)
    {
        _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
    }

    public IEnumerable<OrderResponseModel>? Orders { get; set; } = new List<OrderResponseModel>();

    public async Task<IActionResult> OnGetAsync()
    {
        Orders = await _orderService.GetOrderByUsername("swn");

        return Page();
    }
}