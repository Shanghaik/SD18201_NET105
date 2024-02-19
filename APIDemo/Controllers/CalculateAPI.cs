using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculateAPI : ControllerBase
    {
        [HttpGet("random-number")] 
        public int GetRandomNumber()
        {
            Random r = new Random();
            return r.Next(10, 1000);
        }
        // Request URL sẽ bao gồm: đường dẫn trong launch setting/tên mặc định cấu hình/tên cụ thể
        [HttpGet("get-bmi")] 
        public double GetBMI(double weight, double height) {
            return weight / (height * height); // weight:kg, height: m
        }
        [HttpGet("calculate-interest")] // tính lãi
        public double CalculateInterest(double money, int day, double percentage)
        {
            // Lãi tổng số tiền cuối cùng trừ đi tiền gốc
            return money * Math.Pow(1+percentage/100, day)  - money;
            // Mỗi ngày số tiền sẽ được nhân lên theo tỉ lệ lãi kép
        }
    }
}
