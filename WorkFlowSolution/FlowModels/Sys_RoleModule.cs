using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlowModels
{
    public class Sys_RoleModule
    {

        private List<Sys_Role> list_Roles;
        public  List<Sys_Role> List_Roles
        {
            get
            {
                if (list_Roles == null)
                {
                    list_Roles = new List<Sys_Role>();
                }
                return list_Roles;
            }
            set
            {
                list_Roles = value;
            }
        }

        private List<Sys_Module> list_Modules;
        public  List<Sys_Module> List_Modules
        {
            get
            {
                if (list_Modules == null)
                {
                    list_Modules = new List<Sys_Module>();
                }
                return list_Modules;
            }
            set
            {
                list_Modules = value;
            }
        }

    }
}
