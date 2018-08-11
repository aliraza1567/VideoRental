using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Dtos
{
    public class RentalsDto
    {
        [Required]
        public int CustomerId { get; set; }
        public List<int> MovieIds { get; set; }
    }
}
