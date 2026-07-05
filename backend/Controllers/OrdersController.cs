using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    [HttpPost]
    public IActionResult CreateOrder([FromBody] OrderRequest request)
    {
        var order = new
        {
            OrderId = Guid.NewGuid(),
            ProductId = request.ProductId,
            Quantity = request.Quantity,
            Status = "Created",
            CreatedAt = DateTime.UtcNow
        };

        return Ok(new
        {
            message = "Order placed successfully",
            order
        });
    }
}

public class OrderRequest
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}
