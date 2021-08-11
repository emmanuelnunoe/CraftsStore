using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CraftsStore.Web.Models
{
    public class Product
    {
        public string Id { get; set; }

        [MaxLength(200)]
        [Required]
        public string Maker { get; set; }
        [JsonPropertyName("img")]
        public string Image { get; set; }

      
        public string Url { get; set; }
        [MaxLength(200)]
        [Required]
        public string Title { get; set; }

        [MaxLength(100)]
        [Required]
        public string Description { get; set; }
        //public int[] Rating { get; set; }


        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }

    }
}