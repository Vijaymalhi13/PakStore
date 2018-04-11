using System;
using System.Text;
using System.Threading;
using System.Globalization;
using eLearning.Common.Config;
using System.Collections;
using eLearning.Common.Utils;
using System.Data;
using System.Reflection;
using System.Resources;
using System.Configuration;
using System.IO;
using System.Text.RegularExpressions;
using System.Security.AccessControl;
using System.Security.Cryptography;
using Escrow.Common.Utils;
using System.Collections.Generic;

namespace eLearning.Common.Utils
{
    // Added by Fahim Nasir on 23/01/2017 14:05:11
    public static class ATTACHMENTS
    {
        public static readonly string TableName = "ATTACHMENTS";
        public static readonly string ATTACHMENT_ID = "ATTACHMENT_ID";
        public static readonly string DOC_ID = "DOC_ID";
        public static readonly string ATTACHMENT = "ATTACHMENT";
        public static readonly string TITLE = "TITLE";
        public static readonly string FILE_NAME = "FILE_NAME";
        public static readonly string FILE_LENGTH = "FILE_LENGTH";
        public static readonly string CONTENT_TYPE = "CONTENT_TYPE";
        public static readonly string CREATED_BY = "CREATED_BY";
        public static readonly string CREATED_ON = "CREATED_ON";
        public static readonly string LAST_UPDATED_BY = "LAST_UPDATED_BY";
        public static readonly string LAST_UPDATED_ON = "LAST_UPDATED_ON";
    }
    public static class ACTIVITY_DOCUMENT_TYPE
    {
        public static readonly string TableName = "ACTIVITY_DOCUMENT_TYPE";
        public static readonly string DOC_TYPE_NAME = "DOC_TYPE_NAME";
        //public static string DOC_TYPE_NAME
        //{
        //    get { return DBUtils.GetCultureColumnName( }
        //}
        public static readonly string DOC_TYPE_NAME_EN = "DOC_TYPE_NAME_EN";
        public static readonly string DOC_TYPE_NAME_AR = "DOC_TYPE_NAME_AR";
        public static readonly string IS_ACTIVE = "IS_ACTIVE";
        public static readonly string ACTIVITY_TYPE_ID = "ACTIVITY_TYPE_ID";
        public static readonly string DOCUMENT_TYPE_ID = "DOCUMENT_TYPE_ID";
    }
    public static class DOC_ARCHIVE
    {
        public static readonly string TableName = "DOC_ARCHIVE";

        public static readonly string DOCUMENT_ID = "DOCUMENT_ID";
        public static readonly string TITLE = "TITLE";
        public static readonly string DOCUMENT = "DOCUMENT";
        public static readonly string DESCRIPTION = "DESCRIPTION";
        public static readonly string DOCUMENT_TYPE_ID = "DOCUMENT_TYPE_ID";
        public static readonly string ENTITY_ID = "ENTITY_ID";
        public static readonly string IS_DELETED = "IS_DELETED";
        public static readonly string ENTITY_INTERNAL_ID = "ENTITY_INTERNAL_ID";
        public static readonly string FILE_NAME = "FILE_NAME";
        public static readonly string FILE_LENGTH = "FILE_LENGTH";
        public static readonly string CONTENT_TYPE = "CONTENT_TYPE";
        public static readonly string CREATED_ON = "CREATED_ON";
        public static readonly string CREATED_BY = "CREATED_BY";
        public static readonly string CREATOR_SESSION_ID = "CREATOR_SESSION_ID";
        public static readonly string LAST_UPDATED_ON = "LAST_UPDATED_ON";
        public static readonly string LAST_UPDATED_BY = "LAST_UPDATED_BY";
        public static readonly string LASTUPDATOR_SESSION_ID = "LASTUPDATOR_SESSION_ID";
    }

    public class Util
    {
        private static Logger m_logger = Logger.getInstance();
        public static string MODULE_NAME = "Utils.Util";

