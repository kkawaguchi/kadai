using System; 
using System.IO; 

namespace Kadai
{
//�IInput�C���^�[�t�F�[�X�̍쐬 �@�y�ю����N���XTextInput�N���X�̍쐬 �@�EInput�C���^�[�t�F�[�X�@�@���@input���\�b�h�����C���^�[�t�F�[�X �@�ETextInput�N���X�@�@�@�@�@���@input���\�b�h�Ńe�L�X�g�t�@�C�����當�������荞�ރN���X�B
	class Kadai10
	{

		public static void Main()
		{
			ConsoleOutput HelloWorld = new ConsoleOutput();
			HelloWorld.Set("Hello World");
			HelloWorld.Output();
			
			TextOutput TextHelloWorld = new TextOutput();
			TextHelloWorld.Set("Hello World");
			TextHelloWorld.Output();
			
			TextInput FileContents = new TextInput();
			FileContents.Input();
			Console.WriteLine(FileContents.GetValue());
		}
	}
	
	public interface Output
	{
		void Output();
	}
	
	class ConsoleOutput:Output
	{
		protected string value;
		
		public string GetValue()
		{
			return value;
		}
		
		public void Set(string outPutValue)
		{
			value = outPutValue;
		}
		
		public void Output()
		{
			Console.WriteLine(value);
		}
	}
	
	class TextOutput:Output
	{
		protected string value;
		
		public string GetValue()
		{
			return value;
		}
		
		public void Set(string outPutValue)
		{
			value = outPutValue;
		}
		public void Output()
		{
			File.WriteAllText("./kadai.txt",value);
		}
	}
	
	public interface Input
	{
		void Input();
	}
	
	class TextInput:Input
	{
		protected string value;
		protected string[] values;
		
		public string GetValue()
		{
			return value;
		}
		
		public void Input()
		{
			values = File.ReadAllLines("./kadai.txt");
			value = values[0];
		}
	}
	
}