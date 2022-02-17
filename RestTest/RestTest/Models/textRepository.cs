using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;


namespace RestTest.Models
{
    public class textRepository
    {
        public static void Initialize(IServiceProvider serviceProvider) 
        {
            using (var context = new textDBContext(
                serviceProvider.GetRequiredService<DbContextOptions<textDBContext>>()))
            {
                if(context.Texts.Any())
                {
                    return;
                }

                context.Texts.AddRange(
                    new Text
                    {
                        TextValue = "Developer"                        
                    },
                    new Text
                    {
                        TextValue = "Application"
                    },
                    new Text
                    {
                        TextValue = "Web Service"
                    },
                    new Text
                    {
                        TextValue = "Angular"
                    },
                    new Text
                    {
                        TextValue = "Database"
                    }
                    ) ;
                context.SaveChanges();
            }
        
        }
    }
}
