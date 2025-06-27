using Nacionalidad;
using System.Text.Json;

class Program
{
    static async Task Main(string[] args)
    {
        using HttpClient client = new HttpClient();

        HttpResponseMessage response = await client.GetAsync("https://api.nationalize.io/?name=nathaniel");

        response.EnsureSuccessStatusCode();

        string responseBody = await response.Content.ReadAsStringAsync();
        Nacion ListaNacion = JsonSerializer.Deserialize<Nacion>(responseBody);

        if(ListaNacion != null)
        {
            Console.WriteLine($"Nombre: {ListaNacion.name}\n Contador: {ListaNacion.count}\n");
            
            foreach (var pais in ListaNacion.country)
            {
                Console.WriteLine($"Pais: {pais.country_id}\nProbabilidad: {pais.probability}");
            }
        }
        string jsonString = JsonSerializer.Serialize(ListaNacion);
        string ruta = Path.Combine(Directory.GetCurrentDirectory(), "Nacionalidad.json");
        File.WriteAllText(ruta, jsonString);
        Console.WriteLine("Archivo creado y cargado con exito :)");
    }
}