using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace TestAPI_Console
{
    internal class Program
    {
        static async void Main(string[] args)
        {
            // Call API bằng cách nào?
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Hãy nhập số tiền mà bạn muốn vay");
            double monney = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Hãy nhập số ngày bạn muốn mượn");
            int day = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Lãi xuất bọn muốn là?");
            double percentage = Convert.ToDouble(Console.ReadLine());
            // Truyền được các giá trị đó vào Request URL
            string requestURL = @$"https://localhost:7191/api/CalculateAPI/
            calculate-interest?money={monney}&day={day}&percentage={percentage}";
            // Tạo ra đt HTTP Client 
            var httpClient = new HttpClient();
            var reponse = await httpClient.GetAsync(requestURL); 
            // Thực hiện gửi request để trả về response là kết quả của các phép xử lý
            string apiData = await reponse.Content.ReadAsStringAsync(); 
            string result = JsonConvert.DeserializeObject<string>(apiData);
            // Đọc kết quả cuối từ string Json được trả về
            Console.WriteLine("Chúc mừng gia đình được gánh khoản nợ là {result}");
        }
    }
}