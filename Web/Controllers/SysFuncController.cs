using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Web.DAL;
using Web.Models;

namespace Web.Controllers
{
    public class SysFuncController : BaseController
    {
        // GET: SysFunc/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SysFunc/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SysFuncID,FuncName,FuncDesc,ParentID,IsLeaf,IsButton,URL,IsDisabled,HandlerName,OrderNum")] SysFunc sysFunc)
        {
            if (ModelState.IsValid)
            {
                db.SysFunc.Add(sysFunc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sysFunc);
        }

        // GET: SysFunc/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SysFunc sysFunc = db.SysFunc.Find(id);
            if (sysFunc == null)
            {
                return HttpNotFound();
            }
            return View(sysFunc);
        }

        // POST: SysFunc/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SysFuncID,FuncName,FuncDesc,ParentID,IsLeaf,IsButton,URL,IsDisabled,HandlerName,OrderNum")] SysFunc sysFunc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sysFunc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sysFunc);
        }

        // GET: SysFunc/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SysFunc sysFunc = db.SysFunc.Find(id);
            if (sysFunc == null)
            {
                return HttpNotFound();
            }
            return View(sysFunc);
        }

        // POST: SysFunc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            SysFunc sysFunc = db.SysFunc.Find(id);
            db.SysFunc.Remove(sysFunc);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
    }
}
