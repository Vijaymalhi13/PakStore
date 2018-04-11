using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
namespace eLearning.Common.Utils
{
    public class DashboardHTMLLoader
    {
        
        string mainDashboardHtml = string.Empty;
        string dashboardRowTemplateHtml = string.Empty;
        public DashboardHTMLLoader(string mainDashboardHtml,string dashboardRowTemplateHtml)
        {
            this.mainDashboardHtml = mainDashboardHtml;
            this.dashboardRowTemplateHtml = dashboardRowTemplateHtml;
       
        }

        public string MainDashboardHtml
        {
            get
            {
                return this.mainDashboardHtml;
            }
            
        }
        public string DashboardRowTemplateHtml
        {
            get
            {
                return this.dashboardRowTemplateHtml;
            }

        }
        public string RowWithSingleResultColumnHTML
        {
            get
            {
                return Regex.Match(dashboardRowTemplateHtml, 
                                  @"<!-- Row with single Column Result Start-->([^)]*)<!-- Row with single Column Result Finish-->").Groups[1].Value;
            }

        }

        public string RowWithMultiResultColumnHTML
        {
            get
            {
                return Regex.Match(dashboardRowTemplateHtml,
                                  @"<!--Row with multi Column Result.Start-->([^)]*)<!--Row with multi Column Result.Finish-->").Groups[1].Value;
            }

        }
        public string MultiResultColumnHeadingHTML
        {
            get
            {
                return Regex.Match(dashboardRowTemplateHtml,
                                  @"<!-- Multi Column Result Box Heading Start-->([^)]*)<!-- Multi Column Result Box Heading Finish-->").Groups[1].Value;
            }

        }

        public string MultiResultColumnValueHTML
        {
            get
            {
                return Regex.Match(dashboardRowTemplateHtml,
                                  @"<!-- Multi Column Result Box Value Start-->([^)]*)<!-- Multi Column Result Box Value Start-->").Groups[1].Value;
            }

        }
    }
}
