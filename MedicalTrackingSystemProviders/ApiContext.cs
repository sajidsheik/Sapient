using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalTrackingSystemProviders
{
  public  class ApiContext:DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options)
           : base(options)
        {
        }

        public DbSet<Medicine> Medicines { get; set; }

        
    }
}
