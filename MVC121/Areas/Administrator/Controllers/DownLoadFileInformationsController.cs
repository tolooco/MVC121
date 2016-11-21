using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC121.Areas.Administrator.Models;
using MVC121.Models;
using System.IO;
using System.Web.Hosting;
using Microsoft.AspNet.Identity;

namespace MVC121.Areas.Administrator.Controllers
{
    public class DownLoadFileInformationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //اگر قصد داشته باشیم فایل های دانلود فقط در پوشه و نه دیتابیس ذخیره گردند
        //DownloadFiles objDownload;

        public DownLoadFileInformationsController()
        {
            //اگر قصد داشته باشیم فایل های دانلود فقط در پوشه و نه دیتابیس ذخیره گردند
            //objDownload = new DownloadFiles();
        }

        // GET: Administrator/DownLoadFileInformations
        public ActionResult Index()
        {
            //اگر قصد داشته باشیم فایل های دانلود فقط در پوشه و نه دیتابیس ذخیره گردند
            //var filesCollection = obj.GetFiles();
            //return View(filesCollection);
            return View(db.DownLoadFileInformations.ToList());
        }

        // GET: Administrator/DownLoadFileInformations/Details/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Details(int? id)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(HostingEnvironment.MapPath("~/MyFiles/"));

            string strFileExtension = string.Empty;
            string strLength = string.Empty;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            DownLoadFileInformation downLoadFileInformation = db.DownLoadFileInformations.Find(id);

            foreach (var item in dirInfo.GetFiles())
            {
                if (downLoadFileInformation.FilePathName == item.Name)
                {
                    strFileExtension = item.Extension;
                    strLength = item.Length.ToString();
                }
            }

            if (downLoadFileInformation == null)
            {
                return HttpNotFound();
            }

