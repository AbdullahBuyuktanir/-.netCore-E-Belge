using Core.Utilities.ResultModel.Concrete;
using E_Belge.Business.Abstract;
using E_Belge.Model.Classes;
using E_Belge.Model.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using System.IO.Compression;
using System.Net;
using System.Text;
using System.Xml.Serialization;

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

    [HttpPost("bulkInsert")]
    public IActionResult BulkInsertGibUserList()
    {
      _service.BulkInsertGibUserList();

      /*  var result = _service.InsertCustomer(cariDto);
        if (result.IsSuccess)
          return Created("", result);
      */
      return BadRequest();
    }
  }
}
