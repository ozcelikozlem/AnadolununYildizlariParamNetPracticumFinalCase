using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.UnitTests.TestSetup
{
    public static class Measures
    {
        public static void AddMeasures(this OnlineStoreDbContext context)
        {
            context.Measures.AddRange(
                    new Measure
                    {
                        Title="kg"
                    },
                    new Measure
                    {
                        Title="gr"
                    },
                    new Measure
                    {
                        Title="lt"
                    },
                   new Measure
                    {
                        Title="piece"
                    }
                    );
        }
    }
}