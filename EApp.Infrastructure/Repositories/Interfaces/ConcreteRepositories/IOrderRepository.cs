using EApp.Domain.Entities.Concrete;
using EApp.Infrastructure.Repositories.Interfaces.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EApp.Infrastructure.Repositories.Interfaces.ConcreteRepositories
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
    }
}
