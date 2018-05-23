using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsStore.Domain.Entities;

namespace SportsStore.Domain.Concrete
{
    public class EFUserRepository : Abstract.IUserRepository
    {
        public bool CheckAuth(Users users)
        {
            throw new NotImplementedException();
        }

        public void FindUser(Users users)
        {
            throw new NotImplementedException();
        }
    }
}
