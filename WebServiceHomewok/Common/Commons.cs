using System;
using System.Collections.Generic;
using System.Text;

namespace WebServiceHomewok.Common
{
    public class Commons
    {
        private Dictionary<string, string> headers;
        public Commons()
        {
            this.headers = new Dictionary<string, string>();
        }

        public Dictionary<string, string> Headers 
        {
            get
            {
                return AddHeaders(headers);
            }
        }

        private Dictionary<string, string> AddHeaders(Dictionary<string, string> headers)
        {
            headers.Add("G-Token", "ROM831ESV");
            headers.Add("Authorization", "Basic YWRtaW46YWRtaW4 =");
            headers.Add("Content-Type", "application/json");

            return headers;
        }
    }
}
