using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly SalesContext _salesContext;

        public ProductsController(SalesContext salesContext)
        {
            _salesContext = salesContext;
        }

        [HttpGet]
        public ActionResult Get(int take = 10, int skip = 0)
        {
            return Ok(_salesContext.Products?.OrderBy(p => p.ProductId).Skip(skip).Take(take));
        }
    }
}
