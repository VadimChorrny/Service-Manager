using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SharedController : ControllerBase
    {
        private readonly IStringLocalizer<SharedResource> _sharedResourceLocalizer;

        public SharedController(IStringLocalizer<SharedResource> sharedResourceLocalizer)
        {
            _sharedResourceLocalizer = sharedResourceLocalizer;
        }

        /// <summary>
        /// This endpoint will access the SharedResourece to retrieve the localized data ...
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetsSharedResource")]
        public IActionResult GetUsingSharedResource(string resourceName)
        {
            //var article = _sharedResourceLocalizer["Article"];
            var text = _sharedResourceLocalizer.GetString(resourceName).Value ?? "";
            text = _sharedResourceLocalizer[resourceName] ?? "";

            return Ok(text);
        }
    }
}
