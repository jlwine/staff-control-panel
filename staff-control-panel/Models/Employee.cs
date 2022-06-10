using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using staff_control_panel.CustomValidation;

namespace staff_control_panel.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50, MinimumLength = 10, ErrorMessage = "Длина строки должна быть от 10 до 50 символов")]
        [Required(ErrorMessage = "Это поле должно быть заполнено")]
        public string full_name { get; set; }
        
        [Required(ErrorMessage = "Вы не указали дату рождения")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DateValidation]
        public DateTime birthday { get; set; }
        [Required(ErrorMessage = "Это поле должно быть заполнено")]
        public string gender { get; set; }
        [Required(ErrorMessage = "Выберите должность")]
        public int PostId { get; set; }
        
        [Required(ErrorMessage = "Это поле должно быть заполнено")]
        public string subunit { get; set; }
        [Required(ErrorMessage = "Это поле должно быть заполнено")]
        public string uniq_info { get; set; }

        public Post? Post { get; set; }
    }

    public class Post
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }

    
}
