using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CraftsStore.Web.Models
{
    public class Product
    {
        public string Id { get; set; }

        [StringLength(40,MinimumLength=3)]
        [Required]
        public string Maker { get; set; }
        [JsonPropertyName("img")]
        public string Image { get; set; }
        [MaxLength(100)]
        [Required]
        [Url]
        [Display(Name ="Site URL")]
        public string Url { get; set; }
        [MaxLength(100)]
        [Required]
        [StringLength(100,MinimumLength =3)]
        public string Title { get; set; }

        [MaxLength(100)]
        [Required]
        public string Description { get; set; }
        //public int[] Rating { get; set; }


        public override string ToString()=> JsonSerializer.Serialize(this);
        

    }
}