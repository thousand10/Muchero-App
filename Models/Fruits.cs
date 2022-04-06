using System;
using System.ComponentModel.DataAnnotations;


namespace mucheroapp.Models
{
    public class Fruit 
    {
        [Key]
        public int Id { get;set; }
        [Display(Name = "Fruit_Name")]
        [MaxLength(100)]
        public string? Name { get;set; }
        [Required]
        [Display(Name = "Fruit_Other_Names")]
        [MaxLength(300)]
        public string? OtherNames { get;set; }
        [Required]
        public string? Region { get;set; }
        [Required]
        [Display(Name = "Benefits_of_Fruit")]
        public string? Benefits { get;set; }
        [Required]
        [Display(Name = "Little_about_fruit")]
        [MaxLength(200)]
        public string? Intro { get;set; }
        [Required]
        public string? MoreAboutFruit { get;set; } 
    }
}