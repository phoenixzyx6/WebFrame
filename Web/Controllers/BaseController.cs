using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Lib.Web.Mvc.JQuery.JqGrid;
using log4net;
using Web.DAL;
using Web.Models;

namespace Web.Controllers
{
    public class BaseController: Controller
    {
        protected ILog log;
        protected ERPDAL db;
        // GET: Base
        public BaseController() {
            if (db == null)
            {
                this.db = new ERPDAL();
            }
            log = LogManager.GetLogger(this.GetType().FullName);
        }
        

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        
    }
}