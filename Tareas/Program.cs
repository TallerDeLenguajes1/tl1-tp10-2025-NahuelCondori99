using Tareas;
using System.Text.Json;

class Program
{
    static async Task Main(string[] args)
    {
        using HttpClient client = new HttpClient();

        HttpResponseMessage response = await client.GetAsync("https://jsonplaceholder.typicode.com/todos/");
        response.EnsureSuccessStatusCode();

        string responseBody = await response.Content.ReadAsStringAsync();
        List<Tarea> Listtarea = JsonSerializer.Deserialize<List<Tarea>>(responseBody);

        foreach (var tarea in Listtarea)
        {
            if (tarea.completed)
            {
                Console.WriteLine($"{tarea.id}---{tarea.title}---Tarea completada---");
            }
            else
            {
                Console.WriteLine($"{tarea.id}---{tarea.title}---Tarea No completada---");
            }
        }

        string jsonString = JsonSerializer.Serialize(Listtarea, new JsonSerializerOptions { WriteIndented = true });
        string ruta = Path.Combine(Directory.GetCurrentDirectory(), "tareas.json");
        File.WriteAllText(ruta, jsonString);
        Console.WriteLine("Archivo 'tareas.json' creado y cargado con exito.");
    }

}