using Online.DTOs;
using Online.Models;
using Online.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Online.Controllers;

[ApiController]
[Route("api/products")]
public class ProductsController : ControllerBase
{
    private readonly ILogger<ProductsController> _logger;
    private readonly IProductsRepository _products;
    //private readonly ICustomerRepository _hardware;

    public ProductsController(ILogger<ProductsController> logger,
    IProductsRepository products)
    {
        _logger = logger;
        _products = products;
       // _hardware = hardware;
    }

    [HttpGet]
    public async Task<ActionResult<List<ProductsDTO>>> GetAllProducts()
    {
        var productsList = await _products.GetList();

        // User -> UserDTO
        var dtoList = productsList.Select(x => x.asDto);

        return Ok(dtoList);
    }

    [HttpGet("{product_id}")]
    public async Task<ActionResult<ProductsDTO>> GetById([FromRoute] long product_id)
    {
        var products = await _products.GetById(product_id);

        if (products is null)
            return NotFound("No Product found with given product id");

        // var dto = products.asDto;

        // dto.Products = (await _products.GetListByProductId(product_id)).Select(x => x.asDto).ToList();

        return Ok(products);
    }

    [HttpPost]
    public async Task<ActionResult<ProductsDTO>> CreateProducts([FromBody] ProductsCreateDTO Data)
    {
        // var products = await _products.GetById(Data.ProductId);
        // if (products is null)
        //     return NotFound("No Product found with given product id");

        var toCreateProducts = new Products
        {
            ProductName = Data.ProductName.Trim(),
            Discription = Data.Discription,
            Price = Data.Price,
            

        };

        var createdProducts = await _products.Create(toCreateProducts);

        return StatusCode(StatusCodes.Status201Created, createdProducts.asDto);
    }

    [HttpPut("{product_id}")]
    public async Task<ActionResult> UpdateProducts([FromRoute] long product_id,
    [FromBody] ProductsUpdateDTO Data)
    {
        var existing = await _products.GetById(product_id);
        if (existing is null)
          return NotFound("No Products found with given product id");

        var toUpdateProducts = existing with
        {
            ProductName = Data.ProductName?.Trim()?.ToLower() ?? existing.ProductName,
            Discription = existing.Discription,
            Price = existing.Price,
    
        };

        var didUpdate = await _products.Update(toUpdateProducts);

        if (!didUpdate)
            return StatusCode(StatusCodes.Status500InternalServerError, "Could not update products");

        return NoContent();
    }

    [HttpDelete("{product_id}")]
    public async Task<ActionResult> DeleteProducts([FromRoute] long product_id)
    {
        var existing = await _products.GetById(product_id);
        if (existing is null)
            return NotFound("No product found with given product id");

        var didDelete = await _products.Delete(product_id);

        return NoContent();
    }
}