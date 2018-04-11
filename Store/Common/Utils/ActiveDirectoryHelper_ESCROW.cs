using System;
using System.Collections.Generic;
using System.Text;
using System.DirectoryServices;
using System.Data;

namespace Escrow.Common.Utils
{
    /// <summary>
    /// The class provides usefull utility methods to interact with Active Directory
    /// </summary>
    public class ActiveDirectoryHelper
    {
        private static readonly String PROTOCOL_LDAP = "LDAP";

        private static readonly String PROTOCOL_POST_SYMBOL = "://";


        /// <summary>
        /// This method authenticates an Active Directory user
        /// </summary>
        /// <param name="p_UserName"></param>
        /// <param name="p_Password"></param>
        /// <param name="p_Domain"></param>
        /// <returns></returns>
        public bool Authenticate(String p_UserName, String p_Password, String p_Domain)
        {
            bool isAuthentic = false;

            try
            {
                DirectoryEntry entry = new DirectoryEntry(PROTOCOL_LDAP + PROTOCOL_POST_SYMBOL + p_Domain, p_UserName, p_Password);

                object nativeObject = entry.NativeObject;

                //user is authentic if there is no exception and code reaches here.
                isAuthentic = true;
            }
            catch (DirectoryServicesCOMException)
            {
                //this exception means that user is not authentic.
                // isAuthentic = false;
            }
            return isAuthentic;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_Domain"></param>
        /// <param name="p_UserTip"></param>
        /// <param name="p_propertiesToLoad"></param>
        /// <returns></returns>
        public DirectoryEntry GetUserByAccountName(String p_Domain, String p_SamAccountName, String[] p_propertiesToLoad)
        {
            try
            {
                DirectoryEntry adEntry = new DirectoryEntry(PROTOCOL_LDAP + PROTOCOL_POST_SYMBOL + p_Domain);

                DirectorySearcher searcher = new DirectorySearcher(adEntry);
                searcher.SearchScope = SearchScope.Subtree;
                searcher.ReferralChasing = ReferralChasingOption.All;

                foreach (String propertyToLoad in p_propertiesToLoad)
                {
                    searcher.PropertiesToLoad.Add(propertyToLoad);
                }

                searcher.Filter = "(&(objectCategory=person)(|(cn=" + p_SamAccountName + ")(sAMAccountName=" + p_SamAccountName + ")))";

                SearchResult sr = searcher.FindOne();

                return sr.GetDirectoryEntry();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_Domain"></param>
        /// <param name="p_UserTip"></param>
        /// <param name="p_propertiesToLoad"></param>
        /// <returns></returns>
        public SearchResultCollection FindUsers(String p_Domain, String p_UserTip, String[] p_propertiesToLoad)
        {
            try
            {
                DirectoryEntry adEntry = new DirectoryEntry(PROTOCOL_LDAP + PROTOCOL_POST_SYMBOL + p_Domain);

                DirectorySearcher searcher = new DirectorySearcher(adEntry);
                searcher.SearchScope = SearchScope.Subtree;
                searcher.ReferralChasing = ReferralChasingOption.All;
                searcher.PageSize = 10;
                //searcher.SizeLimit = 5;

                foreach (String propertyToLoad in p_propertiesToLoad)
                {
                    searcher.PropertiesToLoad.Add(propertyToLoad);
                }
                // "(&(anr=" & txtSearch.Text & ")(objectCategory=person)
                //searcher.Filter = "(&(objectCategory=person)(!(userAccountControl:1.2.840.113556.1.4.803:=2)))";

                if (p_UserTip != null && p_UserTip.Length > 0)
                {
                    searcher.Filter = "(&(anr=" + p_UserTip + ")(objectCategory=person)(!(userAccountControl:1.2.840.113556.1.4.803:=2)))";
                    searcher.Filter = String.Format("(anr= {0})", p_UserTip);
                }
                else
                    searcher.Filter = "(&(objectCategory=person)(objectclass=user)(!(userAccountControl:1.2.840.113556.1.4.803:=2)))";


                SearchResultCollection resultsCol = searcher.FindAll();

                foreach (SearchResult result in resultsCol)
                { Console.WriteLine(result.Path); }

                return resultsCol;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_dataTable"></param>
        /// <param name="p_adSearchResultCollection"></param>
        /// <param name="p_dataColumns"></param>
        /// <returns></returns>
        private String[] SetColumnsForDataTable(DataTable p_dataTable, SearchResultCollection p_adSearchResultCollection,
            String[] p_dataColumns)
        {
            String[] columnList = null;

            if (p_dataColumns == null || p_dataColumns.Length <= 0)
            {
                columnList = p_adSearchResultCollection.PropertiesLoaded;
            }
            else
            {
                columnList = p_dataColumns;
            }

            foreach (String columnName in columnList)
            {
                p_dataTable.Columns.Add(columnName);
            }
            return columnList;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_adSearchResultCollection"></param>
        /// <param name="p_propertiesToLoad"></param>
        /// <returns></returns>
        public DataTable GetDataTable(SearchResultCollection p_adSearchResultCollection, String[] p_propertiesToLoad)
        {
            DataTable dataTable = new DataTable("ActiveDirectoryUser");

            String[] columnList =
                this.SetColumnsForDataTable(dataTable, p_adSearchResultCollection, p_propertiesToLoad);

            if (p_adSearchResultCollection != null && p_adSearchResultCollection.Count == 0)
            {
                return dataTable;
            }


            foreach (SearchResult adSearchResult in p_adSearchResultCollection)
            {
                DirectoryEntry adEntry = adSearchResult.GetDirectoryEntry();

                DataRow row = dataTable.NewRow();

                for (int i = 0; i < columnList.Length; i++)
                {
                    String propertyName = columnList[i];
                    row[propertyName] = ((PropertyValueCollection)adEntry.Properties[propertyName]).Value;
                }

                dataTable.Rows.Add(row);

                //if (dataTable.Rows.Count == 100)
                //    break;
            }

            return dataTable;
        }

        // Added by AVANZA\jawwad.ahmed on 12/04/2017 09:54:12
        public bool IsUserExist(string domainName, string userLoginId)
        {

            String[] propertiesToLoad = new String[] {
            "displayName",
            "givenName",
            "email",
            "sn",
            "samaccountname",
            "mail",
            "userPrincipalName",
            "anr"};

            SearchResultCollection src = this.FindUsers(domainName, userLoginId, propertiesToLoad);
            return src.Count > 0;
        }

    }//ActiveDirectoryHelper

}
