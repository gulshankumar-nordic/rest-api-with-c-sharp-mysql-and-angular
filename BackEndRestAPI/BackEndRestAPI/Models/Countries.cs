using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndRestAPI.Models
{
    public class Countries
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        public string name { get; set; }
        
        [Required]
        public string capitalCity { get; set; }
        
        [Required]
        public int population { get; set; }
        
        [Required]
        public DateTime addedOn { get; set; }

    }
}
