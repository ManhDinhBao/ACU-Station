using DevExpress.XtraEditors.DXErrorProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ACUManager
{
    public class Record:IDXDataErrorInfo        
    {
        private string personName;

        public string PersonName
        {
            get { return personName; }
            set { personName = value; }
        }

        private string userId;

        public string UserId
        {
            get { return userId; }
            set { userId = value; }
        }



        public Record() { }       
        // Implements the IDXDataErrorInfo.GetPropertyError method.
        public void GetPropertyError(string propertyName, ErrorInfo info)
        {
            if (propertyName == "PersonName" && PersonName == "" ||
                propertyName == "UserId" && UserId == "")
            {
                info.ErrorText = String.Format("The '{0}' field cannot be empty", propertyName);
            }
        }
        // IDXDataErrorInfo.GetError method
        public void GetError(ErrorInfo info) { }
    }
}
