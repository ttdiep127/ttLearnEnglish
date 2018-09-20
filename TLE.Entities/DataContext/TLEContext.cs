using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TLE.Entities.Models.EntityModels;

namespace TLE.Entities.DataContext
{
    public partial class TLEContext: DbContext
    {
        public virtual DbSet<User> Users { get; set; }
    }
}
