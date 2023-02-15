using System.Text.Json;

namespace ApiParticipantes.WebApi.Models
{
    public class ErrorDetails
    {
        public string Message { get; set; }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
