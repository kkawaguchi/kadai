using System; 
using System.IO; 

namespace Kadai
{
	//⑫入出力機能をもつクラスを作成してください。

	//以下のメソッドを実装していること
	
	// ①テキストファイルの内容を読み込み、 引数に指定されたパスが示すクラス内のフィールドに格納するメソッド public void input(String path);

	// ②クラスのフィールドに格納された内容を、 引数に指定されたパスが示すテキストファイルに出力するメソッド public void output(String path);

	class Kadai12
	{
		public static void Main()
		{
			InputOutput kadai12 = new InputOutput();
			kadai12.Input("./test.txt");
			kadai12.Output("./test.txt");
		}
	}

	class InputOutput
	{
		protected string[] values;
		
		public void Input(string path)
		{
			if (File.Exists(path))
			{
				values = File.ReadAllLines(path);
			}
			else
			{
				Console.WriteLine("ファイルがありませんでした");
			}
		}
		
		public void Output(string path)
		{
			File.WriteAllLines(path, values);
		}
	}
}
