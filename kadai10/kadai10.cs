using System; 
using System.IO; 

namespace Kadai
{
//⑩Inputインターフェースの作成 　及び実装クラスTextInputクラスの作成 　・Inputインターフェース　　→　inputメソッドを持つインターフェース 　
//・TextInputクラス　　　　　→　inputメソッドでテキストファイルから文字列を取り込むクラス。

	class Kadai10
	{

		public static void Main()
		{
			IInput fileContents = new TextInput();
			fileContents.Input();
			Console.WriteLine(FileContents.GetValue());
		}
	}
	
	public interface IInput
	{
		void Input();
		string GetValue();
	}
	
	class TextInput:IInput
	{
		protected string value;
		
		public string GetValue()
		{
			return value;
		}
		
		public void Input()
		{
			value = File.ReadAllText("./kadai.txt");
		}
	}
}
