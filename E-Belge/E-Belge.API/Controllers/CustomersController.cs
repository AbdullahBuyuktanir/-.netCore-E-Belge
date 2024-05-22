using Core.Utilities.ResultModel.Concrete;
using Core.Utilities.Results;
using E_Belge.Business.Abstract;
using E_Belge.Model.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace E_Belge.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CustomersController : ControllerBase
  {
    private readonly ICustomerService _service;

    public CustomersController(ICustomerService service)
    {
      _service = service;
    }

    [HttpGet("getCustomerByCariNo/{cariNo}")]
    public  IActionResult GetCustomerByCariNo(int cariNo)
    {
      var result = _service.GetCustomerByCariNo(cariNo);
      if (result.IsSuccess)
        return Ok(result);

      return NotFound(result);
    }

    [HttpGet("getCustomerByVkn/{vergiNo}")]
    public IActionResult GetCustomerByVkn(string vergiNo)
    {
      var result =  _service.GetCustomerByVkn(vergiNo);
      if (result.IsSuccess)
        return Ok(result);

      return NotFound(result);
    }

    [HttpGet("getCustomer")]
    public async Task<IActionResult> GetAll([FromQuery] PaginationQuery pagination)
    {
      var result = await _service.GetCustomerAllAsync(pagination);
      if (result.IsSuccess)
        return Ok(result);

      return BadRequest(result);
    }

    [HttpPost("createCustomer")]
    public IActionResult CreateCustomer([FromBody] CreateUpdateCariDto cariDto)
    {
      var result = _service.InsertCustomer(cariDto);
      if (result.IsSuccess)
        return Created("", result);

      return BadRequest(result);
    }

    [HttpPut("updateCustomer")]
    public IActionResult UpdateCustomer([FromBody] CreateUpdateCariDto cariDto)
    {
      var result = _service.UpdateCustomer(cariDto);
      if (result.IsSuccess)
        return Ok(result);

      return BadRequest(result);
    }

    [HttpDelete("deleteCustomerByCariNo/{cariNo}")]
    public IActionResult DeleteCustomerByCariNo(int cariNo)
    {
      var result = _service.DeleteCustomerByCariNo(cariNo);
      if (result.IsSuccess)
        return Ok(result);

      return BadRequest(result);
    }

    [HttpDelete("deleteCustomerByVkn{vergiNo}")]
    public IActionResult DeleteCustomerByVkn(string vergiNo)
    {
      var result = _service.DeleteCustomerByVkn(vergiNo);
      if (result.IsSuccess)
        return Ok(result);

      return BadRequest(result);
    }
  }
}
