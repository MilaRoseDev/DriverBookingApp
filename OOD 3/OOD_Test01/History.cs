using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOD_Test01
{
    class History
    {
        private DateTime serviceDate;
        private string serviceType;
        private string comments;

        public History(DateTime newServiceDate, string newServiceType, string newServiceComments) 
        {
            this.serviceDate = newServiceDate;
            this.serviceType = newServiceType;
            this.comments = newServiceComments;
        }

        public string getComment()
        {
            return this.comments;
        }

    }
}
