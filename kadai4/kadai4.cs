using System; 

namespace Kadai4
{
//�C�R�}���h���C�������̒l�𔻒肵�ďo�͂�ύX����v���O�����̍쐬(if��, switch���̗������ړI)
	class Switch
	{

		public static void Main(string[] args)
		{
			double valueA;
			if(double.TryParse(args[0],out valueA))
			{
				Console.WriteLine(args[0] + ":�R�}���h���C�������͐����ł�");
				return;
			}
			else
			{
				Console.WriteLine(args[0] + ":�R�}���h���C�������͕�����ł�");
				return;
			}
		}
	}
	
}