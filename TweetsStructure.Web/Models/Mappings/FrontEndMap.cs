using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TweetsStructure.Web.Models.Mappings
{
    public class FrontEndMap: ClassMap<FrontEndModel>
    {
        public FrontEndMap()
        {
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.CreatedOn).Not.Nullable();
            Map(x => x.UpdatedOn);
            Map(x => x.Deleted);

            Map(x => x.FrontEndName).CustomSqlType("Varchar(50)");

            Table("frontend");
        }

    }
}