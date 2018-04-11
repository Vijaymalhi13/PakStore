using System;
using System.Collections.Generic;
using System.Text;

namespace eLearning.Common.Utils
{
    public class Enumaration
    {

        private const int REC_PER_PAGE = 10;
        public const string ERROR_MESSAGE = "ERROR_MESSAGE";
        public static int RecordsPerPage
        {
            get
            {
                return REC_PER_PAGE;

            }

        }
        private const int TOTAL_PAGES_TO_SHOW_IN_REPEATER = 11;
        public static int GridTotalPagesToShowInRepeater
        {
            get
            {
                return TOTAL_PAGES_TO_SHOW_IN_REPEATER;
            }
        }


        //Added by Fahim Nasir 04/12/2017 13:58:28
        public enum CompUploadEmpStatus
        {
            Active = 1,
            Discontinued = 2
        };

        //Modified by Fahim Nasir 20/03/2018 12:22:08
        //Modified by Fahim Nasir 22/01/2018 12:18:32 - Exemped Added.
        //Added by Fahim Nasir 04/01/2018 15:47:08
        public enum PaymentPlanRecStatus
        {
            UnPaid = 0,
            Paid = 1,
            Transferred = 2,
            Migrated = 3,
            Exempted = 4, 
            //Added by Fahim Nasir 20/03/2018 12:22:17
            FOC = 5 // For ByPassing payment in case of packages and company lumpsum. (self paid)
        };

        public enum TransferredExamStatus
        {
            Passed = 1
        };

        //Added by Fahim Nasir - 07-Nov-2017
        public enum RoomTypes
        {
            Normal = 1,
            Virtual = 2
        };

        //Added by Fahim Nasir 31/10/2017 13:52:23
        public enum TrainingRequestStatus
        {
            Pending = 0,
            Approved = 1,
            Rejected = 2
        };

        public enum ETTCSlotStatus
        {
            Pending = 1,
            Attended = 2,
            Absent = 3,
            Holiday = 4
        };
        //==========================

        //Added by Fahim Nasir 23/10/2017 10:03:03
        public enum QuestionFor
        {
            Supervisor = 1,
            Driver = 2
        };

        //Added by Fahim Nasir on 28-8-2017
        public enum PracticalClassType
        {
            Class = 1,
            Assessment = 2,
            Night = 3,
            Highway = 4,
            // Added by MUHAMMADUZAIR\avanza on 22/09/2017 09:19:41
            //additional classes type enum
            Additional = 5
        };

        public enum ExamIdMap
        {
            KnowledgeTest = 1,
            ParkingTest = 2,
            InternalAssessment = 3,
            RoadTest = 4
        };

        // ADDED BY MUHAMMAD AWAIS 8/3/2017
        public enum CustomerStatus
        {
            Pending = 1,
            Approved = 2
        };

        //Added by Fahim Nasir on 19-7-2017
        public enum ExamEventType
        {
            IssueExamAppointment = 1,
            RescheduleExamAppointment = 2,
            PayForExamAppointment = 3,
            AutoRescheduling = 4,
            AutoCancelation = 5,
            CancelAppointment = 6
        };
        //Added by Fahim Nasir on 10-7-2017
        public enum WeekDays
        {
            Sunday = 1,
            Monday = 2,
            Tuesday = 3,
            Wednesday = 4,
            Thursday = 5,
            Friday = 6,
            Saturday = 7
        };

        // AMJAD
        public enum LanguageType
        {
            ETDI = 1,
            RTA = 2,
            Both = 3
        }

        //Added by Fahim 
        public enum RoomScheduleStatus
        {
            Scheduled = 1,
            Cancelled = 2,
            Holiday = 99,
            //Added by Fahim Nasir 11/01/2018 11:00:56
            ReadyToPlay = 3, //Exceptional status, permission based from back office.
            Started = 4, //Once started will be visible always. Automted from backend.
            Completed = 5 //Automated from backend, on completion of training.
        };
        public enum QuestionType
        {
            NotSelected = -1,
            SingleSelection = 1,
            MatchImagewithImage = 2,
            MatchImagewithText = 3,
            Categorybased = 4,
            MapLocator = 5,


        };

        //Added by Fahim Nasir on 24-8-2017
        public enum CustomerClassStatus
        {
            Pending = 1, //Inserting by default from SP on insert.
            Attended = 2, //On marking attendance as present.
            Absent = 3, //On marking attendance as absent.
            Holiday = 99,
            //Added by Fahim Nasir on 19-9-2017 
            Cancelled = 4
        };
        //==================================

        public enum SlotScheduleStatus
        {
            Pending = 1,
            Attended = 2,
            Cancelled = 3,
            //Added by Fahim Nasir on 23-8-2017
            Absent = 4,
            //==========
            Holiday = 99
        }

        //Added by Fahim Nasir on 4-June-2017
        public enum LoginLanguages
        {
            English = 1,
            Arabic = 2
        }

        //Updated by Fahim Nasir on 04-12-2017
        public enum LicenseStatus
        {
            New = 1,
            Registered = 2,
            Issues = 3,
            Cancelled = 4,
            Hold = 5,
            Transferred = 6,
            //Added by Fahim Nasir 12/12/2017 15:57:53
            TransferredOut = 7
        };
        public enum EidaInfoKey
        {
            Occupation = 1
        };

