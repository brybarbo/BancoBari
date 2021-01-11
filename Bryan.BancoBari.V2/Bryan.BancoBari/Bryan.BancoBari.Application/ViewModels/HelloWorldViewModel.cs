using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bryan.BancoBari.Application.Models
{
    public class HelloWorldViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The Name is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Name")]
        public string Description { get; set; }
    }
}
