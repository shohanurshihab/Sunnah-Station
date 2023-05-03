using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUser<Type, ID, RET> : IRepo<Type, ID, RET>
    {
        RET GetByEmail(string ID);
    }
}
