using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLib.Interfaces
{
    public interface IUserContainer
    {
        public int? FindByUsernameAndPassword(string username, string password);
    }
}
