using System;
using System.Web;

namespace nothinbutdotnetstore.web.core
{
    public class RawHttpHandler : IHttpHandler
    {
        IProcessRequests front_controller;

        public RawHttpHandler(IProcessRequests front_controller)
        {
            this.front_controller = front_controller;
        }

        public void ProcessRequest(HttpContext context)
        {
            throw new NotImplementedException();
        }

        public bool IsReusable
        {
            get { throw new System.NotImplementedException(); }
        }
    }
}