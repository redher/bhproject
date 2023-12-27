using Company.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Company.Accounts.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("")]
        public async Task<ActionResult> CreateAccount([FromQuery] Guid customerId, [FromQuery] decimal transactionValue)
        {
            try
            {
                await _accountService.CreateAccount(customerId, transactionValue);
                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
