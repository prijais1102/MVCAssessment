using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MVCAssessment.Models
{
    public class Student
    {
        [Required]
        [Remote("UniqueIDValue", "Batch", HttpMethod = "Post", ErrorMessage = "Student Id already exists.")]
        public int Id { get; set; }
        [Required]
        [RegularExpression("[a-zA-Z ]+", ErrorMessage = "Only alphabets allowed")]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DateOfBirthValidator]
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        [Required]
        [BatchValidator]
        public string Batch { get; set; }
    }
}
