using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlowModels
{
    [Serializable]
    public enum enAuditState
    {
        未送审 = 0,

        审批中 = 1,

        已完成 = 2,

        退回修改 = 3,

        修改完成 = 4,

        流程撤销= 5
    }
    
}
