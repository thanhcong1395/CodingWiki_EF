using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodingWiki_Model.Models
{
    [Table("Categories")]
    public class Category
    {
        public int Id { get; set; }
        [Column("Name")]
        [Required]
        public string GenreName { get; set; }
        //public int DisplayOrder { get; set; }
    }
}
