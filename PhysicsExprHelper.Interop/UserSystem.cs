using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhysicsExprHelper.Interop
{
    public class UserSystem
    {
        public static BizService.SvcResponse logoutUser(string user)
        {

            BizService.BizServiceClient svcRef = new BizService.BizServiceClient();
            BizService.SvcRequest req = new BizService.SvcRequest();
            BizService.DoServiceRequest doSvcRequest;

            req = new BizService.SvcRequest()
            {
                BizCode = "USTCORi.ExamSystem.BLL.BLLSystemUser",
                EnableCache = false,
                MethodName = "LoginOut"
            };

            req.Parameters = new Dictionary<string, object>();
            req.Parameters.Add("keyString", user);

            BizService.SvcResponse res;
            doSvcRequest = new BizService.DoServiceRequest(req);
            res = svcRef.DoService(doSvcRequest).DoServiceResult;



            return res;
        }

        public static BizService.SvcResponse isUserOnline(string user, bool loginuse)
        {

            BizService.BizServiceClient svcRef = new BizService.BizServiceClient();
            BizService.SvcRequest req = new BizService.SvcRequest();
            BizService.DoServiceRequest doSvcRequest;

            req = new BizService.SvcRequest()
            {
                BizCode = "USTCORi.ExamSystem.BLL.BLLSystemUser",
                EnableCache = false,
                MethodName = "IsOnline"
            };

            req.Parameters = new Dictionary<string, object>();
            req.Parameters.Add("UserID", "\"" + user + "\"");
            req.Parameters.Add("isLoginUse", loginuse.ToString().ToLower());

            BizService.SvcResponse res;
            doSvcRequest = new BizService.DoServiceRequest(req);
            res = svcRef.DoService(doSvcRequest).DoServiceResult;



            return res;
        }

        public static BizService.SvcResponse interfaceLogin(string user, string password)
        {
            BizService.BizServiceClient svcRef = new BizService.BizServiceClient();
            BizService.SvcRequest req = new BizService.SvcRequest();
            BizService.DoServiceRequest doSvcRequest;

            req = new BizService.SvcRequest()
            {
                BizCode = "USTCORi.ExamSystem.BLL.BLLSystemUser",
                EnableCache = false,
                MethodName = "InterfaceLogin"
            };
            req.Parameters = new Dictionary<string, object>();
            req.Parameters.Add("userID", "\"" + user + "\"");
            req.Parameters.Add("password", "\"" + password + "\"");

            BizService.SvcResponse res;
            doSvcRequest = new BizService.DoServiceRequest(req);
            res = svcRef.DoService(doSvcRequest).DoServiceResult;



            return res;
        }

        public static BizService.SvcResponse findStudentNoticeByPage(string user)
        {

            BizService.BizServiceClient svcRef = new BizService.BizServiceClient();
            BizService.SvcRequest req = new BizService.SvcRequest();
            BizService.DoServiceRequest doSvcRequest;

            req = new BizService.SvcRequest()
            {
                BizCode = "USTCORi.ExamSystem.BLL.BLLNotice",
                EnableCache = false,
                MethodName = "FindStudentNoticeByPage"
            };
            req.Parameters = new Dictionary<string, object>();
            req.Parameters.Add("StudentID", "\"" + user + "\"");
            req.Parameters.Add("PageIndex", 1);
            req.Parameters.Add("PageSize", 100);
            BizService.SvcResponse res;
            doSvcRequest = new BizService.DoServiceRequest(req);
            res = svcRef.DoService(doSvcRequest).DoServiceResult;



            return res;

        }



    }
}
