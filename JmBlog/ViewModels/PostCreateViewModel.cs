using System;
using System.ComponentModel.DataAnnotations;

namespace JmBlog.ViewModels
{
    public class PostCreateViewModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Text { get; set; }
        public DateTime DatePublished { get; set; }
        public string UrlImage { get; set; }
    }
}