        public Util()
        {
        }
        public static string UrlChk(string url)
        {
            string chk = "http://";
            //string
            if (url.Equals(""))
            {
                return "";
            }
            else if (url.StartsWith("http://") || url.StartsWith("https://") || url.StartsWith("ftp://"))
                return url;
            else
            {
                url = chk + url;
                return url;
            }


        }

        // Added by Fahim Nasir on 17/01/2017 14:18:20
        public static string ConvertDateToShortString(DateTime date)
        {

            if (!date.ToShortDateString().Equals("1/1/0001") && !date.ToShortDateString().Equals("01/01/0001"))
                return date.Day.ToString().PadLeft(2, '0') + "/" + date.Month.ToString().PadLeft(2, '0') + "/" + date.Year.ToString().PadLeft(2, '0');
            else
                return "";
        }
        public static string ConvertDateTimeForSQL(DateTime date)
        {
            return " Convert(datetime,'" + date.ToString("dd MMM yyyy HH:mm:ss:fff") + "' , 113) ";
        }
        public static string ConvertStringToDateForDBUpdate(Object obj)
        {
            if (obj != null && obj != DBNull.Value && obj.ToString().Length > 0)
                return string.Format("Convert(datetime,'{0}',103)", obj);

            else
                return "NULL";
        }

        public static DataTable GetDataTableForDBUpdate(DataTable dt)
        {
            return GetDataTableForDBUpdate(dt
                , new Dictionary<string, string>()
                , new Dictionary<string, string>());
        }

        public static DataTable GetDataTableForDBUpdate(DataTable dt
            , Dictionary<string, string> fkCoumnWithTableName
            , Dictionary<string, string> ignoredColumns)
        {
            DataTable dtConverted = new DataTable(dt.TableName);

            // make clone of passed data table with string type columns.
            foreach (DataColumn dc in dt.Columns)
            {
                if (ignoredColumns != null
                    && ignoredColumns.ContainsKey(dc.ColumnName))
                {
                    //ignore.
                }
                else
                {
                    dtConverted.Columns.Add(dc.ColumnName, typeof(string));
                }
            }


            foreach (DataRow drOriginal in dt.Rows)
            {

                if (drOriginal.RowState == DataRowState.Added
                   || drOriginal.RowState == DataRowState.Deleted
                   || drOriginal.RowState == DataRowState.Modified)
                {

                    DataRow dr;
                    if (drOriginal.RowState == DataRowState.Deleted)
                    {
                        //special case, as data cant be read from deleted row we have to use some alternate.
                        try
                        {
                            drOriginal.RejectChanges();
                            dr = dt.NewRow();
                            dr.ItemArray = drOriginal.ItemArray;
                        }
                        finally
                        {
                            drOriginal.Delete();
                        }

                    }
                    else
                    {
                        dr = drOriginal;
                    }
                    DataRow drConverted = dtConverted.NewRow();
                    foreach (DataColumn dcConverted in dtConverted.Columns)
                    {
                        DataColumn dc = dt.Columns[dcConverted.ColumnName];
                        long longTemp = 0;

                        //for autogenerated column
                        if (dc.AutoIncrement
                            && dr.RowState == DataRowState.Added)
                        {
                            drConverted[dc.ColumnName] = DALConstants.CustomTags.Token;
                        }
                        // for fk columns
                        else if (fkCoumnWithTableName != null
                            && fkCoumnWithTableName.ContainsKey(dc.ColumnName)
                            && dr.RowState == DataRowState.Added
                            && (dr[dc.ColumnName] == DBNull.Value
                                    || dr[dc.ColumnName].ToString() == "-1"))
                        {
                            drConverted[dc.ColumnName] =
                                string.Format(DALConstants.TagFormat
                                    , fkCoumnWithTableName[dc.ColumnName]);
                        }


                        // data type dependent
                        else if (dc.DataType == typeof(int)
                            || dc.DataType == typeof(long)
                            || dc.DataType == typeof(byte))
                        {
                            drConverted[dc.ColumnName] =
                                ConvertIntToStringForDBUpdate(dr[dc.ColumnName]);
                        }
                        else if (dc.DataType == typeof(DateTime))
                        {
                            drConverted[dc.ColumnName] =
                                ConvertDateTimeToDateTimeForDBUpdate(dr[dc.ColumnName]);
                        }
                        else
                        {
                            drConverted[dc.ColumnName] =
                               ConvertStringToStringForDBUpdate(dr[dc.ColumnName]);
                        }
                    }

                    dtConverted.Rows.Add(drConverted);
                    drConverted.AcceptChanges();

                    switch (drOriginal.RowState)
                    {
                        case DataRowState.Added:
                            drConverted.SetAdded();
                            break;

                        case DataRowState.Deleted:
                            drConverted.Delete();
                            break;


                        case DataRowState.Modified:
                            drConverted.SetModified();
                            break;
                    }

                }
            }

            return dtConverted;
        }

