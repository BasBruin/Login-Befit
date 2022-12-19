using InterfaceLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusnLogic
{
    public class UserContainer
    {
        private readonly IUserContainer container;

        public UserContainer(IUserContainer container)
        {
            this.container = container;
        }

        public int? FindByUsernameAndPassword(string gebruikersnaam, string wachtwoord)
        {
            int? id = container.FindByUsernameAndPassword(gebruikersnaam, wachtwoord);
            if (id == null)
            {
                return null;
            }
            return id;
        }

    }
}
