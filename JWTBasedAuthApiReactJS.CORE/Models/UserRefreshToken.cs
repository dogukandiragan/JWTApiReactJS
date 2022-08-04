using System.ComponentModel.DataAnnotations;

namespace JWTBasedAuthApiReactJS.CORE.Models
{
    public class UserRefreshToken
    {
        [Key]
        public string UserId { get; set; }
        public string Code { get; set; }
        public DateTime Expiration { get; set; }
    }
}
