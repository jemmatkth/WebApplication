using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Areas.Identity.Data;

namespace WebApplication.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Created { get; set; }
        public Boolean Status { get; set; }

        public string CreatedById { get; set; }
        [Display(Name ="Send by")]
        public string CreatedByUsername { get; set; }

        public string SentToId { get; set; }
        public string SentToUsername { get; set; }
    }
}
