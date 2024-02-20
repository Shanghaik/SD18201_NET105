using Demo_API_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Demo_API_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> PrivacyAsync(double monney, int day, double percentage)
        { // Các tham số phải map với thuộc tính name bên html
            string requestURL = @$"https://localhost:7191/api/CalculateAPI/calculate-interest?money={monney}&day={day}&percentage={percentage}";
            // Tạo ra đt HTTP Client 
            var httpClient = new HttpClient();
            var reponse = await httpClient.GetAsync(requestURL);
            // Thực hiện gửi request để trả về response là kết quả của các phép xử lý
            string apiData = await reponse.Content.ReadAsStringAsync();
            string result = JsonConvert.DeserializeObject<string>(apiData);
            ViewData["result"] = result;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}