            ViewBag.Length = strLength;
            return View(downLoadFileInformation);
        }

        // GET: Administrator/DownLoadFileInformations/Create
        [Authorize(Roles = "Administrator")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administrator/DownLoadFileInformations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult Create([Bind(Include = "FileID,FilePath,SizeFile,IsVIP,IsPaymentUser,PriceFile")] DownLoadFileInformation downLoadFileInformation, HttpPostedFileBase UploadFile)
        {
            if (ModelState.IsValid)
            {
                //میتوان از طریق این متغیر پسوند فایل را مورد بررسی قرارداد
                string strFileExtension =
                System.IO.Path.GetExtension(UploadFile.FileName).ToUpper();

                //میتوان از طریق این متغیر ماهیت فایل را مورد بررسی قرارداد
                string strContentType =
                UploadFile.ContentType.ToUpper();


                if ((UploadFile == null
                || (UploadFile.ContentLength == 0)
                || (UploadFile.ContentLength > 12000 * 1024)))

                {
                    return View("Error");
                }

                else
                {
                    downLoadFileInformation.FilePathName = UploadFile.FileName;

                    string strPath = Server.MapPath("~") + "MyFiles\\";

                    if (System.IO.Directory.Exists(strPath) == false)
                    {
                        System.IO.Directory.CreateDirectory(strPath);
                    }

                    string strPathName =
                        string.Format("{0}\\{1}", strPath, downLoadFileInformation.FilePathName);

                    UploadFile.SaveAs(strPathName);
                }

                db.DownLoadFileInformations.Add(downLoadFileInformation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(downLoadFileInformation);
        }

        // GET: Administrator/DownLoadFileInformations/Edit/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DownLoadFileInformation downLoadFileInformation = db.DownLoadFileInformations.Find(id);
            if (downLoadFileInformation == null)
            {
                return HttpNotFound();
            }
            return View(downLoadFileInformation);
        }

        // POST: Administrator/DownLoadFileInformations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit([Bind(Include = "FileID,FilePath,SizeFile,IsVIP,IsPaymentUser,PriceFile")] DownLoadFileInformation downLoadFileInformation, HttpPostedFileBase UploadFile,int id)
        {
            if (ModelState.IsValid)
            {
                if (UploadFile != null)
                {
                    downLoadFileInformation.FilePathName = UploadFile.FileName;

                    if ((UploadFile.ContentLength == 0)

                    || (UploadFile.ContentLength > 12000 * 1024)
                    || (downLoadFileInformation.FilePathName == null))

                    {
                        return View("Error");
                    }

                    else
                    {
                        string strPath = Server.MapPath("~") + "MyFiles\\";

                        if (System.IO.Directory.Exists(strPath) == false)
                        {
                            System.IO.Directory.CreateDirectory(strPath);
                        }

                        string strPathName =
                            string.Format("{0}\\{1}", strPath, downLoadFileInformation.FilePathName);

                        UploadFile.SaveAs(strPathName);
                    }

                    db.Entry(downLoadFileInformation).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    var varDFI = db.DownLoadFileInformations.Find(id);

                    string strFilePathName = varDFI.FilePathName;

                    downLoadFileInformation.FilePathName = strFilePathName;
                    db.Entry(downLoadFileInformation).State = EntityState.Added;
                    db.SaveChanges();
                }

             
                return RedirectToAction("Index");
            }
            return View(downLoadFileInformation);
        }

        // GET: Administrator/DownLoadFileInformations/Delete/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DownLoadFileInformation downLoadFileInformation = db.DownLoadFileInformations.Find(id);
            if (downLoadFileInformation == null)
            {
                return HttpNotFound();
            }
            return View(downLoadFileInformation);
        }

        // POST: Administrator/DownLoadFileInformations/Delete/5
        [Authorize(Roles = "Administrator")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DownLoadFileInformation downLoadFileInformation = db.DownLoadFileInformations.Find(id);
            db.DownLoadFileInformations.Remove(downLoadFileInformation);
            //حذف فیزیکی فایل از فولدر
            string strPath = Server.MapPath("~") + "MyFiles\\";
            System.IO.File.Delete(strPath + downLoadFileInformation.FilePathName.ToString());
            db.SaveChanges();;
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "User")]
        public ActionResult Download(int? id)
        {
            DownLoadFileInformation downLoadFileInformation = db.DownLoadFileInformations.Find(id);
            DirectoryInfo dirInfo = new DirectoryInfo(HostingEnvironment.MapPath("~/MyFiles/"));

            //VIP & PaymentUser can be one condition!

            #region VIP
            if (User.IsInRole("VIP") && downLoadFileInformation.IsVIP == true)
            {
                string strFileExtension = string.Empty;
                string strLength = string.Empty;

                foreach (var item in dirInfo.GetFiles())
                {
                    if (downLoadFileInformation.FilePathName == item.Name)
                    {
                        strFileExtension = item.Extension;
                        strLength = item.Length.ToString();
                    }
                }

                if (id == null)
                {
                    return View("Error");
                }

                int index = Convert.ToInt32(id);

                //اگر قصد داشته باشیم فایل های دانلود فقط در پوشه و نه دیتابیس ذخیره گردند
                //var filesCol = obj.GetFiles();
                //string CurrentFileName = (from hARCHI in filesCol
                //                          where hARCHI.FileId == id
                //                          select hARCHI.FilePath).First();

                string CurrentFileName = dirInfo + downLoadFileInformation.FilePathName;

                string contentType = string.Format("application/" + strFileExtension);

                return File(CurrentFileName, contentType, CurrentFileName);
            }
            #endregion VIP

            #region PaymentUser

            if (User.IsInRole("PaymentUser") && downLoadFileInformation.IsPaymentUser == true)
            {
                string strFileExtension = string.Empty;
                string strLength = string.Empty;

                foreach (var item in dirInfo.GetFiles())
                {
                    if (downLoadFileInformation.FilePathName == item.Name)
                    {
                        strFileExtension = item.Extension;
                        strLength = item.Length.ToString();
                    }
                }

                if (id == null)
                {
                    return View("Error");
                }

                int index = Convert.ToInt32(id);

                //اگر قصد داشته باشیم فایل های دانلود فقط در پوشه و نه دیتابیس ذخیره گردند
                //var filesCol = obj.GetFiles();
                //string CurrentFileName = (from hARCHI in filesCol
                //                          where hARCHI.FileId == id
                //                          select hARCHI.FilePath).First();

                string CurrentFileName = dirInfo + downLoadFileInformation.FilePathName;

                string contentType = string.Format("application/" + strFileExtension);

                return File(CurrentFileName, contentType, CurrentFileName);
            }
            #endregion PaymentUser

            #region Free

            if (downLoadFileInformation.IsPaymentUser == false && downLoadFileInformation.IsVIP == false)
            {
                string strFileExtension = string.Empty;
                string strLength = string.Empty;

                foreach (var item in dirInfo.GetFiles())
                {
                    if (downLoadFileInformation.FilePathName == item.Name)
                    {
                        strFileExtension = item.Extension;
                        strLength = item.Length.ToString();
                    }
                }

                if (id == null)
                {
                    return View("Error");
                }

                int index = Convert.ToInt32(id);

                //اگر قصد داشته باشیم فایل های دانلود فقط در پوشه و نه دیتابیس ذخیره گردند
                //var filesCol = obj.GetFiles();
                //string CurrentFileName = (from hARCHI in filesCol
                //                          where hARCHI.FileId == id
                //                          select hARCHI.FilePath).First();

                string CurrentFileName = dirInfo + downLoadFileInformation.FilePathName;

                string contentType = string.Format("application/" + strFileExtension);

                return File(CurrentFileName, contentType, CurrentFileName);
            }
            #endregion Free

            if (User.Identity.IsAuthenticated)
            {
                ViewBag.IsPaymentUser = downLoadFileInformation.IsPaymentUser;
                ViewBag.IsVIP = downLoadFileInformation.IsVIP;
                ViewBag.User=User.Identity.Name;
                ViewBag.ID = User.Identity.GetUserId();
                return View("Authorize");
            }

            ViewBag.IsPaymentUser = false;
            ViewBag.IsVIP = false;
            return View("Authorize");
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
