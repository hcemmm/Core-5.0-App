
using Microsoft.AspNetCore.Http;

namespace Core_5._0_App.Models
{
    public class AddProfileImage
    {
        public int WriterID { get; set; }
        public string WriterNameSurname { get; set; }
        public string WriterAbout { get; set; }
        public IFormFile WriterImage { get; set; }
        public string WriterMail { get; set; }
        public string WriterPassword { get; set; }
        public bool WriterBool { get; set; }
    }
}
