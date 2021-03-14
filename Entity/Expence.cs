using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entity
{
    public class Expence
    {
        [Key]
        [Required]
        public int ExpenceId { get; set; }
        [Required]
        public string ExpenceCode { get; set; }
        [Required]
        public string ExpenceName { get; set; }
        [Required]
        public bool ExpenceStatus { get; set; }
    }
}
