using Business;
using Microsoft.AspNetCore.Mvc;
using Repository.Dbo;

namespace Lucca.Controllers
{
    [Controller]
    public abstract class BaseController : ControllerBase
    {
        protected readonly ILogger<ControllerBase> _logger;
        protected readonly IConfiguration _configuration;
        protected readonly string _mode;

        public BaseController(ILogger<ControllerBase> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            _mode = configuration["Mode"];
            BaseDbo.Init(_configuration["DatabasePath"]);
        }
    }
}