        // Added by Fahim Nasir on 23/01/2017 09:53:34
        public static string GetStringValue(DataRow dr, string columnName)
        {
            string str = string.Empty;
            if (dr != null && dr[columnName] != DBNull.Value)
            {
                str = dr[columnName].ToString();
            }
            return str;
        }

        public static string ConvertStringToDateTimeForDBUpdate(Object obj)
        {
            if (obj != null && obj != DBNull.Value && obj.ToString().Length > 0)
                return string.Format("Convert(datetime,'{0}',103)", obj);
            else
                return "NULL";
        }

        public static string ConvertDateTimeToDateTimeForDBUpdate(Object obj)
        {
            if (obj.GetType() == typeof(DateTime))
                return string.Format("'{0}'", ((DateTime)obj).ToString("dd-MMM-yyyy hh:mm:ss tt"));

            else
                return "NULL";
        }
        //=============================================

        public static string ConvertStringToStringForDBUpdate(Object obj)
        {
            if (obj != null && obj != DBNull.Value && obj.ToString().Length > 0)
                return "N'" + (string)obj + "'";

            else
                return "NULL";
        }

        public static string ConvertIntToStringForDBUpdate(Object obj)
        {
            if (obj == null)
                return "NULL";
            if (obj == DBNull.Value)
                return "NULL";
            if (obj.ToString() == "")
                return "NULL";
            else if (Convert.ToInt32(obj) == -1)
                return "NULL";
            else
                return obj.ToString();

        }

