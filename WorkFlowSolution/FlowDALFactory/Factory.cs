using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Reflection;
using FlowIDAL;

namespace FlowDALFactory
{
    public abstract class Factory
    {
        //用到反射技术:不用new关键字来新建对象
        private static string type = "Flow" + ConfigurationManager.AppSettings["DBType"];

        //反射得到接口服务
        public static T CreateInterfaceService<T>(string ClassName)
        {
            return (T)Assembly.Load(type + "DAL").CreateInstance(type + "DAL." + ClassName);
        }
    }
}
