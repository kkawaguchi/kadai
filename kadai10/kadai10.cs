using System; 
using System.IO; 

namespace Kadai
{
//�IInput�C���^�[�t�F�[�X�̍쐬 �@�y�ю����N���XTextInput�N���X�̍쐬 �@�EInput�C���^�[�t�F�[�X�@�@���@input���\�b�h�����C���^�[�t�F�[�X �@
//�ETextInput�N���X�@�@�@�@�@���@input���\�b�h�Ńe�L�X�g�t�@�C�����當�������荞�ރN���X�B

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
