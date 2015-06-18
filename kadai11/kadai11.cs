using System; 
using System.IO; 

namespace Kadai
{
//�J������ŁuAbstractDisplay�v�Ƃ������ۃN���X��p�ӂ��܂����B ���̃N���X���p�����ē��͕�����𑕏�����N���X���Q�쐬���Ă��������B �����ɂ������Ă͈ȉ��̃��[��������Ă��������B
	class Kadai11
	{
		public static void Main()
		{
			OutClass1 class1 = new OutClass1("Hellow,orld!");
			class1.Display();
			
			OutClass2 class2 = new OutClass2("Hellow,orld!");
			class2.Display();
		}
	}
	
	public abstract class AbstractDisplay
	{
		public abstract void Open(); 
		public abstract void Print(); 
		public abstract void Close(); 
		public  void Display()
		{
			Open(); 
			for (int i = 0; i < 5; i++)
			{ 
				Print(); 
			} 
			Close(); 
		}
	}
	
	class OutClass1 : AbstractDisplay
	{
		protected string inputValue;
		
		public override void Open()
		{
			Console.WriteLine("+-------------+");
		}
		
		public override void Close()
		{
			Console.WriteLine("+-------------+");
		}
		
		public override void Print()
		{
			Console.WriteLine("|" + inputValue + "|");
		}
		
		public OutClass1(string value)
		{
			inputValue = value;
		}
	}
	
	class OutClass2 : AbstractDisplay
	{
		protected string inputValue;
		
		public override void Open()
		{
			Console.WriteLine("***************");
		}
		
		public override void Close()
		{
			Console.WriteLine("***************");
		}
		
		public override void Print()
		{
			Console.WriteLine("*" + inputValue + "*");
		}
		
		public OutClass2(string value)
		{
			inputValue = value;
		}
	}
}