        public static string CodeBuilder(string testStr, int token)
        {
            //string testStr="Test <NUM>";
            int count = 0;
            //int size=5;
            int size = Convert.ToInt32(SystemParameters.GetParameter("CODE_LENGTH"));
            //int token=13;
            string tkstr = "";
            //token=token+1;
            StringBuilder sb = new StringBuilder(testStr);
            tkstr = token.ToString();
            count = tkstr.Length;
            count = size - count;
            if (count > 0)
                for (int i = 0; i < count; i++)
                    tkstr = "0" + tkstr;
            sb.Replace("<NUM>", tkstr);

            return sb.ToString();
        }
        public static string ExtractFileName(string filenameandpath)
        {
            if (filenameandpath.Equals("")) return "";

            int pos = filenameandpath.LastIndexOf("\\") + 1;
            string filename = filenameandpath.Substring(pos);
            return filename;


        }
        public static string FormatDecimalValue(decimal a_num)
        {
            string DecVal = "";

            if (a_num.ToString().IndexOf(".") != -1)
            {
                string IntegerPart = a_num.ToString().Substring(0, a_num.ToString().IndexOf("."));
                string DecimalPart = a_num.ToString().Substring(a_num.ToString().IndexOf(".") + 1);
                string sDecVal = Convert.ToDecimal(IntegerPart).ToString("N");
                DecVal = sDecVal.Substring(0, sDecVal.IndexOf(".")) + "." + DecimalPart;

                //				if( a_num<0 && a_num<1 )
                //					DecVal = "-" + DecVal;

            }
            else
            {
                string sDecVal = Convert.ToDecimal(a_num).ToString("N");
                DecVal = sDecVal.Substring(0, sDecVal.IndexOf(".")) + ".00";

            }
            return DecVal;
        }
        public static string ConvertHashtableToString(Hashtable htable, string[] keysOrder)
        {
            if (keysOrder.Length <= 0)
                return "";

            string tmp = Convert.ToString(htable[keysOrder[0]]);
            for (int i = 1; i < keysOrder.Length; i++)
            {
                tmp += ", " + keysOrder[i] + " = " + Convert.ToString(htable[keysOrder[i]]);
            }
            return tmp;
        }
        public static string ConvertHashtableToString(Hashtable htable)
        {
            if (htable.Keys.Count > 0)
            {
                string[] keys = new string[htable.Keys.Count];
                int i = 0;
                foreach (string k in htable.Keys)
                {
                    keys[i++] = k;
                }
                return ConvertHashtableToString(htable, keys);
            }
            else
            {
                return "";
            }
        }
        public static string ConvertDataTableToCSVData(System.Data.DataTable dt)
        {
            string[] columnNamesInOrder = new string[dt.Columns.Count];
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                columnNamesInOrder[i] = dt.Columns[i].ColumnName;
            }
            return ConvertDataTableToCSVData(columnNamesInOrder, dt);
        }
        public static string ConvertDataTableToCSVData(string[] columnNamesInOrder, System.Data.DataTable dt)
        {
            string csvData = "";
            foreach (string colName in columnNamesInOrder)
            {
                System.Data.DataColumn dc = dt.Columns[colName];
                if (dc.Caption.Equals(""))
                {
                    csvData += dc.ColumnName + ",";
                }
                else
                {
                    csvData += dc.Caption + ",";
                }
            }
            if (!csvData.Equals(""))
                csvData = csvData.Substring(0, csvData.Length - 1);
            csvData += Environment.NewLine;

            if (dt != null)
            {
                foreach (System.Data.DataRow dr in dt.Rows)
                {
                    foreach (string colName in columnNamesInOrder)
                    {
                        csvData += Convert.ToString(dr[colName]);
                        csvData += ",";
                    }
                    if (csvData.LastIndexOf(",") == csvData.Length - 1)
                    {
                        csvData = csvData.Substring(0, csvData.Length - 1);
                    }
                    csvData += Environment.NewLine;
                }
            }

            return csvData;
        }
        public static string GetCrystalDateSearchString(string dateFieldName, string op, DateTime compareDate)
        {
            string searchCriteria = "";

            int year = compareDate.Year;
            int month = compareDate.Month;
            int day = compareDate.Day;
            searchCriteria += "Date(" + dateFieldName + ") " + op + " Date(" + year + "," + month + "," + day + ")";

            return searchCriteria;
        }
        public static DataTable Create_1to1_Or_Mto1_JoinBetweenDataTable(DataTable dtPrimary, DataTable dtSecondary, string[] primaryKeyColumns)
        {
            string[] secondaryKeyColumns = new string[primaryKeyColumns.Length];
            for (int i = 0; i < secondaryKeyColumns.Length; i++)
            {
                secondaryKeyColumns[i] = primaryKeyColumns[i];
            }

            string[] reqSecColumns = new string[dtSecondary.Columns.Count];
            for (int i = 0; i < reqSecColumns.Length; i++)
            {
                reqSecColumns[i] = dtSecondary.Columns[i].ColumnName;
            }

            return Create_1to1_Or_Mto1_JoinBetweenDataTable(dtPrimary, dtSecondary, primaryKeyColumns, secondaryKeyColumns, reqSecColumns, reqSecColumns);
        }
        public static DataTable Create_1to1_Or_Mto1_JoinBetweenDataTable(DataTable dtPrimary, DataTable dtSecondary, string[] primaryKeyColumns, string[] secondaryKeyColumns, string[] reqSecColumns)
        {
            return Create_1to1_Or_Mto1_JoinBetweenDataTable(dtPrimary, dtSecondary, primaryKeyColumns, secondaryKeyColumns, reqSecColumns, reqSecColumns);
        }
        public static DataTable Create_1to1_Or_Mto1_JoinBetweenDataTable(DataTable dtPrimary, DataTable dtSecondary, string[] primaryKeyColumns, string[] secondaryKeyColumns, string[] reqSecColumns, string[] reqColNames)
        {
            DataTable dtResult = null;
            dtResult = dtPrimary.Clone();


            if (reqSecColumns != null && reqSecColumns.Length > 0)
            {
                DataColumn dc = null;
                int counter = 0;
                foreach (string colName in reqSecColumns)
                {
                    dc = dtSecondary.Columns[colName];
                    dtResult.Columns.Add(new DataColumn(reqColNames[counter++], dc.DataType));
                }
            }
            else
            {
                foreach (DataColumn dc in dtSecondary.Columns)
                {
                    dtResult.Columns.Add(new DataColumn(dc.ColumnName, dc.DataType));
                }
            }

            string[] currPKId = new string[primaryKeyColumns.Length];
            string searchCriteria = "";
            DataRow[] drsCurrSecondaryDetails = null;
            foreach (DataRow dr in dtPrimary.Rows)
            {
                DataRow drFinal = dtResult.NewRow();
                foreach (DataColumn dc in dtPrimary.Columns)
                {
                    drFinal[dc.ColumnName] = dr[dc.ColumnName];
                }

                searchCriteria = "";
                for (int i = 0; i < currPKId.Length; i++)
                {
                    currPKId[i] = Convert.ToString(dr[primaryKeyColumns[i]]);
                    if (!searchCriteria.Equals(""))
                    {
                        searchCriteria += " AND ";
                    }
                    searchCriteria += secondaryKeyColumns[i] + "='" + currPKId[i] + "'";
                }
                drsCurrSecondaryDetails = dtSecondary.Select(searchCriteria);
                if (drsCurrSecondaryDetails != null && drsCurrSecondaryDetails.Length > 0)
                {
                    int counter = 0;
                    foreach (string reqColName in reqSecColumns)
                    {
                        drFinal[reqColNames[counter++]] = drsCurrSecondaryDetails[0][reqColName];
                    }
                }

                dtResult.Rows.Add(drFinal);
            }

            return dtResult;
        }

