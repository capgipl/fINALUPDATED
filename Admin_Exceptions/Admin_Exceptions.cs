using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin_Exceptions
{
    public class Roles_Exception : ApplicationException
    {
        public Roles_Exception()
            : base()
        { }
        public Roles_Exception(string errormsg)
            : base(errormsg)
        { }
        public Roles_Exception(string errormsg, System.Exception innerexception)
            : base(errormsg, innerexception)

        { }
    }

    public class UserRoles_Exception : ApplicationException
    {
        public UserRoles_Exception()
            : base()
        { }
        public UserRoles_Exception(string errormsg)
            : base(errormsg)
        { }
        public UserRoles_Exception(string errormsg, System.Exception innerexception)
            : base(errormsg, innerexception)

        { }
    }

    public class Users_Exception : ApplicationException
    {
        public Users_Exception()
            : base()
        { }
        public Users_Exception(string errormsg)
            : base(errormsg)
        { }
        public Users_Exception(string errormsg, System.Exception innerexception)
            : base(errormsg, innerexception)

        { }

    }
}
