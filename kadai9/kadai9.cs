using System; 
using System.IO; 

namespace Kadai
{
//�HOutput�N���X�̃C���^�[�t�F�[�X�ւ̕ύX�A �@�������������TextOutput�AConsoleOutput�N���X�̍쐬(���ۉ��A�|�����t�B�Y���̗������ړI) �@�EOutput �C���^�[�t�F�[�X�@���@output���\�b�h�����C���^�[�t�F�[�X �@�ETestOutput �N���X�@�@�@�@���@�e�L�X�g�t�@�C���ɏo�͂���N���X �@�EConsoleOutput�N���X�@�@�@���@�R���\�[��(���)�ɏo�͂���N���X
	class Kadai9
	{

		public static void Main()
		{
			ConsoleOutput HelloWorld = new ConsoleOutput();
			HelloWorld.Set("Hello World");
			HelloWorld.Output();
			
			TextOutput TextHelloWorld = new TextOutput();
			TextHelloWorld.Set("Hello World");
			TextHelloWorld.Output();
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
}