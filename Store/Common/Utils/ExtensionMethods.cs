using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;

namespace eLearning.Common.Utils
{
    // AVANZA\jawwad.ahmed - 10/02/2017 11:48:33
    public static class ExtensionMethods
    {
        // Added by AVANZA\jawwad.ahmed on 09/02/2018 17:38:06
        public static MemoryStream ToCSV(this DataTable dtDataTable)
        {
            MemoryStream stream = new MemoryStream();
            StreamWriter sw = new StreamWriter(stream);
            //headers  
            for (int i = 0; i < dtDataTable.Columns.Count; i++)
            {
                sw.Write(dtDataTable.Columns[i]);
                if (i < dtDataTable.Columns.Count - 1)
                {
                    sw.Write(",");
                }
            }
            sw.Write(sw.NewLine);
            foreach (DataRow dr in dtDataTable.Rows)
            {
                for (int i = 0; i < dtDataTable.Columns.Count; i++)
                {
                    if (!Convert.IsDBNull(dr[i]))
                    {
                        string value = dr[i].ToString();
                        if (value.Contains(','))
                        {
                            value = String.Format("\"{0}\"", value);
                            sw.Write(value);
                        }
                        else
                        {
                            sw.Write(dr[i].ToString());
                        }
                    }
                    if (i < dtDataTable.Columns.Count - 1)
                    {
                        sw.Write(",");
                    }
                }
                sw.Write(sw.NewLine);
            }
            sw.Close();
            return stream;
        }

        // AVANZA\jawwad.ahmed - 10/02/2017 11:48:36
        // NOTE: it will ignore the children target control at all, 
        // can be achieved by changing "else if" to "if"
        public static IEnumerable<T> FindControlsOfType<T>(this Control parent) where T : Control
        {
            foreach (Control child in parent.Controls)
            {
                if (child is T)
                {
                    yield return (T)child;
                }
                else if (child.Controls.Count > 0)
                {
                    foreach (T grandChild in child.FindControlsOfType<T>())
                    {
                        yield return grandChild;
                    }
                }
            }
        }

        public static bool IsAjaxRequest(this HttpRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }
            var context = HttpContext.Current;
            var isCallbackRequest = false;// callback requests are ajax requests
            if (context != null && context.CurrentHandler != null && context.CurrentHandler is System.Web.UI.Page)
            {
                isCallbackRequest = ((System.Web.UI.Page)context.CurrentHandler).IsCallback;
            }
            return isCallbackRequest || (request["X-Requested-With"] == "XMLHttpRequest") || (request.Headers["X-Requested-With"] == "XMLHttpRequest");
        }
    }
}