        // Added by Fahim Nasir on 12/01/2017 16:57:03
        public static string GetCultureColumnName(string columnName)
        {
            CultureInfo ci = Thread.CurrentThread.CurrentCulture;
            string RESULT = "";
            switch (ci.Name)
            {
                case "ar-AE": RESULT = columnName + "_AR"; break;
                case "en-GB": RESULT = columnName + "_EN"; break;
                default: RESULT = columnName + "_EN"; break;
            }
            return RESULT;
        }
        //==============================================



        public class CustomRegularExpressions
        {
            public static string PhoneNo = @"^[0-9\-()+]*$";
            public static string POBox = "^[0-9]{0,10}$";
            public static string AlphaNumeric = @"^[0-9A-Za-z]*$";
            public static string Numeric = @"^[0-9]*$";
            public static string StrictCardNumber = @"^((\d+\-\d+)|(\d))*$";
            public static string FlexibleCardNumber = @"^[0-9\-]*$";
            // Added by Fahim Nasir on 12/01/2017 09:27:45
            public static string NumbersWithHyphen = @"^[0-9-]*$";
            public static string AlphabetsOnlyWithSpace = @"^[a-zA-z]*$";
            public static string AlphabetsArabicAndEnglish = @"^[a-zA-z\u0000-\u0099\s]$";
            //=============================================
        }
        public static string GetValueFromConfig(string Key)
        {
            return (new System.Configuration.AppSettingsReader()).GetValue(Key, typeof(System.String)).ToString();
        }
        public static string GetValueFromResource(string baseName, Assembly Asm, string Key)
        {
            try
            {
                ResourceManager resource = new ResourceManager(baseName, Asm);
                return resource.GetString(Key);
            }
            catch (Exception Ex)
            {
                return " ";
            }
        }

