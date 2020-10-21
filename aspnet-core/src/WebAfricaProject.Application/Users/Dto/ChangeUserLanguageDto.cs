using System.ComponentModel.DataAnnotations;

namespace WebAfricaProject.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}