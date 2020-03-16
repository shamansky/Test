using System;
using Microsoft.AspNetCore.Mvc;
using TestSSE.Contexts;
//using TestSSE.Contexts.PostgreSQL;

namespace TestSSE.Controllers
{
    [ApiController]
    [Route("api/testdatabase")]
    public class DummyController : ControllerBase
    {
        private readonly ProductInfoContext _ctx;

        public DummyController(ProductInfoContext ctx)
        {
            _ctx = ctx ?? throw new ArgumentNullException(nameof(ctx));
        }

        [HttpGet]
        public IActionResult TestDatabase()
        {
            return Ok();
        }
    }
}
