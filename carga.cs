using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Http.Headers;
using System.Web;

namespace Personajes
{
    public class cargaHttp
    {
        public async Task<Datos> cargarApi(string url)
        {
            HttpClient cliente = new HttpClient();
            Datos nuevo = new Datos();
            HttpResponseMessage respuesta = await cliente.GetAsync(url);
            if(respuesta.IsSuccessStatusCode)
            {
                string json = await respuesta.Content.ReadAsStringAsync();
                string subJson = json.Substring(12,json.IndexOf('}') - 11);
                nuevo = JsonSerializer.Deserialize<Datos>(subJson);
            }
            else
            {
                Console.WriteLine("ERROR AL CARGAR DEL API");
            }
            return nuevo;
        }
    }
}