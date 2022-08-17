using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shopping.Interfaces;
using Shopping.Models;

namespace Shopping.Pages;

public class CartModel : PageModel
{
    private readonly IBasketService _basketService;

    public CartModel(IBasketService basketService)
    {
        _basketService = basketService ?? throw new ArgumentNullException(nameof(basketService));
    }

    public BasketModel? Cart { get; set; } = new BasketModel();

    public async Task<IActionResult> OnGetAsync()
    {
        var username = "swn";
        Cart = await _basketService.GetBasket(username);

        return Page();
    }

    public async Task<IActionResult> OnPostRemoveToCartAsync(string productId)
    {
        var username = "swn";
        var basket = await _basketService.GetBasket(username);

        var item = basket.Items.Single(x => x.ProductId == productId);
        basket.Items.Remove(item);

        var basketUpdated = await _basketService.UpdateBasket(basket);

        return RedirectToPage();
    }
}