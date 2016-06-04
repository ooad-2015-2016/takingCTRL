using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjekatAutootpad.Autootpad.Models;
using Windows.Web.Http;
using Windows.Web.Http.Headers;
using Windows.Data.Json;
using System.IO;
using Newtonsoft.Json;

namespace ProjekatAutootpad.Autootpad.Servis
{
    class EksterniServis
    {
        JsonObject servicesConfig; 
        string serviceHost;  
        public static string dijeloviName = "_DioService";
        public EksterniServis()
        {               
            servicesConfig = JsonValue.Parse(File.ReadAllText("eksterniServisConfig.json")).GetObject();
            serviceHost = servicesConfig.GetNamedString("serviceHost");
        }
        public async void dodajDio(Dio _dio)
        {
            HttpClient httpClient = new HttpClient();    
            httpClient.DefaultRequestHeaders.Accept.Add(new HttpMediaTypeWithQualityHeaderValue("application/json"));  
            string jsonContents = JsonConvert.SerializeObject(_dio);
            HttpResponseMessage response = await httpClient.PostAsync(new Uri(serviceHost + '/' +dijeloviName), new HttpStringContent(jsonContents, Windows.Storage.Streams.UnicodeEncoding.Utf8, "application/json"));
            JsonValue value = JsonValue.Parse(response.Content.ToString());
        }  
        public async void dodajSveDijelove()
        {  
            HttpClient httpClient = new HttpClient();
            string response = await httpClient.GetStringAsync(new Uri(serviceHost + '/' + dijeloviName));
            JsonValue value = JsonValue.Parse(response);
        }
    }
}
