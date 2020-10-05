using System.ComponentModel.DataAnnotations;

namespace ST
{
    public class Blog
    {
        public int BlogId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Short Description")]
        public string ShortDescription { get; set; }
        [Required]
        [Display(Name = "Long Description")]
        public string LongDescription { get; set; }
        [Required]
        [Display(Name = "Image Url")]
        public string ImageUrl { get; set; }
        public string ImageThumbnailUrl { get; set; }
        [Required]
        [Display(Name = "Category Id")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public string Notes { get; set; }
    }
}