        // Added by Fahim Nasir on 10/01/2017 11:25:26
        public static string RemoveDirtyParams(string value)
        {
            if (value.Contains("'"))
            {
                value = value.Replace("'", "");
            }
            if (value.Contains(","))
            {
                value = value.Replace(",", "");
            }
            if (value.Contains("`"))
            {
                value = value.Replace("`", "");
            }
            if (value.Contains("~"))
            {
                value = value.Replace("~", "");
            }
            if (value.Contains("*"))
            {
                value = value.Replace("*", "");
            }
            if (value.Contains("--"))
            {
                value = value.Replace("--", "");
            }
            return value;
        }
        //================================================

        //		public static string RectifyValues(string stringWithSingleQuote)
        //		{
        //			StringBuilder buffer = new StringBuilder(stringWithSingleQuote);
        //			string ResultString = "";
        //			
        //			for (int i = 0;i<buffer.Length;i++)
        //			{
        //				
        //				if(buffer[i] == '\'')
        //				{
        //					ResultString += "&#39";
        //				}
        //				else if(buffer[i] == '\'')
        //				{
        //					ResultString += "&#39";
        //				}
        //				else 
        //				{
        //					ResultString += buffer[i];
        //				}
        //			}
        //			return ResultString;
        //		}	
        public static string RectifyValues(string stringWithSingleQuote)
        {
            stringWithSingleQuote = stringWithSingleQuote.Trim();
            StringBuilder buffer = new StringBuilder(stringWithSingleQuote);
            buffer = buffer.Replace("\'", "\''");
            //buffer = buffer.Replace(">","&gt;");
            //buffer = buffer.Replace("<","&lt;");
            //buffer = buffer.Replace("\"","&quote;");

            return buffer.ToString();
        }
        //public static int GridSize(DALConstants.GRIDSIZE size)
        //{
        //    switch (size)
        //    {
        //        case DALConstants.GRIDSIZE.SMALL:
        //            {
        //               string GridSize = (new System.Configuration.AppSettingsReader()).GetValue("GRIDSMALLSIZE", typeof(System.String)).ToString();
        //               int Size = 0;
        //               if (int.TryParse(GridSize, out Size))
        //               {
        //                   return Size;
        //               }
        //               else
        //               {
        //                   return 0;
        //               }
        //            }

        //        case DALConstants.GRIDSIZE.MEDIUM:
        //            {
        //                string GridSize = (new System.Configuration.AppSettingsReader()).GetValue("GRIDMEDIUMSIZE", typeof(System.String)).ToString();
        //                int Size = 0;
        //                if (int.TryParse(GridSize, out Size))
        //                {
        //                    return Size;
        //                }
        //                else
        //                {
        //                    return 0;
        //                }
        //            }

        //        case DALConstants.GRIDSIZE.LARGE:
        //            {
        //                string GridSize = (new System.Configuration.AppSettingsReader()).GetValue("GRIDLARGESIZE", typeof(System.String)).ToString();
        //                int Size = 0;
        //                if (int.TryParse(GridSize, out Size))
        //                {
        //                    return Size;
        //                }
        //                else
        //                {
        //                    return 0;
        //                }
        //            }

        //    }
        //    return 0;
        //}

        public static void checkIfFolderExist(string folder)
        {
            bool _isExist = Directory.Exists(SystemParameters.GetParameter("DNRD_ROOT") + folder);
            if (!_isExist)
            {
                Directory.CreateDirectory(SystemParameters.GetParameter("DNRD_ROOT") + folder);
            }
        }

        public static bool validateDate(DateTime dtFrom, DateTime dtTo)
        {
            //returns true if From date is less than to Date.
            if (dtFrom.CompareTo(dtTo) <= 0)
                return true;

            return false;
        }
        public static bool TextBoxContainsNonZeroNumber(string pTextBox)
        {
            try
            {
                if (pTextBox.Trim() != "")
                {
                    decimal test = decimal.Parse(pTextBox.Trim());
                    if (test > 0)
                        return true;
                }
                return false;
            }
            catch (InvalidCastException ex)
            {
                return false;
            }
        }

