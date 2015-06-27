using System; 

namespace Kadai
{
//�J�����_�[�쐬

	class Kadai14
	{
		//�����̓��́A�N���X�̍쐬
		public static void Main()
		{
			//�N�����󂯎��
			Console.WriteLine("�N�ƌ�����͂��Ă�������(��F2015,7)");
			string readYearMonth = Console.ReadLine();
			//calendar�N���X�ɔN����n���Ĉ���̗j���Ɠ������擾
			Calendar calendar = new Calendar();
			if (calendar.CheckValue(readYearMonth))
			{
				calendar.SetYoubi();
				calendar.SetNisu();
				//OutPutCalendar�N���X�Ɉ���̗j���Ɠ�����n���ďo��
				OutPutCalendar outPutcalendar = new OutPutCalendar(calendar);
				outPutcalendar.OutPut();
			}
			else
			{
				return;
			}
		}
		
	}
	//�N,���������̗j���ƍŌ�̓���Ԃ�
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
			//�`�F�b�N����month��year���Z�b�g����
			
			if (monthYear.IndexOf(",") == -1)
			{
				Console.WriteLine("���͂̃t�H�[�}�b�g�����������ł�(�u,�v������܂���)");
				checkFlg = false;
			}
			else
			{
				string[] listMonthYear  = monthYear.Split(',');
				if(listMonthYear.Length != 2)
				{
					Console.WriteLine("���͂̃t�H�[�}�b�g�����������ł�(�u,�v�̐������������ł�)");
					checkFlg = false;
				}
				else
				{
					getYear = listMonthYear[0];
					getMonth = listMonthYear[1];
					if(!int.TryParse(getYear,out year))
					{
						Console.WriteLine("�N�������ł͂���܂���");
						checkFlg = false;
					}
					else
					{
						if(year < 1 || year > 9999)
						{
							Console.WriteLine("�N��1�`9999�ł͂���܂���");
							checkFlg = false;
						}
					}
					if(!int.TryParse(getMonth,out month))
					{
						Console.WriteLine("���������ł͂���܂���");
						checkFlg = false;
					}
					else
					{
						if(month < 1 || month > 12)
						{
							Console.WriteLine("����1�`12�ł͂���܂���");
							checkFlg = false;
						}
					}
				}
			}
		return checkFlg;
		}
		
		//����̗j�����o��
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
		//�������o��
		public void SetNisu()
		{
			nisu = DateTime.DaysInMonth(year, month);
		}
	}
	//�o��
	class OutPutCalendar
	{
		Calendar calendar;
		//�R���X�g���N�^
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
			Console.WriteLine("���@���@�΁@���@�؁@���@�y");
			for(int i=0; i<42;i++)
			{
				if((i+1)%7==0)
				{
					Console.WriteLine(outDate[i]);
				}
				else
				{
					Console.Write(outDate[i]);
					Console.Write("�@");
				}
			}
		}
	}
}
