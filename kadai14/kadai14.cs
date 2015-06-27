using System; 

namespace Kadai
{
//カレンダー作成

	class Kadai14
	{
		//引数の入力、クラスの作成
		public static void Main()
		{
			//年月を受け取る
			Console.WriteLine("年と月を入力してください(例：2015,7)");
			string readYearMonth = Console.ReadLine();
			//calendarクラスに年月を渡して一日の曜日と日数を取得
			Calendar calendar = new Calendar();
			if (calendar.CheckValue(readYearMonth))
			{
				calendar.SetYoubi();
				calendar.SetNisu();
				//OutPutCalendarクラスに一日の曜日と日数を渡して出力
				OutPutCalendar outPutcalendar = new OutPutCalendar(calendar);
				outPutcalendar.OutPut();
			}
			else
			{
				return;
			}
		}
		
	}
	//年,月から一日の曜日と最後の日を返す
	class Calendar 
	{
		protected int month;
		protected int year;
		protected int nisu;
		protected int youbi;
		
		public int GetMonth()
		{
			return month;
		}
		
		public int GetYear()
		{
			return year;
		}
		
		public int GetNisu()
		{
			return nisu;
		}
		
		public int GetYoubi()
		{
			return youbi;
		}
		
		public bool CheckValue(string monthYear)
		{
			string getMonth;
			string getYear;
			bool checkFlg;
			checkFlg = true;
			//チェックしてmonthとyearをセットする
			
			if (monthYear.IndexOf(",") == -1)
			{
				Console.WriteLine("入力のフォーマットがおかしいです(「,」がありません)");
				checkFlg = false;
			}
			else
			{
				string[] listMonthYear  = monthYear.Split(',');
				if(listMonthYear.Length != 2)
				{
					Console.WriteLine("入力のフォーマットがおかしいです(「,」の数がおかしいです)");
					checkFlg = false;
				}
				else
				{
					getYear = listMonthYear[0];
					getMonth = listMonthYear[1];
					if(!int.TryParse(getYear,out year))
					{
						Console.WriteLine("年が数字ではありません");
						checkFlg = false;
					}
					else
					{
						if(year < 1 || year > 9999)
						{
							Console.WriteLine("年が1～9999ではありません");
							checkFlg = false;
						}
					}
					if(!int.TryParse(getMonth,out month))
					{
						Console.WriteLine("月が数字ではありません");
						checkFlg = false;
					}
					else
					{
						if(month < 1 || month > 12)
						{
							Console.WriteLine("月が1～12ではありません");
							checkFlg = false;
						}
					}
				}
			}
		return checkFlg;
		}
		
		//一日の曜日を出す
		public void SetYoubi()
		{
			DateTime day = new DateTime(year, month, 1, 00, 00, 00, 000);
			DayOfWeek week = day.DayOfWeek;
			switch (week)
			{
				case DayOfWeek.Sunday:
					youbi=0;
					break;
				case DayOfWeek.Monday:
					youbi=1;
					break;
				case DayOfWeek.Tuesday:
					youbi=2;
					break;
				case DayOfWeek.Wednesday:
					youbi=3;
					break;
				case DayOfWeek.Thursday:
					youbi=4;
					break;
				case DayOfWeek.Friday:
					youbi=5;
					break;
				case DayOfWeek.Saturday:
					youbi=6;
					break;
			}
		}
		//日数を出す
		public void SetNisu()
		{
			nisu = DateTime.DaysInMonth(year, month);
		}
	}
	//出力
	class OutPutCalendar
	{
		Calendar calendar;
		//コンストラクタ
		public OutPutCalendar(Calendar value)
		{
			calendar = value;
		}
		public void OutPut()
		{
			string[] outDate = new string[42];
			
			if(calendar.GetYoubi() == 0)
			{
				for(int i=0;i<calendar.GetYoubi() + 7;i++)
				{
					outDate[i] = "--";
				}
				for(int i=0;i<calendar.GetNisu();i++)
				{
					outDate[calendar.GetYoubi()+i+7] = String.Format("{0, 2}", i+1);
				}
				for(int i=0;i<(42-calendar.GetYoubi()-calendar.GetNisu()-7);i++)
				{
					outDate[calendar.GetYoubi()+calendar.GetNisu()+i+7] = "--";
				}
			}
			else
			{
				for(int i=0;i<calendar.GetYoubi();i++)
				{
					outDate[i] = "--";
				}
				for(int i=0;i<calendar.GetNisu();i++)
				{
					outDate[calendar.GetYoubi()+i] = String.Format("{0, 2}", i+1);
				}
				for(int i=0;i<(42-calendar.GetYoubi()-calendar.GetNisu());i++)
				{
					outDate[calendar.GetYoubi()+calendar.GetNisu()+i] = "--";
				}
			}
			Console.WriteLine("日　月　火　水　木　金　土");
			for(int i=0; i<42;i++)
			{
				if((i+1)%7==0)
				{
					Console.WriteLine(outDate[i]);
				}
				else
				{
					Console.Write(outDate[i]);
					Console.Write("　");
				}
			}
		}
	}
}
