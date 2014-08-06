using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pinicules.Data.Repositories;

namespace Pinicules.Data.Tests.Initializers
{
    public class MoviesInitializer : DropCreateDatabaseAlways<MoviesRepository>
    {
        protected override void Seed(MoviesRepository context)
        {
            base.Seed(context);
        }
    }
}