using System.ComponentModel.DataAnnotations;

namespace ASPNetCoreVue.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}