using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TweetsStructure.Common.Data.Base
{
    public class BaseModel
    {
        public virtual int Id { get; set; }

        [Required(ErrorMessage = "{0} : Required")]
        public virtual DateTime CreatedOn { get; set; }

        public virtual DateTime UpdatedOn { get; set; }

        public virtual int Deleted { get; set; }
    }
}
