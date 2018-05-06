using System;

namespace PhysicsExprHelper.Interop
{
    public class UserSystem
    {
        public static BizService.SvcResponse LogoutUser(string user)
        {
            return (new Service("USTCORi.ExamSystem.BLL.BLLSystemUser", "LoginOut"))
            .Set("keyString", user)
            .DoRequest();
        }

        public static BizService.SvcResponse IsOnline(string user, bool loginuse = false)
        {
            return (new Service("USTCORi.ExamSystem.BLL.BLLSystemUser", "IsOnline"))
            .Set("UserID", "\"" + user + "\"")
            .Set("PassWord", "\"" + user + "\"")
            .Set("isLoginUse", loginuse.ToString().ToLower())
            .DoRequest();
        }

        public static BizService.SvcResponse InterfaceLogin(string user, string password)
        {
            return (new Service("USTCORi.ExamSystem.BLL.BLLSystemUser", "InterfaceLogin"))
            .Set("userID", "\"" + user + "\"")
            .Set("password", "\"" + password + "\"")
            .Set("version", "\"预习大厅v1.10.0822\"")
            .DoRequest();
        }

        public static BizService.SvcResponse FindStudentNoticeByPage(String user, uint pageIndex = 1, uint pageSize = 11)
        {
            return (new Service("USTCORi.ExamSystem.BLL.BLLNotice", "FindStudentNoticeByPage"))
            .Set("StudentID", "\"" + user + "\"")
            .Set("PageIndex", pageIndex)
            .Set("PageSize", pageSize)
            .DoRequest();
        }
    }
}
