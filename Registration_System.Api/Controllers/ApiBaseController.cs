using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Registration_System.Api.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ApiBaseController : ControllerBase
    {
    }
}
