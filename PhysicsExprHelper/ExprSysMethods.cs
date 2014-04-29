using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;


namespace PhysicsExprHelper.ExprSystems
{
    public class UserSystem
    {
        public static PhysicsExprHelper.BizService.SvcResponse logoutUser(string user)
        {
            
            PhysicsExprHelper.BizService.BizServiceClient svcRef = new PhysicsExprHelper.BizService.BizServiceClient();
            PhysicsExprHelper.BizService.SvcRequest req = new PhysicsExprHelper.BizService.SvcRequest();
            PhysicsExprHelper.BizService.DoServiceRequest doSvcRequest;

            req = new PhysicsExprHelper.BizService.SvcRequest()
            {
                BizCode = "USTCORi.ExamSystem.BLL.BLLSystemUser",
                EnableCache = false,
                MethodName = "LoginOut"
            };

            req.Parameters = new Dictionary<string, object>();
            req.Parameters.Add("keyString", user);

            PhysicsExprHelper.BizService.SvcResponse res;
            doSvcRequest = new BizService.DoServiceRequest(req);
            res = svcRef.DoService(doSvcRequest).DoServiceResult;



            return res;
        }

        public static PhysicsExprHelper.BizService.SvcResponse isUserOnline(string user,bool loginuse)
        {

            PhysicsExprHelper.BizService.BizServiceClient svcRef = new PhysicsExprHelper.BizService.BizServiceClient();
            PhysicsExprHelper.BizService.SvcRequest req = new PhysicsExprHelper.BizService.SvcRequest();
            PhysicsExprHelper.BizService.DoServiceRequest doSvcRequest;

            req = new PhysicsExprHelper.BizService.SvcRequest()
            {
                BizCode = "USTCORi.ExamSystem.BLL.BLLSystemUser",
                EnableCache = false,
                MethodName = "IsOnline"
            };

            req.Parameters = new Dictionary<string, object>();
            req.Parameters.Add("UserID", "\"" + user + "\"");
            req.Parameters.Add("isLoginUse", loginuse.ToString().ToLower());

            PhysicsExprHelper.BizService.SvcResponse res;
            doSvcRequest = new BizService.DoServiceRequest(req);
            res = svcRef.DoService(doSvcRequest).DoServiceResult;



            return res;
        }

        public static BizService.SvcResponse interfaceLogin(string user, string password)
        {
            PhysicsExprHelper.BizService.BizServiceClient svcRef = new PhysicsExprHelper.BizService.BizServiceClient();
            PhysicsExprHelper.BizService.SvcRequest req = new PhysicsExprHelper.BizService.SvcRequest();
            PhysicsExprHelper.BizService.DoServiceRequest doSvcRequest;

            req = new PhysicsExprHelper.BizService.SvcRequest()
            {
                BizCode = "USTCORi.ExamSystem.BLL.BLLSystemUser",
                EnableCache = false,
                MethodName = "InterfaceLogin"
            };
            req.Parameters = new Dictionary<string, object>();
            req.Parameters.Add("userID", "\""+user+"\"");
            req.Parameters.Add("password", "\"" + password+"\"");
            
            PhysicsExprHelper.BizService.SvcResponse res;
            doSvcRequest = new BizService.DoServiceRequest(req);
            res = svcRef.DoService(doSvcRequest).DoServiceResult;



            return res;
        }

        public static BizService.SvcResponse findStudentNoticeByPage(string user)
        {

            PhysicsExprHelper.BizService.BizServiceClient svcRef = new PhysicsExprHelper.BizService.BizServiceClient();
            PhysicsExprHelper.BizService.SvcRequest req = new PhysicsExprHelper.BizService.SvcRequest();
            PhysicsExprHelper.BizService.DoServiceRequest doSvcRequest;

            req = new PhysicsExprHelper.BizService.SvcRequest()
            {
                BizCode = "USTCORi.ExamSystem.BLL.BLLNotice",
                EnableCache = false,
                MethodName = "FindStudentNoticeByPage"
            };
            req.Parameters = new Dictionary<string, object>();
            req.Parameters.Add("StudentID", "\"" + user + "\"");
            req.Parameters.Add("PageIndex", 1);
            req.Parameters.Add("PageSize", 100);
            PhysicsExprHelper.BizService.SvcResponse res;
            doSvcRequest = new BizService.DoServiceRequest(req);
            res = svcRef.DoService(doSvcRequest).DoServiceResult;



            return res;

        }

        

    }

    public class ExamSystem
    {
        public static BizService.SvcResponse findPaperContentByPaperID(string paperID)
        {

            PhysicsExprHelper.BizService.BizServiceClient svcRef = new PhysicsExprHelper.BizService.BizServiceClient();
            PhysicsExprHelper.BizService.SvcRequest req = new PhysicsExprHelper.BizService.SvcRequest();
            PhysicsExprHelper.BizService.DoServiceRequest doSvcRequest;

            req = new PhysicsExprHelper.BizService.SvcRequest()
            {
                BizCode = "USTCORi.ExamSystem.BLL.BLLExamArrage",
                EnableCache = false,
                MethodName = "FindPaperContentByPaperID"
            };
            req.Parameters = new Dictionary<string, object>();
            req.Parameters.Add("paperID", paperID);
            PhysicsExprHelper.BizService.SvcResponse res;
            doSvcRequest = new BizService.DoServiceRequest(req);

            res = svcRef.DoService(doSvcRequest).DoServiceResult;



            return res;

        }
    }
}
