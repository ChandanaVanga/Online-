using Online.DTOs;
using Online.Models;
using Online.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Online.Controllers;

[ApiController]
[Route("api/orders")]
public class OrdersController : ControllerBase
{
    private readonly ILogger<OrdersController> _logger;
    private readonly IOrdersRepository _orders;
    // private readonly IUserRepository _user;

    public OrdersController(ILogger<OrdersController> logger,
    IOrdersRepository orders)
    {
        _logger = logger;
        _orders = orders;
        
        // _user = user;
    }

    // [HttpPost]
    // public async Task<ActionResult<Hardware>> CreateHardware([FromBody] HardwareCreateDTO Data)
    // {
    //     var user = await _user.GetById(Data.UserEmployeeNumber);
    //     if (user is null)
    //         return NotFound("No user found with given employee number");

    //     var toCreateHardware = new Hardware
    //     {
    //         Name = Data.Name.Trim(),
    //         MacAddress = Data.MacAddress?.Trim(),
    //         Type = (HardwareType)Data.Type,
    //         UserEmployeeNumber = Data.UserEmployeeNumber,
    //     };

    //     var createdItem = await _hardware.Create(toCreateHardware);

    //     return StatusCode(StatusCodes.Status201Created, createdItem);
    // }
[HttpGet]
    public async Task<ActionResult<List<OrdersDTO>>> GetList()
    {
        var ordersList = await _orders.GetList();

        // User -> UserDTO
        var dtoList = ordersList.Select(x => x.asDto);

        return Ok(dtoList);
    }


    [HttpPut("{order_id}")]
    public async Task<ActionResult> UpdateOrders([FromRoute] int order_id,
    [FromBody] OrdersCreateDTO Data)
    {
        var existing = await _orders.GetById(order_id);
        if (existing is null)
            return NotFound("No Order found with given id");

        var toUpdateItem = existing with
        {
            CustomerId = Data.CustomerId,
            Status = Data.Status?.Trim(),
    
        };

        await _orders.Update(toUpdateItem);

        return NoContent();
    }

    [HttpDelete("{order_id}")]
    public async Task<ActionResult> DeleteOrders([FromRoute] int order_id)
    {
        var existing = await _orders.GetById(order_id);
        if (existing is null)
            return NotFound("No orders found with given id");

        await _orders.Delete(order_id);

        return NoContent();
    }
}
