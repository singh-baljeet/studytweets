using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TweetsStructure.Web.Models.Mappings
{
    public class BackEndMap: ClassMap<BackEndModel>
    {
        public BackEndMap()
        {
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.CreatedOn).Not.Nullable();
            Map(x => x.UpdatedOn);
            Map(x => x.Deleted);

            Map(x => x.BackEndName).CustomSqlType("Varchar(50)");

            Table("backend");
        }

    }
}