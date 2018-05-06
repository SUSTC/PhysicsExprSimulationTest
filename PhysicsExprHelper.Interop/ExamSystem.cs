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

        public static BizService.SvcResponse FindExamScoreByStudentIDNew(string studentID)
        {
            return (new Service("USTCORi.ExamSystem.BLL.BLLExamCritique", "FindExamScoreByStudentIDNew"))
            .Set("studentID", "\"" + studentID + "\"")
            .DoRequest();
        }

        public static BizService.SvcResponse FindPaperContent(string examID, string studentID)
        {
            return (new Service("USTCORi.ExamSystem.BLL.BLLExamCritique", "FindPaperContent"))
            .Set("examID", examID)
            .Set("studentID", "\"" + studentID + "\"")
            .DoRequest();
        }

        public static BizService.SvcResponse FindSubmitStudentByExamID(string examID)
        {
            return (new Service("USTCORi.ExamSystem.BLL.BLLExamCritique", "FindSubmitStudentByExamID"))
            .Set("examID", examID)
            .DoRequest();
        }


        public static BizService.SvcResponse FindStudentInfoByExamIDAndStudentID(string examID, string studentID)
        {
            return (new Service("USTCORi.ExamSystem.BLL.BLLExamArrage", "FindStudentInfoByExamIDAndStudentID"))
            .Set("examID", examID)
            .Set("studentID", "\"" + studentID + "\"")
            .DoRequest();
        }
    }
}
