using EApp.Application.Repositories.Abstract;
using EApp.Domain.Entities.Concrete;
using EApp.Infrastructure.Context;
using EApp.Infrastructure.Repositories.Interfaces.ConcreteRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EApp.Application.Repositories.Concrete
{
    public class AppUserRepository : BaseRepository<AppUser>, IAppUserRepository
    {
        public AppUserRepository(AppDbContext context) : base(context)
        {
        }
    }
}
