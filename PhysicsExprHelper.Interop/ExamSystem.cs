using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;


namespace PhysicsExprHelper.Interop
{
    

    public class ExamSystem
    {
        public static BizService.SvcResponse findPaperContentByPaperID(string paperID)
        {

            BizService.BizServiceClient svcRef = new BizService.BizServiceClient();
            BizService.SvcRequest req = new BizService.SvcRequest();
            BizService.DoServiceRequest doSvcRequest;

            req = new BizService.SvcRequest()
            {
                BizCode = "USTCORi.ExamSystem.BLL.BLLExamArrage",
                EnableCache = false,
                MethodName = "FindPaperContentByPaperID"
            };
            req.Parameters = new Dictionary<string, object>();
            req.Parameters.Add("paperID", paperID);
            BizService.SvcResponse res;
            doSvcRequest = new BizService.DoServiceRequest(req);

            res = svcRef.DoService(doSvcRequest).DoServiceResult;



            return res;

        }
    }
}
