using System;
using System.ComponentModel.DataAnnotations;

namespace JmBlog.Model
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Text { get; set; }
        public DateTime? DatePublished { get; set; }
        public DateTime DateUpdated { get; set; }
        public string ImageBase64 { get; set; }
        public string Permalink { get; set; }

        public Post()
        {
            
        }
    }

}