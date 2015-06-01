using System; 
using System.IO; 

namespace Kadai
{
//�GOutput�N���X���p������TextOutput�N���X�̍쐬(�p���̗������ړI) �@�EOutput�N���X�@�@�@���@output���\�b�h�ŉ�ʏo�͂��s�� �@�ETextOutput�N���X�@���@output���\�b�h�Ńt�@�C���o�͂��s��
	class Kadai8
	{

		public static void Main()
		{
			Output HelloWorld = new Output();
			HelloWorld.SetValue("Hello World");
			HelloWorld.OutPut();
			
			TextOutput TextHelloWorld = new TextOutput();
			TextHelloWorld.SetValue("Hello World");
			TextHelloWorld.OutPut();
		}
	}
	
	class Output
	{
		protected string value;
		
		public string GetValue()
		{
			return value;
		}
		
		public void SetValue(string outPutValue)
		{
			value = outPutValue;
		}
		
		virtual public void OutPut()
		{
			Console.WriteLine(value);
		}
	}
	
	class TextOutput:Output
	{
		override public void OutPut()
		{
			File.WriteAllText("./kadai.txt",value);
		}
	}
}