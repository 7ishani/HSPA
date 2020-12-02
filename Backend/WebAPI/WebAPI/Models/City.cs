using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class City
    {
        public int Id { get; set; }

        public string name { get; set; }

        [Required]
        public string Country { get; set; }

        public DateTime LastUpdateOn { get; set; }

       public int LastUpdateBy { get; set; }


    }
}
