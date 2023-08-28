﻿using System.ComponentModel.DataAnnotations;

namespace CodingWiki_Model.Models
{
    public class Publisher
    {
        [Key]
        public int Publisher_Id { get; set; }
        [Required]
        public string Name{ get; set; }
        public string Location { get; set; }

    }
}
