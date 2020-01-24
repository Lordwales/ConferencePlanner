using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ConferenceDTO
{
    public class Tag
    {
        public int Id { get; set; }

        [StringLength(32)]
        [Required]
        public string Name { get; set; }
    }
}
