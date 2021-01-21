using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public abstract class BaseApiController : ControllerBase
    {

    }
}
