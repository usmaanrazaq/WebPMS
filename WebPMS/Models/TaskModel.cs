using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebPMS;
using WebPMS.Models;


namespace WebPMS.Models
{
    [Serializable()]
    public class Tasks : List<Task>
    { }


    public class Task
    {
        public Task() { }
        public Task(int ID, string Status, string Type, string UserID, string LinkedReference, string Task, string Priority, DateTime? StartDate, DateTime? DueDate, DateTime? CompletedDate, string OverDue, string AutoReminder, DateTime? ReminderDate, DateTime? LastUpdatedTime, string LastUpdatedUser, string LinkedDescription)
        {
            this.ID = ID;
            this.Status = Status;
            this.Type = Type;
            this.UserID = UserID;
            this.LinkedReference = LinkedReference;
            this.task = Task;
            this.Priority = Priority;
            this.StartDate = StartDate;
            this.DueDate = DueDate;
            this.CompletedDate = CompletedDate;
            this.OverDue = OverDue;
            this.AutoReminder = AutoReminder;
            this.ReminderDate = ReminderDate;
            this.LastUpdatedTime = LastUpdatedTime;
            this.LastUpdatedUser = LastUpdatedUser;
            this.LinkedDescription = LinkedDescription;

        }
        public int ID { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public string UserID { get; set; }
        public string LinkedReference { get; set; }
        public string task { get; set; }
        public string Priority { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public string OverDue { get; set; }
        public string AutoReminder { get; set; }
        public DateTime? ReminderDate { get; set; }
        public DateTime? LastUpdatedTime { get; set; }
        public string LastUpdatedUser { get; set; }
        public string LinkedDescription { get; set; }

    }

    public static class BuildTask
    {
        public static Tasks ViewTasksByUser(string UserID, int NoOfDays, bool BeforeDays)
        {
            DataTable DT = DB.ReadData(Constants.StoredProcedures.Read.uspRetrieveTasksByUser, DB.StoredProcedures.uspRetrieveTasksByUser(UserID, NoOfDays, BeforeDays));
            Tasks prop = new Tasks();
            if (DT.Rows.Count > 0)
            {
                foreach (DataRow R in DT.Rows)
                {
                    prop.Add(BuildTaskFromDataRow(R));
                }
            }
            return prop;
        }
        public static Task ViewTask(int ID)
        {
            DataTable DT = DB.ReadData(Constants.StoredProcedures.Read.uspRetrieveTask, DB.StoredProcedures.uspRetrieveTask(ID));
            
            if (DT.Rows.Count > 0)
            {
               
                  return BuildTaskFromDataRow(DT.Rows[0]);
                
            }
            return new Task();
        }


        private static Task BuildTaskFromDataRow(DataRow dr)
        {
            return new Task(Functions.ToInt32(dr["ID"]), Functions.ToString(dr["Status"]), Functions.ToString(dr["Type"]), Functions.ToString(dr["UserID"]), Functions.ToString(dr["LinkedReference"]), Functions.ToString(dr["Task"]), Functions.ToString(dr["Priority"]), Functions.ToDate(dr["StartDate"]), Functions.ToDate(dr["DueDate"]), Functions.ToDate(dr["CompletedDate"]), Functions.ToString(dr["OverDue"]), Functions.ToString(dr["AutoReminder"]), Functions.ToDate(dr["ReminderDate"]), Functions.ToDate(dr["LastUpdatedTime"]), Functions.ToString(dr["LastUpdatedUser"]), Functions.ToString(dr["LinkedDescription"]));
        }
    }
}