using Microsoft.AspNetCore.Mvc;

namespace FastTech.WEB.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProdutosController : MainController
{
    public ProdutosController()
    {

    }

    [HttpGet]
    public async Task<IActionResult> BuscarProdutos()
    {
        return Ok();
    }
}
