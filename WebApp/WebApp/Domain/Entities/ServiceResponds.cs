using System.ComponentModel.DataAnnotations;

namespace WebApp.Domain.Models
{
    public class ServiceResponds<T> // <T> Para poder receber dados genericos
    {
        public T? Data { get; set; }
        public string Message { get; set; } = string.Empty;
        public bool Success { get; set; }

    }
}