        // Added by Fahim Nasir on 12/01/2017 13:54:36
        public enum DropDownDefaultValue
        {
            Select = -1
        };

        // Added by Fahim Nasir on 03/02/2017 14:33:12
        // Modified by AVANZA\muhammad.uzair on 01/11/2017 14:59:13
        public enum CustomerType
        {
            DefaultValue = 1,
            Individual = 2,
            Corporate = 3
        };

        // Added by Fahim Nasir on 27/01/2017 10:04:45
        public enum ReportName
        {
            LearningFile,
            CustomerExamBookingReport
        }

        // Added by Fahim Nasir on 03/02/2017 09:22:15
        public enum NofExperience
        {
            ZeroToTwo = 1,
            TwoToFive = 2,
            AboveFive = 3
        };
        //=============================================


        public enum Entities
        {
            CustomerManagement = 1
        };
        //============================================




        // Added by Fahim Nasir on 23/01/2017 13:58:23
        public enum OperationType
        {
            AddDocArchive = 1
        };

        // Added by Fahim Nasir on 12/01/2017 14:10:00
        public enum Country
        {
            UAE = 233, 
            //Added by Fahim Nasir.
            Pakistan = 168
        };

        // Added by Fahim Nasir on 23/01/2017 09:24:42
        public enum CheckingStatus
        {
            Pending = 1,
            Approved = 2,
            Rejected = 3
        };

        public enum Channels
        {
            WebApplication = 1,
            CustomerPortal = 2,
            ImportCustomer = 3,
            Mobile = 4,
        };

        public enum PageMode
        {
            Add,
            Edit,
            ApprovalRequired,
            Approve,
            SaveAfterApprove,
            Rejected,
            InActive,
            PopUp,

        };

        public enum LoginStatus
        {
            InvalidLoginId = 1,
            IncorrectPassword = 2,
            LDAPNotConnecting = 3,
            Success = 4,
            // Added by AVANZA\fahim.nasir on 04/01/2017 15:34:21
            ErrorsWhileSingleSignOn = 5,
            Inactive = 6,
            OtherErrors = 7
            //==========================
        };


        // Added by Fahim Nasir on 17/01/2017 15:24:15
        public enum ServiceWorkFlowStatus
        {
            #region Commented Code by Fahim Nasir
            /* Fahim Statuses 
            /// Commited by Tariq 
            //NewCustomer = 1, // it is named as Draft in DB. 
            //TheoryExamScheduled = 8,
            //// Added by Fahim Nasir on 08/02/2017 15:20:37
            //Pending = 28, 
            //Approved = 29,
            //Rejected = 1 //as on rejection it will roll back to Draft Status.
            Fahim statuses */
            //Draft = 1,
            //Pending = 2,
            //SendForApproval = 3,
            //Approved = 4,
            //Rejected = 5,
            //TheoryClassesScheduled = 6,
            //TheoryClassesStarted = 7,
            //TheoryClassesCompleted = 8,
            //TheoryAssessmentScheduled = 9,
            //ReScheduleTheoryClasses = 10,
            //ReadyforTheoryExamScheduling = 11,
            //TheoryExamScheduled = 12,
            //ReadyforIndoorPracticalScheduling = 13,
            //IndoorPracticalScheduled = 14,
            //IndoorPracticalStarted = 15,
            //IndoorPracticalCompleted = 16,
            //IndoorPracticalAssessmentScheduled = 17,
            //ReScheduleIndoorPractical = 18,
            //ParkingExamScheduled = 19,
            //ReadyforOutdoorPracticalScheduling = 20,
            //OutdoorPracticalScheduled = 21,
            //OutdoorPracticalStarted = 22,
            //OutdoorPracticalCompleted = 23,
            //OutdoorPracticalAssessmentScheduled = 24,
            //ReScheduleOutdoorPractical = 25,
            //RoadTestExamScheduled = 26,
            //LicenseIssuancePending = 27,
            //LicenseIssued = 28,
            #endregion
            NewCustomer = 1,
            Draft = 14,
            Pending = 15,
            SendForApproval = 16,
            Approved = 17,
            Rejected = 18,
            LectureScheduled = 3,
            PracticalScheduled = 7,
            KnowledgeTestScheduled = 5,
            ParkingTestScheduled = 10,
            RoadTestScheduled = 11
        };

        // Added by Fahim Nasir on 10/02/2017 12:10:39
        public enum ServiceRateCardCategory
        {
            Normal = 1,
            VIP = 2,
            Special = 3,
            // Added by MUHAMMADUZAIR\Administrator as Onsite Support on 14/12/2017 22:13:44 
            Friday = 4
        };

        //Updated by Fahim Nasir on 30-11-2017
        public enum ServiceWorkFlowStage
        {
            OpenFile = 1,
            KnowledgeTest = 2,
            InternalManoeverTest = 3,
            ETDIAssessmentTest = 4,
            RoadTest = 5,
            // Added by Muhammad Uzair on 08/03/2018 09:55:36 
            AllStages = 6
        };
        //=============================================

        public enum Application
        {
            AdminApp = 1,
            FrontApp = 2,
        };
        public enum Permissions
        {
            //ChangePassword = 1,
            ListCompanies = 2,

        };

        public enum rtaPostingServiceStatus
        {
            Error = -1,
            Pending = 0,
            InProgress = 1,
            Processed = 2
        };

