using System.Diagnostics.Tracing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text.Json;
using Usuarios;

class Program
{
    static async Task Main(string[] args)
    {
        using HttpClient client = new HttpClient();

        HttpResponseMessage response = await client.GetAsync("https://jsonplaceholder.typicode.com/users");
        response.EnsureSuccessStatusCode();

        string responseBody = await response.Content.ReadAsStringAsync();
        List<Usuario> ListUsuarios = JsonSerializer.Deserialize<List<Usuario>>(responseBody);

        /*
        foreach (var usu in ListUsuarios)
        {
            Console.WriteLine($"Nombre: {usu.name}\nCorreo electronico: {usu.email}\nDireccion: {usu.address.street}");
            Console.WriteLine("-------------------------");
        }
        */
        List<string> usuariosDatos = new List<string>
        {
            "Nombre del usuario ;Correo electronico ;Direccion "
        };

        foreach (var usu in ListUsuarios)
        {
            if (usu.id <= 5)
            {
                Console.WriteLine($"ID: {usu.id}\nNombre: {usu.name}\nCorreo electronico: {usu.email}\nDireccion: {usu.address.street}");
                Console.WriteLine("-------------------------");
                string agregar = $"{usu.name}; {usu.email}; {usu.address.street}";
                usuariosDatos.Add(agregar);
            }
        }
        
        string jsonString = JsonSerializer.Serialize(usuariosDatos, new JsonSerializerOptions { WriteIndented = true });
        string ruta = Path.Combine(Directory.GetCurrentDirectory(), "Usuarios.json");
        File.WriteAllText(ruta, jsonString);
        Console.WriteLine("'Usuarios.json' creado y cargado con exito.");
    }
}