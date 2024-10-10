using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project13_WeatherAppProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://open-weather13.p.rapidapi.com/city/istanbul/TR"),
                Headers =
    {
        { "x-rapidapi-key", "1cd0b07e55msh766ca1b28cc97eep1ddf20jsn394261c6dd7d" },
        { "x-rapidapi-host", "open-weather13.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var json = JObject.Parse(body);

                var fahrenheit = json["main"]["feels_like"].ToString();
                lblFahrenheit.Text = fahrenheit;

                var windSpeed = json["wind"]["speed"].ToString();
                lblWindSpeed.Text = windSpeed;

                var humidity = json["main"]["humidity"].ToString();
                lblHumidity.Text = humidity;

                double celcius = (double.Parse(fahrenheit) - 32) / 1.8;
                lblCelcius.Text = celcius.ToString("0.00");

                var main = json["weather"][0]["main"].ToString();

                string imagePath = @"C:\Users\Fatma Birel\Desktop\Udemy20Project\Project13_WeatherAppProject\images\";
                string imageFile = ""; 

                switch (main)
                {
                    case "Clouds":
                        imageFile = "cloud.png";
                        break;

                    case "Clear":
                        imageFile = "cloudandsun.png";
                        break;

                    case "Rain":
                        imageFile = "rainy.png";
                        break;

                    case "Snow":
                        imageFile = "snow.png";
                        break;

                    case "Sun":
                        imageFile = "sun.png";
                        break;

                    default:
                        imageFile = "cloudandsun.png"; // Default görsel
                        break;
                }

                string fullImagePath = Path.Combine(imagePath, imageFile);
                pictureBox1.Image = Image.FromFile(fullImagePath);


            }
        }
    }
}
