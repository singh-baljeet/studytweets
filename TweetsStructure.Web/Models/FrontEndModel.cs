using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TweetsStructure.Common.Data.Base;

namespace TweetsStructure.Web.Models
{
    public class FrontEndModel : BaseModel
    {
        [StringLength(50, ErrorMessage ="{0}: Max Character =50")]
        public virtual string FrontEndName { get; set; }

    }
}