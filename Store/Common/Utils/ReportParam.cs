using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace eLearning.Common.Utils
{
    public class ReportParam
    {
        public string ReportFileName { get; set; }
        public Hashtable Parameters = new Hashtable();
        public DataSet  ReportData { get; set; }
    }

    public static class ReportName
    {
        public const string LearningFile = "LearningFile";
        public const string InstructorSchedule = "InstructorSchedule";
        public const string TrainingCertificate = "TrainingAttendanceCertificate";
        public const string CustomerExamBookingReport = "CustomerExamBooking";

        // Added by MUHAMMADUZAIR\Administrator as Onsite Support on 07/12/2017 13:21:45 
        //public const string ViewContractReport = "TrainingContract";
        public const string ViewContractReport = "TrainingContractNew";

        public const string PaymentReceipt = "PaymentReceipt";
        public const string LicenseIssueReport = "LicenseIssueReport";
        public const string HolidaysReport = "HolidaysReport";
        //Added by Fahim Nasir
        public const string ClassesScheduleReport = "ClassesScheduleReport";
        //Added by Fahim Nasir n 20-9-2017
        public const string LectureScheduleReport = "LectureScheduleReport";
        // Added by AVANZA\muhammad.uzair on 11/10/2017 11:53:38
        public const string LicenseTrainingCertificate = "LicenseTrainingCertificate";
        // Added by AVANZA\muhammad.uzair on 31/10/2017 17:49:18
        public const string CompanyPaymentReceipt = "CompanyPaymentReceipt";

        // Added by MUHAMMADUZAIR\Administrator as Onsite Support on 26/11/2017 13:24:13 
        public const string PaymentReceiptNew = "PaymentReceiptNew";

        // Added by Muhammad Uzair on 28/02/2018 16:30:38 
        public const string PaymentReceiptLatest = "PaymentReceiptLatest";

        //Added by Fahim Nasir 16/12/2017 12:19:15
        public const string CustomerSummaryReport = "CustomerSummaryReport";
        public const string CustomerSummaryFinal = "CustomerSummaryFinal";


        public const string NewSupervisor = "NewSupervisor";
        // Added by MUHAMMADUZAIR\Administrator as Onsite Support on 01/12/2017 16:11:44 
        public const string CustomerLectureSchedules = "CustomerLectureSchedules";

        // Added by BSD-004\Administrator as Onsite Support on 28/12/2017 17:30:04 
        public const string CustomerSearchReport = "CustomerSearchReport";

        // Added by AVANZA\vijay.kumar on 01/02/2018 14:52:05
        public const string CustomerPayments = "CustomerPayments";

        // Added by AVANZA\vijay.kumar on 07/02/2018 12:28:26
        public const string CustomerPaymentCategory = "CustomerPaymentCategory";
        public const string OutStandingPayments = "OutStandingPayments";
        public const string CompanyOutStandingPayments = "CompanyOutStandingPayments";
        public const string PettyCash = "PettyCash";
        public const string DepartmentExpensesReport = "DepartmentExpensesReport";
        public const string DailyFloat = "DailyFloat";
        public const string CompanyDiscount = "CompanyDiscount";

        //Added by Fahim Nasir 12/03/2018 15:03:40
        public const string LectureStudentsReport = "LectureStudentsReport";

        // Added by Muhammad Uzair on 19/03/2018 19:49:14 as ONSITE_DEV
        public const string ClearanceLetter = "ClearanceLetter";
    }   
}
