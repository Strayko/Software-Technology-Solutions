using System.ComponentModel.DataAnnotations;

namespace ST
{
    public class FormModel
    {
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}