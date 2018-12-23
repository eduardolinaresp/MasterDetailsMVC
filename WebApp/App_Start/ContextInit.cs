using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.App_Start
{
    public class ContextInit
    {
        private static ServicesFactory _servicesFactory;

        public static ServicesFactory ServicesFactory
        {
            get
            {
                return _servicesFactory;
            }
        }
        public static void Init()
        {
            string connString = "Data Source=.;Initial Catalog=NadeemInvoiceDemo;Integrated Security=True;";
            _servicesFactory = new ServicesFactory(connString);
        }
    }
}