using System; 

namespace Kadai
{
//�FOutput(�@�\�͇A�Ɠ��l)�N���X�̍쐬�ƁA������Ăяo���v���O�����̍쐬(�N���X�̗������ړI)
	class Kadai7
	{

		public static void Main()
		{
			Output HelloWorld = new Output();
			HelloWorld.SetValue("Hello World");
			HelloWorld.OutPutValuse();
		}
	}
	
	class Output
	{
		private string value;
		
		public string GetValue()
		{
			return value;
		}
		
		public void SetValue(string outPutValue)
		{
			value = outPutValue;
		}
		
		public void OutPutValuse()
		{
			Console.WriteLine(value);
		}
	}
}