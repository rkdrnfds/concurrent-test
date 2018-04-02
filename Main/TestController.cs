using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Main
{
    [Route("Test")]
    public class TestController : Controller
    {
        readonly ILogger _logger;
        private readonly MyDbContext _dbContext;

        public TestController(
            ILogger<TestController> logger, MyDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpGet("DoNothingGet")]
        public void DoNothingGet()
        {
        }

        [HttpPost("GetBlog")]
        public Blog GetBlog([FromBody] int key)
        {
            return _dbContext.Blogs.SingleOrDefault(b => b.Key == key);
        }
    }
}