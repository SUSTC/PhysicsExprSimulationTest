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

        public static BizService.SvcResponse findExamScoreByStudentIDNew(string studentID)
        {

            BizService.BizServiceClient svcRef = new BizService.BizServiceClient();
            BizService.SvcRequest req = new BizService.SvcRequest();
            BizService.DoServiceRequest doSvcRequest;

            req = new BizService.SvcRequest()
            {
                BizCode = "USTCORi.ExamSystem.BLL.BLLExamCritique",
                EnableCache = false,
                MethodName = "FindExamScoreByStudentIDNew"
            };
            req.Parameters = new Dictionary<string, object>();
            req.Parameters.Add("studentID", "\"" + studentID + "\"");
            BizService.SvcResponse res;
            doSvcRequest = new BizService.DoServiceRequest(req);

            res = svcRef.DoService(doSvcRequest).DoServiceResult;



            return res;

        }

        public static BizService.SvcResponse findPaperContent(string examID, string studentID)
        {

            BizService.BizServiceClient svcRef = new BizService.BizServiceClient();
            BizService.SvcRequest req = new BizService.SvcRequest();
            BizService.DoServiceRequest doSvcRequest;

            req = new BizService.SvcRequest()
            {
                BizCode = "USTCORi.ExamSystem.BLL.BLLExamCritique",
                EnableCache = false,
                MethodName = "FindPaperContent"
            };
            req.Parameters = new Dictionary<string, object>();
            req.Parameters.Add("studentID", "\"" + studentID + "\"");
            req.Parameters.Add("examID", examID);
            BizService.SvcResponse res;
            doSvcRequest = new BizService.DoServiceRequest(req);

            res = svcRef.DoService(doSvcRequest).DoServiceResult;



            return res;

        }

        public static BizService.SvcResponse findSubmitStudentByExamID(string examID)
        {

            BizService.BizServiceClient svcRef = new BizService.BizServiceClient();
            BizService.SvcRequest req = new BizService.SvcRequest();
            BizService.DoServiceRequest doSvcRequest;

            req = new BizService.SvcRequest()
            {
                BizCode = "USTCORi.ExamSystem.BLL.BLLExamCritique",
                EnableCache = false,
                MethodName = "FindSubmitStudentByExamID"
            };
            req.Parameters = new Dictionary<string, object>();
            req.Parameters.Add("examID", examID);
            BizService.SvcResponse res;
            doSvcRequest = new BizService.DoServiceRequest(req);

            res = svcRef.DoService(doSvcRequest).DoServiceResult;



            return res;

        }

    }
}
