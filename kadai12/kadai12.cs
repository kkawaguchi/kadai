using System; 
using System.IO; 

namespace Kadai
{
	//�K���o�͋@�\�����N���X���쐬���Ă��������B

	//�ȉ��̃��\�b�h���������Ă��邱��
	
	// �@�e�L�X�g�t�@�C���̓��e��ǂݍ��݁A �����Ɏw�肳�ꂽ�p�X�������N���X���̃t�B�[���h�Ɋi�[���郁�\�b�h public void input(String path);

	// �A�N���X�̃t�B�[���h�Ɋi�[���ꂽ���e���A �����Ɏw�肳�ꂽ�p�X�������e�L�X�g�t�@�C���ɏo�͂��郁�\�b�h public void output(String path);

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
				Console.WriteLine("�t�@�C��������܂���ł���");
			}
		}
		
		public void Output(string path)
		{
			File.WriteAllLines(path, values);
		}
	}
}
