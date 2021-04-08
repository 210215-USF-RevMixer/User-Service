using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserModels
{
    public class Report
    {
        //Data Fields
        private int userId;
        private int targetId;
        private bool isSample;
        private DateTime reportDate;
        private string description;

        //Properties 
        public int Id { get; set; } //Id to identify reports

        //UserId Property
        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }
        //TargetId Property 
        public int TargetId
        {
            get { return targetId; }
            set { targetId = value; }
        }
        //IsSample Property
        public bool IsSample
        {
            get { return isSample; }
            set { isSample = value; }
        }
        //ReportDate Property 
        public DateTime ReportDate
        {
            get { return reportDate; }
            set { reportDate = DateTime.Now; }
        }
        //Description Property
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        //User Property 
        public User User { get; set; }
    }
}
