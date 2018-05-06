using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PhysicsExprHelper.Interop
{
    class Service
    {
        BizService.SvcRequest req;

        public Service(String bizCode, String methodName)
        {
            req = new BizService.SvcRequest()
            {
                BizCode = bizCode,
                EnableCache = false,
                MethodName = methodName
            };

            req.Parameters = new Dictionary<string, object>();
        }

        public Service Set(String key, Object value)
        {
            req.Parameters.Add(key, value);
            return this;
        }

        public BizService.SvcResponse DoRequest()
        {
            try
            {
                return (new BizService.BizServiceClient())
                .DoService(new BizService.DoServiceRequest(req))
                .DoServiceResult;
            } catch(System.ServiceModel.FaultException e)
            {
                MessageBox.Show("服务器开小差了\n" + e.ToString(), "啊，出错了");
                return null;
            }
        }

    }
}
