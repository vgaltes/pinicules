using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Pinicules.Data.Infrastructure;
using Pinicules.Data.Migrations;

namespace Pinicules
{
    public class EntityFrameworkConfig
    {
        public static void SetInitializer()
        {
            Database.SetInitializer<MoviesContext>(
                new MigrateDatabaseToLatestVersion<MoviesContext, Configuration>());
        }
    }
}