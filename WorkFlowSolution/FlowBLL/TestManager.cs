using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlowDALFactory;
using System.Data;

namespace FlowBLL
{
   public class TestManager
    {
       private static FlowIDAL.ITestService TestService = Factory.CreateInterfaceService<FlowIDAL.ITestService>("TestService");
       public static  DataTable GetTestData()
       {
         return  TestService.GetTestData();
       }
    }
}