        public static bool IsNumeric(string pTextBox)
        {
            try
            {
                if (pTextBox.Trim() != "")
                {
                    decimal test = decimal.Parse(pTextBox.Trim());
                    return true;
                }
                return false;
            }
            catch (FormatException ex)
            {
                return false;
            }
        }
        public static bool TextBoxContainsPositiveNumber(string pTextBox)
        {
            try
            {
                if (pTextBox.Trim() != "")
                {
                    decimal test = decimal.Parse(pTextBox.Trim());
                    if (test >= 0)
                        return true;
                    else
                        return false;
                }
                return false;
            }
            catch (FormatException ex)
            {
                return false;
            }
        }
        public static bool PercentageValidation(string pTextBox)
        {
            try
            {
                if (pTextBox.Trim() != "")
                {
                    decimal test = decimal.Parse(pTextBox.Trim());
                    if (test > 0 && test <= 100)
                        return true;
                    else
                        return false;
                }
                return false;
            }
            catch (FormatException ex)
            {
                return false;
            }
        }

        public static void SetInitialPermissions(out ArrayList alPermissions, System.Web.SessionState.HttpSessionState objSession, System.Web.UI.Page objPage)
        {

            DataSet ds = (DataSet)objSession["PERMISSIONS"];

            if (ds != null)
            {
                alPermissions = new ArrayList(ds.Tables[0].Rows.Count);

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    alPermissions.Add(ds.Tables[0].Rows[i][0].ToString());
                }
            }
            else
            {
                //System.Web.Security.FormsAuthentication.SignOut();
                //objSession.RemoveAll();
                //objSession.Abandon();
                //// FormsAuthentication.RedirectToLoginPage();                
                alPermissions = null;
                //objPage.Response.Redirect("../UI/Login.aspx", false);
            }

        }

        public static DataTable GetGroupedDataTable(DataTable sourceTable, string[] groupColNames, string aggregateColName, string aggregateFuncName)
        {
            DataTable tempTable = new DataTable();
            DataTable resultTable = new DataTable();
            tempTable = sourceTable.Copy();

            resultTable = sourceTable.Clone();
            Hashtable ht = new Hashtable();
            string key = "";
            string filter = "";
            foreach (DataRow dr in tempTable.Rows)
            {
                filter = "";
                key = "";
                foreach (string s in groupColNames)
                {
                    if (tempTable.Columns[s].DataType == Type.GetType("System.DateTime"))
                    {
                        key += Convert.ToDateTime(dr[s]).Ticks.ToString();
                    }
                    else
                    {
                        if (dr[s] != DBNull.Value) key += dr[s].ToString() + "|";
                    }
                }
                if (!ht.ContainsKey(key))
                {
                    ht.Add(key, "");
                    DataRow currRow = resultTable.NewRow();
                    foreach (DataColumn dc in tempTable.Columns)
                    {
                        currRow[dc.ColumnName] = dr[dc.ColumnName];
                    }
                    filter = "";

                    int i = 0;
                    for (i = 0; i < groupColNames.Length; i++)
                    {
                        if (!filter.Equals(""))
                        {
                            filter += " AND ";
                        }
                        filter += groupColNames[i] + " = '" + dr[groupColNames[i]].ToString() + "'";
                    }

                    try
                    {
                        currRow[aggregateColName] = Convert.ToDecimal(tempTable.Compute(aggregateFuncName + "(" + aggregateColName + ")", filter));
                        resultTable.Rows.Add(currRow);
                    }
                    catch
                    {

                    }
                }
            }

            return resultTable;
        }



        private static string CapText(Match m)
        {
            // Get the matched string.
            string x = m.ToString();
            // If the first char is lower case...
            if (char.IsLower(x[0]))
            {
                // Capitalize it.
                return char.ToUpper(x[0]) + x.Substring(1, x.Length - 1);
            }
            return x;
        }

        public static string ConvertStringToTitleCase(string text)
        {
            string result = Regex.Replace(text.ToLower(), @"\w+", new MatchEvaluator(Util.CapText));
            return result;
        }

        public static int getMaxNumberOfSameSuccessiveAlphabets(string text)
        {
            int finalNumSuccessive = 0;
            int numSuccessive = 0;

            char prevChar = '1';

            for (int i = 0; i < text.Length; i++)
            {
                if (!Char.IsLetter(text[i]))
                {
                    if (numSuccessive > finalNumSuccessive)
                    {
                        finalNumSuccessive = numSuccessive;
                    }
                    numSuccessive = 0;
                    continue;
                }

                if (numSuccessive == 0)
                {
                    prevChar = text[i];
                    numSuccessive++;
                }
                else if (text[i] == prevChar)
                {
                    numSuccessive++;
                }
                else
                {
                    if (numSuccessive > finalNumSuccessive)
                    {
                        finalNumSuccessive = numSuccessive;
                    }

                    prevChar = text[i];
                    numSuccessive = 1;
                }
            }

            if (numSuccessive > finalNumSuccessive)
            {
                finalNumSuccessive = numSuccessive;
            }

            return finalNumSuccessive;
        }

        public static int getMaxNumberOfSameSuccessiveDigits(string text)
        {
            int finalNumSuccessive = 0;
            int numSuccessive = 0;

            char prevChar = 'a';

            for (int i = 0; i < text.Length; i++)
            {
                if (!Char.IsDigit(text[i]))
                {
                    if (numSuccessive > finalNumSuccessive)
                    {
                        finalNumSuccessive = numSuccessive;
                    }
                    numSuccessive = 0;
                    continue;
                }

                if (numSuccessive == 0)
                {
                    prevChar = text[i];
                    numSuccessive++;
                }
                else if (text[i] == prevChar)
                {
                    numSuccessive++;
                }
                else
                {
                    if (numSuccessive > finalNumSuccessive)
                    {
                        finalNumSuccessive = numSuccessive;
                    }

                    prevChar = text[i];
                    numSuccessive = 1;
                }
            }

            if (numSuccessive > finalNumSuccessive)
            {
                finalNumSuccessive = numSuccessive;
            }

            return finalNumSuccessive;
        }


        public static int getAlphabetCount(string text)
        {
            int numAlphabets = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (Char.IsLetter(text[i]))
                    numAlphabets++;
            }
            return numAlphabets;
        }

        public static int getDigitCount(string text)
        {
            int numDigits = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (Char.IsDigit(text[i]))
                    numDigits++;
            }
            return numDigits;
        }

        public static int getMaxNumberOfSuccessiveAlphabets(string text)
        {
            int finalNumSuccessive = 0;
            int numSuccessive = 0;

            for (int i = 0; i < text.Length; i++)
            {
                if (Char.IsLetter(text[i]))
                {
                    numSuccessive++;
                }
                else
                {
                    if (numSuccessive > finalNumSuccessive)
                    {
                        finalNumSuccessive = numSuccessive;
                    }
                    numSuccessive = 0;
                }
            }

            return finalNumSuccessive;
        }


        public static string getMd5Hash(string input)
        {
            string sMethod = "getMd5Hash";
            System.Security.Cryptography.MD5CryptoServiceProvider md5Hasher = null;
            byte[] data = null;
            StringBuilder sBuilder = null;

            try
            {


                // Create a new instance of the MD5CryptoServiceProvider object.
                md5Hasher = new System.Security.Cryptography.MD5CryptoServiceProvider();

                // Convert the input string to a byte array and compute the hash.
                data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));
                
                // Create a new Stringbuilder to collect the bytes
                // and create a string.
                sBuilder = new StringBuilder();

                // Loop through each byte of the hashed data 
                // and format each one as a hexadecimal string.
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }



            }
            catch (Exception ex)
            {
                m_logger.Error(MODULE_NAME, sMethod, "Unhanlde Exception has occured");
            }
            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        // Verify a hash against a string.
        public static bool verifyMd5Hash(string input, string hash)
        {
            string hashOfInput = getMd5Hash(input);
            //  string hashOfInput = Crypt.CryptStr(input);
            if (0 == String.Compare(hashOfInput, hash, true))
            {
                return true;
            }
            return false;
        }

        public static string convertAdminRelativePathToDriverAppPath(string xmlPath)
        {

            return xmlPath.Replace("../../../", "../../");
        }

    }
}
