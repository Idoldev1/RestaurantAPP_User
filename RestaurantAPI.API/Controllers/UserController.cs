using MediatR;
using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.Service.Commands;
using RestaurantAPI.Service.Queries;

namespace RestaurantAPI.API.Controllers;


[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;
    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }



    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterUserCommand command)
    {
        try
        {
            var result = await _mediator.Send(command);
            return Ok($"Registeration successful {result} ");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }


    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginUserCommand command)
    {
        try
        {
            var result = await _mediator.Send(command);
            return Ok($"Login Successful {result}");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }



    [HttpGet("userProfile")]
    public async Task<IActionResult> GetUserProfile(GetUserQuery query)
    {
        try
        {
            var result = await _mediator.Send(query);

            if (result == null)
            {
                return NotFound($"User with ID not found.");
            }

            // You might want to return a DTO instead of the actual User entity for security reasons
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }



    [HttpGet("orderItems")]
    public async Task<IActionResult> GetOrderItems(ViewOrderItemsQuery itemsQuery)
    {
        try
        {
            var result = await _mediator.Send(itemsQuery);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}