        public static class Culture
        {
            public static string ARABIC = "ar-AE";
            public static string ENGLISH = "en-US";

        }

        public static class Keys
        {
            // Added by Fahim Nasir on 17/01/2017 10:26:07
            public const string PageDataList = "PageDataList";
            public const string CustomerId = "CustomerId";
            public const string CustomerServiceContractId = "CustomerServiceContractId";
            public const string PageResultMessage = "msg";
            public const string ReportParam = "ReportParam";
            public const string EidaInfoBit = "EidaInfoBit";
            public const string SubServiceId = "SubServiceId";
            public const string CustomerStatusId = "CustomerStatusId";
            public const string EidaObject = "EidaObject";
            //===============================================
            public const string FilesToDelete = "FilesToDelete";
            public static string CurrentCulture = "CurrentCulture";
            public static string LoggedInUser = "LoggedInUser";
            public static string Permissions = "Permissions";
            public static string MenuHTML = "MenuHTML";
            public static string MenuHeaderHTML = "menuHeader";
            public static string SubMenuHTML = "subMenu";
            public static string DashboardHTML = "DashboardHTML";
            public static string RowWithSingleResultColumnHTML = "RowWithSingleResultColumnHTML";
            public static string RowWithMultiResultColumnHTML = "RowWithMultiResultColumnHTML";
            public static string MultiResultColumnHeadingHTML = "MultiResultColumnHeadingHTML";
            public static string MultiResultColumnValueHTML = "MultiResultColumnValueHTML";
            public static string MenuEndJS = "MenuENDJS";
            public static string ID = "ID";
            public static string PageMode = "PageMode";
            public static string PageDataSet = "PageDataSet";
            public static string ExamTemplateValuesFromSelection = "ExamTemplateValuesFromSelection";
            public static string GridDataSource = "GridDataSource";
            public static string GridTotalPages = "GridTotalPages";
            public static string GridCurrentPage = "GridCurrentPage";
            public static string MEDIA_LOC_PLACE_HOLDER_TO_REPLACE_IN_XML = "&lt;MEDIA_LOC&gt;";
            public static string MEDIA_LOC_PLACE_HOLDER_TO_REPLACE = "<MEDIA_LOC>";
            public static string COURSE_MEDIA_LOC_PLACE_HOLDER_TO_REPLACE_IN_XML = "&lt;COURSE_MEDIA_LOC&gt;";
            public static string COURSE_MEDIA_LOC_PLACE_HOLDER_TO_REPLACE = "<COURSE_MEDIA_LOC>";
            public static string MultilingualCultureTextsDataTable = "MultilingualCultureTextsDataTable";
            public static string MultilingualCultureTextsKey = "MultilingualCultureTextsKey";
            public static string MultilingualCultureFileUpload = "MultilingualCultureFileUpload";
            public static string FromPage = "FromPage";
            public static string IdNotToFetch = "IdNotToFetch";
            public static string RELATIVE_PATHS = "&lt;RELATIVE_PATHS&gt;";
            public static string ExistingLicenseDataSet = "ExistingLicenseDataSet";
            public static string ExistingLicenseEditingId = "ExistingLicenseEditingId";

            public static string RoomSchTrainingSlot = "RoomSchTrainingSlot";
            public static string LBGridScheduleDataSet = "LBGridScheduleDataSet";
            public static string LBGridSchHistoryDataSet = "LBGridSchHistoryDataSet";

            public static string INS_AVAIL_DATA = "INS_AVAIL_DATA";

            //Added by Fahim Nasir 
            public static string COMPANY_DISCOUNT_ID = "COMPANY_DISCOUNT_ID";
            public static string CUSTOM_SLIDE_ID = "CUSTOM_SLIDE_ID";


            //Added by Fahim Nasir
            public static string CC_UPLOADED_FILE_NAME = "CC_UPLOADED_FILE_NAME";
            public static string CC_UPLOADED_FILE_PATH = "CC_UPLOADED_FILE_PATH";
            public static string CC_CUSTOM_UPLOADED_FILE_NAME = "CC_CUSTOM_UPLOADED_FILE_NAME";
            public static string CC_CUSTOM_UPLOADED_FILE_PATH = "CC_CUSTOM_UPLOADED_FILE_PATH";
            public static string CC_CUSTOM_PPT_REL_PATH = "CC_CUSTOM_PPT_REL_PATH";
            public static string PPT_SLIDE_THUMNAILS = "PPT_SLIDE_THUMNAILS";
            public static string FUP_ASNWER_IMAGE_FILE_NAME = "FUP_ASNWER_IMAGE_FILE_NAME";
            public static string FUP_MATCHING_IMAGE_FILE_NAME = "FUP_MATCHING_IMAGE_FILE_NAME";
            public static string FUP_ASNWER_IMAGE_PATH = "FUP_ASNWER_IMAGE_PATH";
            public static string FUP_MATCHING_IMAGE_PATH = "FUP_MATCHING_IMAGE_PATH";
            public static string FUP_MATCHING_IMAGE_VALID = "FUP_MATCHING_IMAGE_VALID";
            public static string FUP_ASNWER_IMAGE_VALID = "FUP_ASNWER_IMAGE_VALID";
            //=====================

            //Added by Fahim Nasir 23/11/2017 15:41:52
            public static string TRAINING_CONTRACT_NO = "TRAINING_CONTRACT_NO";

