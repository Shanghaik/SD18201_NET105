using Newtonsoft.Json;

namespace DemoAPI_WF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void btn_xacnhan_ClickAsync(object sender, EventArgs e)
        {
            double monney = Convert.ToDouble(tbt_money.Text);
            int day = Convert.ToInt32(tbt_day.Text);
            double percentage = Convert.ToDouble(tbt_percentage.Text);
            string requestURL = @$"https://localhost:7191/api/CalculateAPI/calculate-interest?money={monney}&day={day}&percentage={percentage}";
            // Tạo ra đt HTTP Client 
            var httpClient = new HttpClient();
            var reponse = await httpClient.GetAsync(requestURL);
            // Thực hiện gửi request để trả về response là kết quả của các phép xử lý
            string apiData = await reponse.Content.ReadAsStringAsync();
            string result = JsonConvert.DeserializeObject<string>(apiData);
            // Đọc kết quả cuối từ string Json được trả về
            lb_ketqua.Text = $"Chúc mừng gia đình được gánh khoản nợ là {result}";
        }
    }
}