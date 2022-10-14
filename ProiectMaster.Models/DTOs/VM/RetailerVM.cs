using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProiectMaster.Models.DTOs.VM
{
    public class RetailerVM
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        [MaxLength(2000)]
        public string Description { get; set; }

        public int ProductTypeId { get; set; }

        public string ProductTypeName { get; set; }

        public List<IdNameDto> ProductTypes { get; set; }
    }
}
