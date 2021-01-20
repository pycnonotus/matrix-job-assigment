using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    /// <summary>
    ///  the default structure of controller
    /// controllers that extension this controller  by default get the route /api/{contrller name}
    /// </summary>
    public abstract class BaseApiController : ControllerBase
    {

    }
}
