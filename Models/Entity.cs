using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TeclaT.Models
{
    public class Entity
    {
        [Key]
        public long Id { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string Name { get; set; }
    }
}
