using System;
using System.ComponentModel.DataAnnotations;

namespace JmBlog.ViewModels
{
    public class PostCreateViewModel
    {
        [Required(AllowEmptyStrings = false)]
        public string Title { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Text { get; set; }
        public DateTime? DatePublished { get; set; }
        public string ImageBase64 { get; set; }
    }
}
