namespace Infrastructure
{
	public static class HtmlHelpers
	{
		public static System.Web.Mvc.MvcHtmlString HiddenForDateTime<TModel, TValue>
			(this System.Web.Mvc.HtmlHelper<TModel> htmlHelper,
			System.Linq.Expressions.Expression<System.Func<TModel, TValue>> expression)
			where TModel : class
		{
			var varMetadata =
				System.Web.Mvc.ModelMetadata.FromLambdaExpression
				(expression, htmlHelper.ViewData);

			//var varMetadata =
			//	System.Web.Http.Metadata.ModelMetadata.FromLambdaExpression
			//	(expression, htmlHelper.ViewData);

			var varValue = varMetadata.Model;

			return (htmlHelper.HiddenForDateTime(expression, varValue));
		}

		public static System.Web.Mvc.MvcHtmlString HiddenForDateTime<TModel, TValue>
			(this System.Web.Mvc.HtmlHelper<TModel> htmlHelper,
			System.Linq.Expressions.Expression<System.Func<TModel, TValue>> expression, object value)
			where TModel : class
		{
			string strHtmlFieldName =
				System.Web.Mvc.ExpressionHelper.GetExpressionText(expression);

			string strFullName =
				htmlHelper.ViewContext.ViewData.TemplateInfo
				.GetFullHtmlFieldName(strHtmlFieldName);

			var strTag =
				new System.Web.Mvc.TagBuilder("input");

			strTag.GenerateId(strFullName);

			strTag.Attributes.Add("type", "hidden");
			strTag.Attributes.Add("name", strFullName);

			string strValue = string.Empty;

			if (value != null)
			{
				System.DateTime dtmValue =
					(System.DateTime)value;

				strValue = dtmValue.ToString("yyyy/MM/dd HH:mm:ss");
			}

			strTag.Attributes.Add("value", strValue);

			return (new System.Web.Mvc.MvcHtmlString(strTag.ToString()));
		}

		public static System.Web.IHtmlString DtxTimeDifference
			(this System.Web.Mvc.HtmlHelper helper, System.DateTime dateTime)
		{
			string strResult = string.Empty;

			System.DateTime dtmNow = System.DateTime.Now;

			if (dtmNow <= dateTime)
			{
				return (helper.Raw(string.Empty));
			}

			System.TimeSpan dtmDifference =
				dtmNow - dateTime;

			if (dtmDifference < new System.TimeSpan(0, 1, 0))
			{
				strResult =
					string.Format("{0} ثانيه قبل", dtmDifference.Seconds);

				return (helper.Raw(strResult));
			}

			if (dtmDifference < new System.TimeSpan(1, 0, 0))
			{
				strResult =
					string.Format("{0} دقيقه قبل", dtmDifference.Minutes);

				return (helper.Raw(strResult));
			}

			if (dtmDifference < new System.TimeSpan(1, 0, 0, 0))
			{
				strResult =
					string.Format("{0} ساعت و {1} دقيقه قبل", dtmDifference.Hours, dtmDifference.Minutes);

				return (helper.Raw(strResult));
			}

			if (dtmDifference < new System.TimeSpan(2, 0, 0, 0))
			{
				strResult = "ديروز";

				return (helper.Raw(strResult));
			}

			if (dtmDifference < new System.TimeSpan(7, 0, 0, 0))
			{
				switch (dateTime.DayOfWeek)
				{
					case System.DayOfWeek.Saturday:
					{
						strResult = "شنبه";
						break;
					}

					case System.DayOfWeek.Sunday:
					{
						strResult = "يکشنبه";
						break;
					}

					case System.DayOfWeek.Monday:
					{
						strResult = "دوشنبه";
						break;
					}

					case System.DayOfWeek.Tuesday:
					{
						strResult = "سه شنبه";
						break;
					}

					case System.DayOfWeek.Wednesday:
					{
						strResult = "چهارشنبه";
						break;
					}

					case System.DayOfWeek.Thursday:
					{
						strResult = "پنجشنبه";
						break;
					}

					case System.DayOfWeek.Friday:
					{
						strResult = "جمعه";
						break;
					}
				}

				return (helper.Raw(strResult));
			}

			System.Globalization.PersianCalendar oPersianCalendar =
				new System.Globalization.PersianCalendar();

			int intMonth = oPersianCalendar.GetMonth(dateTime);
			int intDay = oPersianCalendar.GetDayOfMonth(dateTime);

			string strMonth = string.Empty;

			switch (intMonth)
			{
				case 1:
				{
					strMonth = "فروردين";
					break;
				}

				case 2:
				{
					strMonth = "ارديبهشت";
					break;
				}

				case 3:
				{
					strMonth = "خرداد";
					break;
				}

				case 4:
				{
					strMonth = "تير";
					break;
				}

				case 5:
				{
					strMonth = "مرداد";
					break;
				}

				case 6:
				{
					strMonth = "شهريور";
					break;
				}

				case 7:
				{
					strMonth = "مهر";
					break;
				}

				case 8:
				{
					strMonth = "آبان";
					break;
				}

				case 9:
				{
					strMonth = "آذر";
					break;
				}

				case 10:
				{
					strMonth = "دی";
					break;
				}

				case 11:
				{
					strMonth = "بهمن";
					break;
				}

				case 12:
				{
					strMonth = "اسفند";
					break;
				}
			}

			strResult =
				string.Format("{0} {1}", intDay, strMonth);

			return (helper.Raw(strResult));
		}
	}
}