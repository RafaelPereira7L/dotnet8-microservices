using GeekShopping.WebUI.Interfaces;
using GeekShopping.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.WebUI.Controllers;

public class ProductsController : Controller
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }
    
    public async Task<IActionResult> Index()
    {
        var products = await _productService.GetProducts();
        return View(products);
    }

    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(ProductModel product)
    {
        if (ModelState.IsValid)
        {
            var response = await _productService.CreateProduct(product);

            if (response != null)
            {
                return RedirectToAction(nameof(Index));
            }
        }
        return View(product);
    }
    
    public async Task<IActionResult> Update(Guid id)
    {
        var product = await _productService.GetProductById(id);
        
        if (product == null)
        {
            return NotFound();
        }
        
        return View(product);
    }
     
    [HttpPost]
    public async Task<IActionResult> Update(ProductModel product)
    {
        if (ModelState.IsValid)
        {
            try
            {
                var response = await _productService.UpdateProduct(product);

                if (response != null)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
            }
        }
        return View(product);
    }
    
    public async Task<IActionResult> Delete(Guid id)
    {
        var product = await _productService.GetProductById(id);
        
        if (product == null)
        {
            return NotFound();
        }
        
        return View(product);
    }
    
    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(Guid id)
    {
        var response = await _productService.DeleteProduct(id);

        Console.WriteLine(response);
        
        if (response)
        {
            return RedirectToAction(nameof(Index));
        }
        return View();
    }
}