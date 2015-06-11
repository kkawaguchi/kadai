using System; 
using System.IO; 

namespace Kadai
{
//⑪こちらで「AbstractDisplay」という抽象クラスを用意しました。 このクラスを継承して入力文字列を装飾するクラスを２個作成してください。 実装にあたっては以下のルールを守ってください。
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