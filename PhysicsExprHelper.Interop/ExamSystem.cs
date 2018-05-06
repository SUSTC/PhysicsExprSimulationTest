using System;
using System.Collections.Generic;


namespace PhysicsExprHelper.Interop
{
    public class ExamSystem
    {
        public static BizService.SvcResponse GetExamStudentInfo(String studentID, String examID)
        {
            return (new Service("USTCORi.ExamSystem.BLL.BLLExamCritique", "GetExamStudentInfo"))
            .Set("examID", examID)
            .Set("studentID", "\"" + studentID + "\"")
            .DoRequest();
        }

        public static BizService.SvcResponse FindUndoExamByStudentID(String studentID)
        {
            return (new Service("USTCORi.ExamSystem.BLL.BLLExamArrage", "FindUndoExamByStudentID"))
            .Set("studentID", "\"" + studentID + "\"")
            .DoRequest();
        }

        public static BizService.SvcResponse UpdateStudentPaperContent( String studentInfo)
        {
            return (new Service("USTCORi.ExamSystem.BLL.BLLExamArrage", "UpdateStudentPaperContent"))
            .Set("studentInfo", studentInfo)
            .DoRequest();
        }

        public static BizService.SvcResponse findExamScoreByStudentIDNew(string studentID)
        {
            return (new Service("USTCORi.ExamSystem.BLL.BLLExamCritique", "FindExamScoreByStudentIDNew"))
            .Set("studentID", "\"" + studentID + "\"")
            .DoRequest();
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


        public static BizService.SvcResponse FindStudentInfoByExamIDAndStudentID(string examID, string user)
        {

            BizService.BizServiceClient svcRef = new BizService.BizServiceClient();
            BizService.SvcRequest req = new BizService.SvcRequest();
            BizService.DoServiceRequest doSvcRequest;

            req = new BizService.SvcRequest()
            {
                BizCode = "USTCORi.ExamSystem.BLL.BLLExamArrage",
                EnableCache = false,
                MethodName = "FindStudentInfoByExamIDAndStudentID"
            };
            req.Parameters = new Dictionary<string, object>();
            req.Parameters.Add("examID", examID);
            req.Parameters.Add("studentID", "\"" + user + "\"");
            BizService.SvcResponse res;
            doSvcRequest = new BizService.DoServiceRequest(req);
            res = svcRef.DoService(doSvcRequest).DoServiceResult;



            return res;

        }
    }
}
