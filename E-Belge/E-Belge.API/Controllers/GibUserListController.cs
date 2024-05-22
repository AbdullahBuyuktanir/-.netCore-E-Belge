using Core.Utilities.ResultModel.Concrete;
using E_Belge.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace E_Belge.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class GibUserListController : ControllerBase
  {
    private readonly IGibUserListService _service;

    public GibUserListController(IGibUserListService service)
    {
      _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] PaginationQuery pagination)
    {
      return Ok(await _service.GetGibUserListAllAsync(pagination));
    }

    [HttpGet("{vergiNo}")]
    public IActionResult GetByVKN([FromRoute(Name = "vergiNo")] string vergiNo)
    {
      return Ok( _service.GetGibUserList(vergiNo));
    }
  }
}
