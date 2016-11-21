namespace MVC121.Helpers.Utilities
{
    public static class MailMessage
    {
        //کدهای مربوط به بدنه رایانامه
        #region MailBody_ConvertTextForBodyEmail(string text)

        //ایجاد یک رشته که قالب رایانامه را شبیه سازی میکند
        public static string ConvertTextForBodyEmail(string text)
        {
            text = text.Replace(System.Convert.ToChar(10).ToString(), ""); // Return Key.
            text = text.Replace(System.Convert.ToChar(13).ToString(), "<br />"); // Return Key.
            text = text.Replace(System.Convert.ToChar(9).ToString(), "&nbsp;&nbsp;&nbsp;&nbsp;"); // TAB Key.

            return (text);
        }

        #endregion ConvertTextForBodyEmail(string text)

        //متد های مربوط به ارسال رایانامه و تنظیمات میل مسیج و اس ام تی پی
        #region SendMailMethods_MailMessage&SmtpConfiguration()

        /// <summary>
        /// متد ارسال که موضوع و بدنه دارد
        /// </summary>
        /// <param name="subject">موضوع</param>
        /// <param name="body">بدنه</param>
        public static void Send
            (
                string subject,
                string body
            )
        {
            Send
                (
                    null,
                    null,
                    subject,
                    body,
                    System.Net.Mail.MailPriority.High,
                    null,
                    System.Net.Mail.DeliveryNotificationOptions.Never
                );
        }



        /// <summary>
        /// متد ارسال که چهار پارامتر دارد
        /// در 99 درصد از ارسال رایانامه به این شکل میباشد
        /// </summary>
        /// <param name="recipient">دريافت کننده</param>
        /// <param name="subject">موضوع</param>
        /// <param name="body">بدنه</param>
        /// <param name="priority">اهميت</param>
        public static void Send
            (
                System.Net.Mail.MailAddress recipient,
                string subject,
                string body,
                System.Net.Mail.MailPriority priority
            )
        {
            System.Net.Mail.MailAddressCollection oRecipients =
                new System.Net.Mail.MailAddressCollection();

            oRecipients.Add(recipient);

            Send(null, oRecipients, subject, body, priority, null, System.Net.Mail.DeliveryNotificationOptions.Never);
        }

        /// <summary>
        /// متد ارسال با شش پارامتر
        /// کاملترین مدل ارسال
        /// </summary>
        /// <param name="sender">ارسال کننده</param>
        /// <param name="recipients">دريافت کنندگان</param>
        /// <param name="subject">موضوع</param>
        /// <param name="body">بدنه</param>
        /// <param name="priority">اهميت</param>
        /// <param name="deliveryNotification">رسيد ارسال</param>
        public static void Send
    (
        System.Net.Mail.MailAddress sender,
        System.Net.Mail.MailAddressCollection recipients,
        string subject,
        string body,
        System.Net.Mail.MailPriority priority,
        System.Net.Mail.AttachmentCollection attachments,
        System.Net.Mail.DeliveryNotificationOptions deliveryNotification
    )
        {
            //ایجاد سه شی از میل آدرس - اس ام تی پی و میل مسیج
            System.Net.Mail.MailAddress oSender = null; ;
            System.Net.Mail.SmtpClient oSmtpClient = null;
            System.Net.Mail.MailMessage oMailMessage = null;

            try
            {
                // #################################################
                // ### Mail Message Configuration ##################
                // #################################################

                // قدم اول نیو کردن شی میل مسیج
                oMailMessage = new System.Net.Mail.MailMessage();

                //اگر پارامتر ورودی سندر نال نبود
                if (sender != null)
                {
                    //پارامتر دوم برابر با شی ایجاد شده از میل آدرس میشود
                    oSender = sender;
                }
                //در غیر اینصورت
                else
                {
                    //ایجاد دو رشته از نیم اسپیس وب اپلیکیشن و کلاس اپلیکیشن ادیت و متد گت ولیو
                    string strAddress = MVC121.Helpers.Utilities.ApplicationEdit.GetValue("NoReplyAddress");
                    string strDisplayName = MVC121.Helpers.Utilities.ApplicationEdit.GetValue("NoReplyDisplayName");

                    //اگر رشته دیسپلی نیم نال یا امپتی بود
                    if (string.IsNullOrEmpty(strDisplayName))
                    {
                        //شی میل آدرس را با  دو رشته اس تی آر آدرس نیو میکنیم
                        oSender =
                            new System.Net.Mail.MailAddress(strAddress, strAddress, System.Text.Encoding.UTF8);
                    }
                    //در غیر اینصورت
                    else
                    {
                        //شی میل آدرس را با  یک رشته اس تی آرآدرس  و یک رشته دیسپلی نیم نیو میکنیم
                        oSender =
                            new System.Net.Mail.MailAddress(strAddress, strDisplayName, System.Text.Encoding.UTF8);
                    }
                }

                //قسمت های فرام - سندر - و ریپلای تو را برابر با شی میل آدرس او سندر قرار میدهیم
                //وقتی از یک آدرس در این سه پراپرتی و دو جای دیگر در وب کانفیگ استفاده میکنیم احتمال در اسپم نرفتن بیشتر است
                oMailMessage.From = oSender;
                oMailMessage.Sender = oSender;
                oMailMessage.ReplyTo = oSender;

                //پراپرتی های ذیل از جنس کالکشن هستند
                //جهت اطمینان ابتدا آنها را کلیر میکنیم
                oMailMessage.To.Clear();
                oMailMessage.CC.Clear();
                oMailMessage.Bcc.Clear();
                oMailMessage.Attachments.Clear();

                //اگر پارامتر ورودی از میل آدرس نال بود
                if (recipients == null)
                {
                    //شی ساخته شده از میل آدرس را برابر نال قرار میدهیم
                    System.Net.Mail.MailAddress oMailAddress = null;
                    //ایجاد دو رشته از نیم اسپیس وب اپلیکیشن و کلاس اپلیکیشن ادیت و متد گت ولیو
                    string strAddress = MVC121.Helpers.Utilities.ApplicationEdit.GetValue("SupportAddress");
                    string strDisplayName = MVC121.Helpers.Utilities.ApplicationEdit.GetValue("SupportDisplayName");

                    //اگر رشته دیسپلی نیم نال یا امپتی بود
                    if (string.IsNullOrEmpty(strDisplayName))
                    {
                        oMailAddress =
                            new System.Net.Mail.MailAddress(strAddress, strAddress, System.Text.Encoding.UTF8);
                    }
                    //در غیر اینصورت
                    else
                    {
                        //شی میل آدرس را با  یک رشته اس تی آرآدرس  و یک رشته دیسپلی نیم نیو میکنیم
                        oMailAddress =
                            new System.Net.Mail.MailAddress(strAddress, strDisplayName, System.Text.Encoding.UTF8);
                    }

                    //پراپرتی تو شی میل مسیج را برابر با شی میل آدرس قرار میدهیم
                    oMailMessage.To.Add(oMailAddress);
                }
                else
                {
                    //اگر پارامتر ورودی میل آدرس نال نبود
                    // Note: Wrong Usage!
                    // oMailMessage.To = recipients;

                    //به ازای تمامی آدرس های موجود در پارامتر ورودی با استفاده از پراپرتی تو میل  به مسیج اد میکنیم
                    foreach (System.Net.Mail.MailAddress oMailAddress in recipients)
                    {
                        oMailMessage.To.Add(oMailAddress);
                    }
                }

                //ایجاد یک رشته از نیم اسپیس وب اپلیکیشن و کلاس اپلیکیشن ادیت و متد گت ولیو
                string strBccAddresses = MVC121.Helpers.Utilities.ApplicationEdit.GetValue("BccAddresses");

                //اگر  استرینگ بی سی سی نال بود
                if (string.IsNullOrEmpty(strBccAddresses))
                {
                    //پراپرتی بی سی سی را به شی میل مسیج اد میکنیم
                    oMailMessage.Bcc.Add("Chabok.121@gmail.com");
                }
                //در غیراینصورت
                else
                {
                    //استرینگ بی سی سی را به میل مسیج اد میکنیم
                    oMailMessage.Bcc.Add(strBccAddresses);
                }

                //بدنه رایانامه را مشخص میکنیم
                oMailMessage.Body = body;

                //ایجاد یک رشته از نیم اسپیس وب اپلیکیشن و کلاس اپلیکیشن ادیت و متد گت ولیو
                string strEmailSubjectPrefix = MVC121.Helpers.Utilities.ApplicationEdit.GetValue("EmailSubjectPrefix");
                //اگر رشته بالا نال بود
                if (string.IsNullOrEmpty(strEmailSubjectPrefix))
                {
                    //عنوان ورودی را به میل مسیج میدهیم به عنوان سابجکت
                    oMailMessage.Subject = subject;
                }
                else
                {
                    //در غیر اینصورت ابتدا پرفیکس و بعد عنوان را میدهیم
                    oMailMessage.Subject = strEmailSubjectPrefix + " " + subject;
                }

                //فعال شدن کد های اچ تی ام ال در متن
                oMailMessage.IsBodyHtml = true;
                //اولویت ارسال را با پارامتر ورودی مشخص میکنیم
                oMailMessage.Priority = priority;
                //بدنه را انکدینگ میکنیم
                oMailMessage.BodyEncoding = System.Text.Encoding.UTF8;
                //عنوان را انکدینگ میکنیم
                oMailMessage.SubjectEncoding = System.Text.Encoding.UTF8;
                //نحوه مطلع شدن سرور رایانامه از ارسال رایانامه را با پارامتر ورودی مشخص میکنیم
                oMailMessage.DeliveryNotificationOptions = deliveryNotification;

                //اگر رایانامه پیوستی داشت
                if (attachments != null)
                {
                    // Note: Wrong Usage!
                    // oMailMessage.Attachments = attachments;
                    //پیوست ها را به این شکل به میل مسیج اد میکنیم
                    foreach (System.Net.Mail.Attachment oAttachment in attachments)
                    {
                        oMailMessage.Attachments.Add(oAttachment);
                    }
                }

                //هدر رایانامه را مشخص میکنیم
                oMailMessage.Headers.Add("TOLOOCO_Mailer_Version", "1.2.1");
                oMailMessage.Headers.Add("TOLOOCO_Mailer_Date", "2015/12/12");
                oMailMessage.Headers.Add("TOLOOCO_Mailer_Author", "Amir Chabok");
                oMailMessage.Headers.Add("TOLOOCO_Mailer_Company", "www.TOLOOCO.com");

                // ###################################################
                // ###  /Mail Message Configuration ##################
                // ###################################################


                // ###################################################
                // ###  SMTP Message Configuration ###################
                // ###################################################
                //ایجاد یک شی از اس ام تی پی
                oSmtpClient = new System.Net.Mail.SmtpClient();

                //کلا تو این گت ولیو ها دیفالت ولیو آخرین مقدار هست
                //بررسی امضا الکترونیکی رایانامه و مقدار دهی آن توسط متد گت ولیو
                if (MVC121.Helpers.Utilities.ApplicationEdit.GetValue("SmtpClientEnableSsl", "0") == "1")
                {
                    oSmtpClient.EnableSsl = true;
                }
                else
                {
                    oSmtpClient.EnableSsl = false;
                }

                //مدت زمان برقراری اتصال برای ارسال رایانامه پیش فرض 100 ثانیه است
                oSmtpClient.Timeout =
                    System.Convert.ToInt32(MVC121.Helpers.Utilities.ApplicationEdit.GetValue("SmtpClientTimeout", "100000"));

                // ###################################################
                // ### /SMTP Message Configuration ###################
                // ###################################################

                //ارسال نهایی رایانامه
                oSmtpClient.Send(oMailMessage);
            }
            //درصورت بروز خطا آنرا لاگ میکنیم
            catch (System.Exception ex)
            {
                System.Collections.Hashtable oHashtable =
                    new System.Collections.Hashtable();

                if (oSender != null)
                {
                    oHashtable.Add("Address", oSender.Address);
                    oHashtable.Add("DisplayName", oSender.DisplayName);
                }

                oHashtable.Add("Subject", subject);
                oHashtable.Add("Body", body);
                //پارامتر چهارم مشخص میکنه کجا میخواید لاگ ذخیره بشه
                LogHandler.Report(typeof(MailMessage), oHashtable, ex, LogHandler.LogTypes.LogToFile);

                string strErrorMessage = System.Web.HttpContext.GetGlobalResourceObject("Library", "ErrorOnSendingEmail").ToString();

            }
            //شی میل مسیج و اس ام تی پی را خاتمه میدهیم
            finally
            {
                if (oMailMessage != null)
                {
                    oMailMessage.Dispose();
                    oMailMessage = null;
                }

                if (oSmtpClient != null)
                {
                    oSmtpClient = null;
                }
            }
        }

        #endregion SendMailMethods_MailMessage&SmtpConfiguration()
    }
}