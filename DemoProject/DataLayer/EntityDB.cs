using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoProject.DataLayer
{
    public class EntityDB
    {

        public DemoEntities DemoEntitiesDbContext = null;
        public EntityDB()
        {
            DemoEntitiesDbContext = new DemoEntities();
        }

        public DemoEntities GetDBContext()
        {
            return DemoEntitiesDbContext;
        }

    }
}