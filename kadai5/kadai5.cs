using System; 
//1�`100�܂ŏo�͂���v���O�����̍쐬(while��, for���̗������ړI) �@ 
namespace Kadai5
{

	class ForBun
	{

		public static void Main()
		{
			for (int i = 1; i <= 100;i++ )
			{
				if (i % 10 == 0)
				{
					Console.WriteLine(i);
				}
				else 
				{
					Console.Write(i + ",");
				}
				
			}
		}
	}

}
