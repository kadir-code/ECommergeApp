using EApp.Domain.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EApp.Domain.Entities.Concrete
{
    public class AppRole:BaseEntity
    {
        public string Description { get; set; }
        public ICollection<AppUser>? AppUsers { get; set; }
    }
}
