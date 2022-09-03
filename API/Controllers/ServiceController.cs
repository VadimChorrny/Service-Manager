//using System.Net;

using System.Net.Http.Headers;
using Core.Exceptions;
using Core.Interfaces.CustomServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

//using Microsoft.Net.Http.Headers;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService _serviceService;

        [Route("getDataFromExcel")]
        [HttpPost]
        public async Task<HttpResponseMessage> GetDataFromExcel(IFormFile file)
        {
            //var httpRequest = HttpContext.Request.;
            //if (httpRequest.Files.Count > 0)
            //{

            //}
            //var files = HttpContext.Request.Form.Files;

            //HttpRequestMessage request = this.Request;
            //if (!request.Content.IsMimeMultipartContent())
            //{
            //    throw new HttpException("Incorrect file",HttpStatusCode.UnsupportedMediaType);
            //}
            //var file = Request.Form.Files[0];
            var folderName = Path.Combine("Resources", "ExcelFiles");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            if (file.Length > 0)
            {
                var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                var fullPath = Path.Combine(pathToSave, fileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                if (await _serviceService.SaveFromExcel(fullPath))
                {
                    return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
                }
                
            }
            return new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);
        }

        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }
    }
}