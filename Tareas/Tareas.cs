using System.Text.Json;

namespace Tareas
{
    public class Tarea
    {
        //[JsonPropertyName("userId")]
        public int userId { get; set; }

        //[JsonPropertyName("id")]
        public int id { get; set; }

        //[JsonPropertyName("title")]
        public string title { get; set; }

        //[JsonPropertyName("completed")]
        public bool completed { get; set; }
    }

}
    