            //Added by Fahim Nasir 11/12/2017 10:04:23
            public static string TRAINING_TOTAL_AMOUNT = "TRAINING_TOTAL_AMOUNT";

            //Added by Fahim Nasir 09/01/2018 12:01:36
            public static string SHARED_FOLDER_PPT_FILE = "SHARED_FOLDER_PPT_FILE";

            public static string FUP_VALIDATION_CHECK = "FUP_VALIDATION_CHECK";

            //Added by Fahim Nasir 12/01/2018 11:56:58
            public static string WP_EXAM_USER_NAME = "WP_EXAM_USER_NAME";
            public static string WP_EMIRATE_ID_NUMBER = "WP_EMIRATE_ID_NUMBER";
            public static string WP_EXAM_TEMPLATE_ID = "WP_EXAM_TEMPLATE_ID";

            //Added by Fahim Nasir 15/01/2018 10:30:29
            public static string TR_INSTALLMENT_FILE_PATH = "TR_INSTALLMENT_FILE_PATH";
            public static string TR_INSTALLMENT_FILE_NAME = "TR_INSTALLMENT_FILE_NAME";
            public static string TR_INSTALLMENT_FILE_CONTENT_TYPE = "TR_INSTALLMENT_FILE_CONTENT_TYPE";

            //Added by Fahim Nasir 24/01/2018 14:16:06
            public static string CUSTOMER_COMPANY_NAME = "CUSTOMER_COMPANY_NAME";

            // Added by Muhammad Uzair on 23/01/2018 10:42:06 
            public static string QUIZ_EXAM_TEMPLATE_ID = "QUIZ_EXAM_TEMPLATE_ID";
            public static string QUIZ_EMIRATES_ID = "QUIZ_EMIRATES_ID";
            public static string WP_USER_COMPANY_ID = "WP_USER_COMPANY_ID";
            public static string QUIZ_USER_COMPANY_ID = "QUIZ_USER_COMPANY_ID";


