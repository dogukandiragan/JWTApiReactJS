 using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace JWTBasedAuthApiReactJS.CORE.DTOs
{

    public class TransactionDto
    {
 
        [Key]
        [JsonIgnore]
        public int Id { get; set; }
        public string UserId { get; set; }
 
        public string Service { get; set; }
        public double Price { get; set; }
    }
}
