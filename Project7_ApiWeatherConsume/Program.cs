#region Menü_Başlangıcı
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

Console.BackgroundColor = ConsoleColor.Cyan; // Arka plan rengini turkuaz yap
Console.ForegroundColor = ConsoleColor.Black; // Yazı rengini siyah yap
Console.Clear(); // Konsolu temizle ve yeni renkleri uygula


Console.WriteLine("Api Consume İşlemine Hoşgeldiniz");
Console.WriteLine();
Console.WriteLine("### Yapmak İstediğiniz İşlemi Seçin ###");
Console.WriteLine();
Console.WriteLine("1- Şehir Listesini Getirin");
Console.WriteLine("2- Şehir ve Hava Durumu Listesini Getirin");
Console.WriteLine("3- Yeni Şehir Ekleme");
Console.WriteLine("4- Şehir Silme İşlemi");
Console.WriteLine("5- Şehir Güncelleme İşlemi");
Console.WriteLine("6- Id'ye Göre Şehir Getirme");
Console.WriteLine();
#endregion

string number;
Console.Write("Tercihiniz: ");
number = Console.ReadLine();
Console.WriteLine();

if (number == "1")
{
    string url = "https://localhost:7236/api/Weathers"; //istek yapılacak url
    using (HttpClient client = new HttpClient()) //http istekleri yapmak için kullanılan sınıf
    {
        HttpResponseMessage response = await client.GetAsync(url); //api'ye GET isteği yapar
        string responseBody = await response.Content.ReadAsStringAsync(); // dönen isteği tutar
        JArray jArray = JArray.Parse(responseBody); // json verisini parse etme
        foreach (var item in jArray)
        {
            string cityName = item["name"].ToString();
            Console.WriteLine($"Şehir: {cityName}");
        }
    }
}
if (number == "2")
{
    string url = "https://localhost:7236/api/Weathers";
    using (HttpClient client = new HttpClient())
    {
        HttpResponseMessage response = await client.GetAsync(url);
        string responseBody = await response.Content.ReadAsStringAsync();
        JArray jArray = JArray.Parse(responseBody);
        foreach (var item in jArray)
        {
            string cityName = item["name"].ToString();
            string cityTemprature = item["temprature"].ToString();
            string country = item["country"].ToString();
            Console.WriteLine(cityName + "-" + country + "-->" + cityTemprature + " derece");
        }
    }
}
if (number == "3")
{
    Console.WriteLine("### Yeni Veri Girişi ###");
    Console.WriteLine();
    string name, country, detail;
    decimal temprature;

    Console.Write("Şehir Adı: ");
    name = Console.ReadLine();

    Console.Write("Ülke Adı: ");
    country = Console.ReadLine();

    Console.Write("Hava Durumu Detayı: ");
    detail = Console.ReadLine();

    Console.Write("Sıcaklık Değeri: ");
    temprature = decimal.Parse(Console.ReadLine());

    string url = "https://localhost:7236/api/Weathers";
    var newWeatherCity = new
    {
        Name = name,
        Country = country,
        Detail = detail,
        Temprature = temprature
    };

    using (HttpClient client = new HttpClient())
    {
        string json = JsonConvert.SerializeObject(newWeatherCity); // nesneyi JSON formatına dönüştürür
        StringContent content = new StringContent(json, Encoding.UTF8, "application/json"); //JSON verisini UTF-8 kodlamasıyla ve "application/json" içeriği olarak hazırlar. Bu, API'ye uygun biçimde veri göndermemizi sağlar.
        HttpResponseMessage response = await client.PostAsync(url, content); // post işlemi yapılır
        response.EnsureSuccessStatusCode(); //  isteğin başarılı olup olmadığını kontrol eder. Eğer başarısız olursa bir hata fırlatır.       
    }
}
if (number == "4")
{
    string url = "https://localhost:7236/api/Weathers?id=";
    Console.Write("Silmek istediğiniz Id Değeri: ");
    int id = int.Parse(Console.ReadLine());

    using (HttpClient client = new HttpClient())
    {
        HttpResponseMessage response = await client.DeleteAsync(url + id); // delete işlemi yapılır
        response.EnsureSuccessStatusCode();
    }
}
if (number == "5")
{
    Console.WriteLine("### Yeni Güncelleme İşlemi ###");
    Console.WriteLine();
    string name, country, detail;
    decimal temprature;
    int Id;

    Console.Write("Şehir Id: ");
    int id = int.Parse(Console.ReadLine());

    Console.Write("Şehir Adı: ");
    name = Console.ReadLine();

    Console.Write("Ülke Adı: ");
    country = Console.ReadLine();

    Console.Write("Hava Durumu Detayı: ");
    detail = Console.ReadLine();

    Console.Write("Sıcaklık Değeri: ");
    temprature = decimal.Parse(Console.ReadLine());

    string url = "https://localhost:7236/api/Weathers";
    var updatedWeatherCity = new
    {
        Id = id,
        Name = name,
        Country = country,
        Detail = detail,
        Temprature = temprature
    };

    using (HttpClient client = new HttpClient())
    {
        string json = JsonConvert.SerializeObject(updatedWeatherCity);
        StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
        HttpResponseMessage response = await client.PutAsync(url, content);
        response.EnsureSuccessStatusCode();
    }
}
if (number == "6")
{
    string url = "https://localhost:7236/api/Weathers/id?id=";
    Console.Write("Bilgilerini Getirmek istediğiniz Id Değeri: ");
    int id = int.Parse(Console.ReadLine());
    Console.WriteLine();

    using (HttpClient client = new HttpClient())
    {
        HttpResponseMessage response = await client.GetAsync(url + id); //api'ye GET isteği yapar
        response.EnsureSuccessStatusCode();
        string responseBody = await response.Content.ReadAsStringAsync();
        JObject cityObject = JObject.Parse(responseBody);
        string name = cityObject["name"].ToString();
        string country = cityObject["country"].ToString();
        string detail = cityObject["detail"].ToString();
        decimal temp = decimal.Parse(cityObject["temprature"].ToString());
        Console.WriteLine("Girmiş olduğunuz Id değerine ait bilgiler");
        Console.WriteLine();
        Console.WriteLine("Şehir: " + name + " Ülke: " + country + " Sıcaklık: " + temp + " Detay: " + detail);
    }
}
Console.Read();