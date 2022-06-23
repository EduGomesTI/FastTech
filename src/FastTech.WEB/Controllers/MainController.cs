using Microsoft.AspNetCore.Mvc;

namespace FastTech.WEB.Controllers;

[ApiController]
public abstract class MainController : ControllerBase
{
    public MainController()
    {

    }

    protected ActionResult CustomResponse(object result)
    {
        return Ok(new
        {
            success = true,
            data = result
        });
    }


}
