using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entity
{
    public class Firm
    {
        [Key]
        [Required]
        public int FirmId { get; set; }
        [Required]
        public short FirmType { get; set; }
        [Required]
        public string FirmCode { get; set; }
        [Required]
        public string FirmName { get; set; }
        [Required]
        public bool FirmStatus { get; set; }
    }
}