            //Added by Fahim Nasir 22/02/2018 15:46:29
            public static string VAT_PERCENTAGE = "VAT_PERCENTAGE";
            public static string CUSTOMER_ID = "CUSTOMER_ID";
            //---------------------------------------
        }
        public static class PreviewKeys
        {
            public static string QUESTION_ID = "QUESTION_ID";
            public static string QUESTION_XML = "QUESTION_XML";
            public static string TRAINING_ID = "TRAINING_ID";
            public static string TRAINING_XML = "TRAINING_XML";
            public static string TRAINING_XML_MAIN_START = @"<MainElement  Preview=""1""  Dfileid="""" isDriver= ""1"" Dname="""" TName="""" Franchise=""DTC""  Default=""1"" RelPath=""" + Keys.RELATIVE_PATHS + "\">";
            public static string TRAINING_XML_MAIN_END = @"</MainElement>";
            public static string TRAINING_XML_COURSE_START = @"<Course CName=""""  Cid=""""   Cvoice="""" Cicon=""<DEFAULT_COURSE_ICON>""  schcourse=""1"" >";
            public static string TRAINING_XML_COURSE_END = @"</Course> ";


        }
        public enum SearchExamTemplateCriteria
        {

            TestTemplateId,
            ExamName,
            CreatedBy,
            DateCreatedFrom,
            DateCreateTo,
            PassingPercentageFrom,
            PassingPercentageTo,
            NoOfQuestionsFrom,
            NoOfQuestionsTo,

        };

        public enum SearchExamScheduleCriteria
        {

            TestId,
            ExamNumber,
            ExamTemplateName,
            CreatedBy,
            DateCreatedFrom,
            DateCreateTo,
            DateStartFrom,
            DateStartTo,
            DriverType,
            Trainer,
            Status,

        };
        public enum SearchInstructorCriteria
        {

            InstructorId,
            EmployeeId,
            EmirateNumber,
            PermitNo,
            Mobile,
            EmirateId,
            LanguageId,
            CountryId,
            VehicleType,
            //Added by Fahim Nasir 08/03/2018 10:32:45
            InstructorName


        };
        public enum InstructorStatus
        {

            New = 1,
            Submitted = 2,

        }
        public enum TestStatus
        {
            Scheduled = 1,
            Completed = 2,
            Cancelled = 3,

        };
        public enum DriverType
        {
            New = 1,
            Existing = 2,


        };
        public enum DriverApplicationLoginStatus
        {
            UnsuccessfullLogin,
            SuccessfullLoginNoTestPresent,
            SuccessfullTestPresent,
            SuccessfullNoTestTimeOut,
        };
        public enum AuthenticateDriverReturnKeys
        {
            DataSet = 0,
            LoginFlag = 1,
        };
        public enum TestTakerQuestionStatus
        {
            NotAttempted,
            Right,
            Wrong,
        };
        public enum TestTakerStatus
        {
            Absent = 1,
            Present = 2,
            Passed = 3,
            Failed = 4,
        };
        public static class SystemConfigurationKeys
        {
            public static string TEST_GRACE_PERIOD = "TEST_GRACE_PERIOD";
            public static string TEST_DURATION = "TEST_DURATION";
            public static string EXAM_PASSING_MARKS = "EXAM_PASSING_MARKS";
            public static string EXAM_GENERAL_INSTRUCTIONS = "EXAM_GENERAL_INSTRUCTIONS";
            public static string EXAM_DETAILS = "EXAM_DETAILS";

        }
        public enum UpdateTestTakerOptionalKeys
        {
            Status,
            StartedOn,
            CompletedOn,
            QuestionAttempted,

        };
        public enum CriteriaKeysReportPassFail
        {
            TestNumber,


        };
        public enum SearchQuestionsCriteria
        {
            QuestionTypeId,
            QuestionNumber,
            CreatedBy,
            CreatedOnFrom,
            CreatedOnTo,
            ApprovedFrom,
            ApprovedTo,
            Caption,
            DateCreatedFrom,
            DateCreateTo,
            Status,
            QuestionText,
            Section,
            StatusIn,
            IdNotToFetch,
        };
        public static class ManageQuestionKeys
        {
            public const string DT_QuestionTextCultureRes = "DT_QuestionTextCultureRes";
            public const string DT_QuestionCatOneCultureRes = "DT_QuestionCat1CultureRes";
            public const string DT_QuestionCatTwoCultureRes = "DT_QuestionCat2CultureRes";
            public const string DT_AnswerTextCultureRes = "DT_AnswerTextCultureRes";
            public const string QUESTIONS_MEDIA_DIRECTORY_VIRTUAL_PATH = "QUESTIONS_PICTURES_DIRECTORY_VIRTUAL_PATH";
            public const string DT_ImagesToDelete = "DT_ImagesToDelete";
            public const string Col_ImagesToDelete = "Col_ImagesToDelete";

        }
        public enum QuestionsStatus
        {
            Created = 1,
            New = 2,
            Rejected = 3,
            Active = 4,
            InActive = 5,
        };
        public static class SystemNumberKeys
        {
            public const string TEST = "TEST";
            public const string QUESTION = "QUESTION";
            public const string REQUEST = "REQUEST";


        }
        public enum SearchSectionKeys
        {
            SectionId,
            SectionName,
            CreatedBy,
            TotalQuestionFrom,
            TotalQuestionTo,

        };
        public enum SearchUsersCriteria
        {
            UserName,
            UserId,
            RoleId,
            Caption,
            CreatedBy,
            DateCreatedFrom,
            DateCreateTo,
            Status,
            SysStatus,
            //Added by M.Tariq on 04 Jan 2017
            FIRST_NAME_EN,
            LAST_NAME_EN,
            Mobile,
            //Added by Fahim Nasir on 24-MAY-2017 - Onsite
            IsActive,
            // Added by AVANZA\vijay.kumar on 08/12/2017 10:23:05
            Usertype
        };

        public enum SearchRolesCriteria
        {
            RoleName,
            RoleId,
            CreatedBy,
            SysStatus,
        };

        public enum SearchServiceRatesCriteria
        {
            Name,
            Date,
            VehicleType,
            SysStatus,
            // Added by MUHAMMADUZAIR\Administrator as Onsite Support on 27/11/2017 14:24:06 
            RegistrationType
        };
        public enum SearchCustomerServiceExamCriteria
        {
            Name,
            ExamCode,
            ToDate,
            FromDate,
            LicenceType,
            IsCancelled
        };
        public enum SearchPersonsCriteria
        {
            PersonID,
            Name,
            PassportNum,
            LicenseNum,
            RefNum,
            FileNum,
            DriverIdNum,
            TelNum,
            Franchise,
            Nationality,
        };
        public static class ManageSlideKeys
        {
            public const string DT_SlideNameCultureRes = "DT_SlideNameCultureRes";
            public const string DT_SlideFileUploadCultureRes = "DT_SlideFileUploadCultureRes";
            public const string DT_SlideNavigationCultureRes = "DT_SlideNavigationCultureRes";

        }
        public enum SlideType
        {
            NotSelected = -1,
            CustomSlide = 1,
            Questionnaire = 2,
            Navigation = 3,
        }

        public enum SlideStatus
        {

            Created = 1,
            Published = 2,
            Inactive = 3,
        }

        public enum SearchSlideCriteria
        {
            SlideID,
            SlideName,
            SlideNum,
            SlideType,
            SlideStatus,
            SlideStatusIn,
            CreatedBy,
            CreatedOnFrom,
            CreatedOnTo,

        };

        public enum RequestStatus
        {

            New = 1,
            Submitted = 2,

        }

        public enum RequestType
        {

            NewDriverTraining = 1,
            AccidentTraining = 2,
            RefresherTraining = 2,

        }




        public enum SearchCourseCriteria
        {
            CourseID,
            CourseName,
            CourseNum,
            CourseStatus,
            CreatedBy,
            CreatedOnFrom,
            CreatedOnTo,

        };

        public enum CoursetStatus
        {

            New = 1,
            Submitted = 2,

        }

        public static class ManageCourseKeys
        {

            public const string DT_CourseFileUploadCultureRes = "DT_CourseFileUploadCultureRes";
            public const string DT_CourseDescriptionCultureRes = "DT_CourseDescriptionCultureRes";

        }

        public enum SearchTrainingTemplateCriteria
        {
            TrainingTempId,

            CreatedBy,

            DailyFeesDTCFrom,
            DailyFeesDTCTo,
            DailyFeesNonDTCFrom,
            DailyFeesNonDTCTo,
            PreReqTraining,

            TxtTrainingName,

        };

        public static class ManageTrainingTemplateKeys
        {
            public const string DT_TrainingTemplateDescriptionCultureRes = "DT_TrainingTemplateDescriptionCultureRes";
            public const string DT_TrainingTemplateNameCultureRes = "DT_TrainingTemplateNameCultureRes";
        }
        public enum CriteriaKeysReportPsychometric
        {
            DriverName,
            RefNum,
            PassportNum,
            LicenseNum,


        };


        public enum RoomType
        {
            Training = 1,
            Exam = 2,
            Both = 3,
        }

        public enum RoomStatus
        {
            Active = 1,
            InActive = 2,

        }

        public enum SearchRoomCriteria
        {
            Status = 1,
            Name = 2,
            CapacityFrom = 3,
            CapacityTo = 4,
            Type = 5,
            RoomId = 6,
            CreatedBy = 7

        }

        public enum HolidayType
        {
            PulicHoliday = 1,
            Weekend = 2,
        }

        public enum FileTypes
        {
            Word = 1,
            Excel = 2,
            PDF = 3
        }
        public static class FileType
        {
            public const string Image = "1";
            public const string Animation = "2";
            public const string Audio = "3";
            public const string Docs = "4";
            public const string AnimationDocs = "5";
        }

        public static class MysteryShopperFileImportColumns
        {
            public const string JOB_ID = "JOB_ID";
            public const string VISIT_DATE = "VISIT_DATE";
            public const string VISIT_TIME = "VISIT_TIME";
            public const string POINTS_OBTAINED = "POINTS_OBTAINED";
            public const string TOTAL_POINTS = "TOTAL_POINTS";
            public const string RESULT = "RESULT_PERCENT";
            public const string VEHICLE_NUM = "VEHICLE_NUM";

        }

        public enum CriteriaKeysReportMysteryShopper
        {
            Phase,
            Year,

        };

        public enum SearchTrainingRequestCriteria
        {
            RequestID,
            RequestNum,
            Franchise,
            RequestType,
            Department,
            RequestStatus,
            CreatedBy,
            CreatedOnFrom,
            CreatedOnTo,

        };

        public enum CriteriaKeysReportTrainerActivity
        {
            TrainerName,
            StartedOnFrom,
            StartedOnTo,
            FinishedOn,
            SlideName,
            CourseName,
            TrainingTempId,


        };
        public enum CriteriaKeysReportDashboard
        {
            Month,


        };
        public enum TrainingScheduleStatus
        {
            Scheduled = 1,
            Started = 2,

        };

        public enum TrainingfOR
        {

            Internal = 1,
            External = 2
        };

        public enum TrainingInstanceStatus
        {
            Scheduled = 1,
            Started = 2,
            Completed = 3,

        };

        public enum SearchTrainingCriteria
        {
            TrainingId,
            TrainingNum,
            TrainerId,
            Status,
            CreatedBy,
            CreatedOnFrom,
            CreatedOnTo,
            StartFrom,
            StartTo,
            CompleteFrom,
            CompleteTo,
            DurationFrom,
            DurationTo,
            ParticipantFrom,
            ParticipantTo,
        };

        public enum CriteriaKeysReportTraineeAttendaceReport
        {
            TrainerName,
            StartedOnFrom,
            StartedOnTo,
            CompletedOnFrom,
            CompletedOnTo,
            TrainingTempName,
            TraineeName,

        };
        public enum MessageStatus
        {
            Queued = 100,
            InProcess = 101,
            MessageNotSentProcessed = 0,
            MessageProcessed = 1,
            DTCDEGGeneralError = -1,
            ProxyError = -2,
            DEGGatewaymessagesenderror = -3,
            DTCGatewaymessagesenderror = -4,
            FunctionErrorNonexistentfunctionFunctionnotSet = -5,
            Mainfunctionerror = -6,
            DEGGatewayconfigurationerror = -8,
            Authenticationfailed = -9,

        };

        public enum TrainingRequestDetailStatus
        {
            Created = 1,
            Submitted = 2,
            TrainingAllocated = 3,
            TrainingCancelled = 4,
            TrainingCompleted = 5,

        };

        public enum FinancialTransactionStatus
        {
            Created = 1,
            ReadyForPosting = 2,
            Posted = 3,


        };

        // AVANZA\jawwad.ahmed - 13/01/2017 09:16:20
        public enum RateCardCategory
        {
            Normal = 1, VIP = 2, Special = 3
        }

        // AVANZA\jawwad.ahmed - 13/01/2017 09:16:23
        public enum ServiceShifts
        {
            Morning = 1, Afternoon = 2, Night = 3
        }

        // AVANZA\jawwad.ahmed - 13/01/2017 09:16:25
        public enum MainService
        {
            DrivingLicense = 1
        }

        // AVANZA\jawwad.ahmed - 31/01/2017 14:10:58
        public enum ActivityModule
        {
            Admin = 0,
            // Added by Fahim Nasir on 01/02/2017 09:08:29
            CustomerManagement = 1,
            ModifyTrainingSchedule = 2
        }

        public enum ClassType
        {
            Practical = 6,
            Lecture = 1
        }

        public enum ClassScheduleStatus
        {
            Schedule = 0,
            Attended = 1,
            Cancelled = 2
        }

        // AVANZA\muhammad.awais - 18/08/2017 10:21:27
        public enum Emotions
        {
            Happy = 1,
            NoEmotion = 2,
            Sad = 3
        }


        //Added by Fahim Nasir 22/02/2018 11:08:13
        public enum CustomerChannel
        {
            CreatedFromSystem = 1,
            ImportedFromRTA = 2,
            Migrated = 3
        };
        //========================================

        // AVANZA\muhammad.awais - 18/08/2017 10:22:30
        public enum Channel
        {
            Mobile = 1,
            Web = 2
        }

        // AVANZA\muhammad.awais - 18/08/2017 11:49:36
        // Modified by AVANZA\muhammad.uzair on 25/10/2017 16:16:51
        // USER_TYPE_ID will be mapped with USER_TYPE table and used in User table in USER_TYPE_ID
        public enum UserType
        {
            Default = 1, //Default 
            Instructor = 2,
            Student = 3,
            Company = 4,
            Employee = 9,
            Other = 5,
            Csr = 6
        }

        public enum PriorityType
        {
            Lowest = 0,
            Low = 1,
            Medium = 2,
            High = 3,
            Highest = 4,
        }

        // AVANZA\Muhammad.Tariq - 18/08/2017 11:49:36      
        public enum NotificationState
        {
            None,
            New,
            Sent,
            Failed,
            Expired,
            Wait,
            Processing,
            AcceptedForDelivered,
            QueuedForDelivery,
            AccountCreditLimitReached,
            RequiredParametersmissing,
            InvalidMSIDN,
            Unroutablemessage,
            AuthenticationFailure,
            Messagecontent,
            FirewallBlock,
            Error
        }
        public enum AdapterStatus
        {
            None,
            Initializing,
            Running,
            Down,
            Closed,
        }
        public enum ResponseCodes
        {
            Accepted_For_Delivery = 0,
            Queued_For_Delivery = 1,
            Required_Parameters_missing = 2,
            Invalid_MSIDN_number_format = 3,
            Unroutable_message = 4,
            Authentication_Failure = 5,
            Message_content = 6,
            Firewall_Block = 7,
            Account_Credit_Limit_Reached = 8

        }

        public enum NotificationPriority
        {
            Low,
            Medium,
            High
        }

        // Added by MUHAMMADUZAIR\avanza on 18/09/2017 16:01:22
        // Modified by AVANZA\muhammad.uzair on 13/10/2017 11:30:46
        public enum TrainingType
        {
            ETDI = 1,
            ETTC = 2,
            Depots = 3,
            Internal_Department = 4,
            External_Company = 5,
            General = 7
        }

        // Added by MUHAMMADUZAIR\avanza on 18/09/2017 16:05:17
        public enum ActiveStatus
        {
            Active = 1,
            Inactive = 2
        }

        // Added by AVANZA\vijay.kumar on 16/11/2017 12:37:15
        public enum CompanyTypes
        {
            Internal = 1,
            External = 2,
            Depots = 3
        }



        // Added by AVANZA\muhammad.uzair on 26/09/2017 09:36:00
        public enum TestResultStatus
        {
            Pass = 1,
            Fail = 2,
            Absent = 3
        }

        // Added by AVANZA\muhammad.uzair on 10/10/2017 12:43:10
        public enum RegistrationType
        {
            ETDI = 1,
            ETTC = 2,
            All = 3
        }

        // Added by AVANZA\muhammad.uzair on 27/10/2017 15:55:22
        public enum CompanyEmployeeStatus
        {
            Pending = 0,
            Approved = 1
        }

        // Added by AVANZA\muhammad.uzair on 12/10/2017 09:08:48
        public enum CourseClassType
        {
            Theory = 1,
            Practical = 2,
            Both = 3
        }

        // Added by AVANZA\muhammad.uzair on 12/10/2017 09:11:12
        public enum CourseEligibility
        {
            General = 1,
            Driver = 2,
            Supervisor = 3,
            All = 4
        }

        public enum EtdiRequestType
        {
            UserRegistration = 1
        }

        public enum EtdiRequestStatus
        {
            Pending = 1,
            Approved = 2,
            Rejected = 3
        }
        // Added by AVANZA\muhammad.uzair on 19/10/2017 16:20:12
        public enum ExamType
        {
            ETDI = 1,
            ETTC = 2
        }

        // Added by AVANZA\muhammad.uzair on 27/10/2017 19:44:57
        public enum Status
        {
            Pending = 0,
            Approved = 1,
            Rejected = 2
        }

        // Added by AVANZA\muhammad.uzair on 31/10/2017 13:57:41
        public enum PaymentFor
        {
            ETDI = 1,
            ETTC = 2
        }

        // Added by AVANZA\muhammad.uzair on 31/10/2017 15:56:49
        public enum PaymentStatus
        {
            Pending = 0,
            Paid = 1,
            Credit = 2
        }

        // Added by AVANZA\muhammad.uzair on 07/11/2017 10:26:29
        public enum VehicleCurrentCondition
        {
            Working = 1,
            Accidented = 2,
            InWorkshopForRepairing = 3,
            MaintanenceRequired = 4
        }

        // Added by AVANZA\muhammad.uzair on 07/11/2017 10:29:08
        public enum VehicleState
        {
            Working = 1,
            Faulty = 2,
            MinorAccident = 3,
            MajorAccident = 4,
            NotReturned = 5
        }

        // Added by AVANZA\jawwad.ahmed on 02/11/2017 12:56:49
        public enum InstallmentStatus
        {
            Pending = 0,
            Paid = 1
        }

        // Added by AVANZA\jawwad.ahmed on 03/11/2017 13:17:24
        public enum TrainingRequestAudiance
        {
            General = 0,
            NewDriver = 1,
            NewSupervisor = 2,
            RefresherDriver = 3,
            RefresherSupervisor = 4
        }

        // Added by AVANZA\jawwad.ahmed on 03/11/2017 13:17:24
        public enum TrainingRequestSite
        {
            ETTCSite = 0,
            CompanySite = 1
        }

        // Added by AVANZA\muhammad.uzair on 13/11/2017 11:12:52
        public enum CustomerSaveState
        {
            SavedSuccessfully = 1,
            SavedWithPaymentPlanNotGenerated = 2,
            SavedUnsuccessfull = 3
        }
        // Added by AVANZA\jawwad.ahmed on 08/11/2017 15:34:20
        public enum IndividualDiscountStatus
        {
            Pending = 0,
            Approved = 1,
            Rejected = 2,
            Consumed = 3
        }

        // Added by AVANZA\jawwad.ahmed on 08/11/2017 15:44:30
        public enum DiscountType
        {
            Fixed = 1,
            Percentage = 2
        }

        // Added by AVANZA\jawwad.ahmed on 14/11/2017 17:03:17
        public enum PaymentType
        {
            Cash = 0, Cheque = 1, Card = 2, Unknown = 3
        }

        // Added by AVANZA\muhammad.uzair on 16/11/2017 12:33:35
        public enum PracticalSessionState
        {
            Started = 1,
            Finished = 2
        }


        //Added by Fahim Nasir 20/11/2017 10:03:40
        public enum RequestValidationStatus
        {
            //Training Request Participant is greater than capacity of any room.
            RoomCapacityCheckFailed = 101,

            //Request's participant count is greater than available seats in scheduled slot.
            NoAvailableSeatsForRequest = 102,

            //General Error in validation method.
            GeneralError = -1,
            GoodToGo = 1,
        }

        //Added by Fahim Nasir 31/10/2017 13:52:23
        public enum RegistrationRequestStatus
        {
            Approved = 1
        };

        // Added by AVANZA\vijay.kumar on 16/01/2018 12:18:50
        public enum EttcExamResult
        {
            Pass = 1,
            Fail = 2,
            NotAttended = 3,
            Absent = 4
        };

        // Added by AVANZA\vijay.kumar on 16/01/2018 17:48:39
        //for Vehicles Column ET_TYPE
        public enum EtType
        {
            EtType1 = 1,
            EtType2 = 2
        };

        // Added by AVANZA\vijay.kumar on 16/01/2018 17:48:39
        //for Vehicles Column Plate_TYPE
        public enum PlateType
        {
            PlateType1 = 1,
            PlateType2 = 2
        };

        // Added by AVANZA\vijay.kumar on 17/01/2018 10:55:20
        public enum VehiclePlateColor
        {
            yellow = 1,
            red = 2
        };

        // Added by AVANZA\vijay.kumar on 23/01/2018 14:10:40
        public enum PaymentCategory
        {
            ReplacementRtaBook = 1,
            OpenFile = 2
        };

        // Added by AVANZA\vijay.kumar on 23/01/2018 14:29:11
        public enum StockType
        {
            Booklet = 1,
            StudentPracticallesson = 2,
            LicenseCard = 3,
            StudentOpeningGiftFile = 4,
            CertificateTemplatePaperEnvelope = 5,
            OtherGifts = 6,
            RTANewDriverSticker = 7
        };

        // Added by Muhammad Uzair on 25/01/2018 10:55:18 
        public enum BenefitType
        {
            LumpSum = 1,
            Discount = 2
        };
        // aDDED BY avanza\VIJAY.KUMAR ON 24/01/2018 17:29:43
        public enum ActivityType
        {
            Registration = 1,
            Payments = 2,
            TheorySchedule = 3,
            PracticalSchedule = 4,
            ExamBooking = 5,
            AttendanceMarks = 6,
            LicenseIssue = 7,
            ExamResult = 8
        };

        // Added by AVANZA\vijay.kumar on 06/02/2018 16:11:44
        public enum DailyFloatTransaction
        {
            Issued = 1,
            Received = 2
        };

        // Added by AVANZA\vijay.kumar on 06/02/2018 16:43:44

        public enum DailyFloatTransactionStatus
        {
            Pending = 0,
            Approved = 1,
            Reject = 2
        };

        public enum GeneralRequestType
        {
            CourseChange = 1,
            InstructorChange = 2
        }

        public enum GeneralRequestStatus
        {
            Pending = 1,
            Approved = 2,
            Rejected = 3,
            InProgress = 4,
            Completed = 5
        }
        // Added by Muhammad Uzair on 14/02/2018 17:06:26 
        public enum PsychometricReponse
        {
            StronglyAgree = 1,
            Agree = 2,
            Neutral = 3,
            Disagree = 4,
            StronglyDisagree = 5
        }

        // Added by Muhammad Uzair on 15/02/2018 10:52:06 
        public enum PsychometricStatus
        {
            Active = 1,
            Inactive = 0
        }
        // Added by AVANZA\vijay.kumar on 16/02/2018 13:10:44
        public enum Transactiontype
        {
            PettyCash =1,
            DepartmentExpense =2
        };

        public enum AdvancedPaymentType
        {
            RTA = 1,
            DHA = 2
        };

    }
}

