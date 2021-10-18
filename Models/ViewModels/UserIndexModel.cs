using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Areas.Identity.Data;

namespace WebApplication.Models.ViewModels
{
    public class UserIndexModel
    {
        public WebApplicationUser user { get; }
        public virtual DateTime? LastLoginTime { get; set; }
        public virtual int? NumberOfLogins { get; set; }
    }
}
