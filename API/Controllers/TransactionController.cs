using System.Net.Http.Headers;
using Core.Interfaces.CustomServices;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet("getAllTransactionsBySubscription")]
        public async Task<IActionResult> GetAllTransactionsBySubscription(string id)
        {
            return Ok(await _transactionService.GetAllTransactionsBySubscription(Guid.Parse(id)));
        }
        //[HttpGet]
        //public IActionResult GetTransactions(string key, string account, DateTime fromDate)
        //{
        //    HttpClient client = new HttpClient();
        //    using (var message = new HttpRequestMessage(HttpMethod.Get, "https://api.monobank.ua/personal/statement/{account}/{from}/{to}"))
        //    {
        //        message.Headers.Add("X-Token", key);
        //        //message.Pa
        //    }

        //    return Ok("dd");
        //}
        [HttpPost("addTransactionsFromExcel")]
        public async Task<IActionResult> AddTransactionsFromExcel(IFormFile file)
        {
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

                bool isSucceed = await _transactionService.AddTransactionsFromExcel(fullPath);
                System.IO.File.Delete(fullPath);
                if (isSucceed)
                {
                    return Ok();
                }

            }
            return BadRequest();
        }
    }
}
