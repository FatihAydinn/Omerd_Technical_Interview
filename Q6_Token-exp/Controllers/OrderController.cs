using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Q6_Token_exp.Services;

namespace Q6_Token_exp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GerOrders()
        {
            var tokenService = new TokenService();
            var token = await tokenService.GetToken();

            using var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var response = await client.GetAsync("https://xyz.com/api/orders");
            var content = await response.Content.ReadAsStringAsync();

            return Content(content, "application/json");
        }
    }
}
