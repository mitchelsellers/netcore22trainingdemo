using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace SampleWeb.Services.Samples.Models
{
    public class FormWithFileViewModel
    {
        [Required]
        [StringLength(25)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(25)]
        public string LastName { get; set; }
        public IFormFile ProfilePhoto { get; set; }
    }
}