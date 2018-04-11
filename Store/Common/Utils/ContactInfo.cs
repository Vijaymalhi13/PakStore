using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eLearning.Common.Utils
{
    public class ContactInfo
    {
        private String name;
        private String mobileNo;
        private String email;
        private String id;
        
        public ContactInfo( String name, String mobileNo, String email,String id )
        {
            this.name = name;
            this.mobileNo = mobileNo;
            this.email = email;
            this.id = id;
        }

        public String Name 
        {
            get
            { 
                return name;
            }
            
        }
        public String MobileNo
        {
            get
            {
                return mobileNo.Replace(" ", "").Replace("-", "");
            }

        }
        public String Email
        {
            get
            {
                return email;
            }

        }
        public String Id
        {
            get
            {
                return id;
            }

        }
    }
}
