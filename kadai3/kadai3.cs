using System; 

namespace kadai3
{

	class Keisan
	{

		public static void Main()
		{
			double Anser;
            double DoubleReadA;
            double DoubleReadB;

			while(true)
			{
				while (true)
	            {
	                Console.WriteLine("��ڂ̈���");
	                Console.Write("��");
	                var StrReadA = Console.ReadLine();
	                if (double.TryParse(StrReadA, out DoubleReadA) == false)
	                {
	                	Console.WriteLine("�����ł͂���܂���");
	                }
	                else
	                {
	                	break;
	                }
		         }

	             Console.WriteLine("���Z�L��(+ - / *) ");
	             Console.Write("��");
	             var StrKigou = Console.ReadLine();

	             while (true)
	             {
	             	Console.WriteLine("��ڂ̈���");
	             	Console.Write("��");
	             	var StrReadB = Console.ReadLine();
	             	if (double.TryParse(StrReadB, out DoubleReadB) == false)
	             	{
	                 	Console.WriteLine("�����ł͂���܂���");
	             	}
	             	else
	             	{
	                 	break;
	             	}

	             }

	             switch (StrKigou)
	      		 {
	             	case "+":
	                 	Anser = DoubleReadA + DoubleReadB;
	                 	Console.WriteLine("����");
	                 	Console.WriteLine(Anser);
			             break;

	        	     case "-":
		               	Anser = DoubleReadA - DoubleReadB;
	                		Console.WriteLine("����");
	                 	Console.WriteLine(Anser);
			            break;

			         case "*":
	                 	Anser = DoubleReadA * DoubleReadB;
	                		Console.WriteLine("����");
	                 	Console.WriteLine(Anser);
	                 	break;

	             	 case "/":
	                	if (DoubleReadB == 0)
	                	{
	                		Console.WriteLine("���ꂪ0�ł�");
	                		break;
	                	}
	                	else
	                	{
	                		Anser = DoubleReadA / DoubleReadB;
	                		Console.WriteLine("����");
	                		Console.WriteLine(Anser);
	                	}
	                	break;

	             	default:
	                	Console.WriteLine("���Z�L�������������ł�");
	                	break;
	             }

	             Console.WriteLine("�I�����܂����H");
	             Console.WriteLine("1:�I���@���̑�:������");
	             var StrRead = Console.ReadLine();
	             if (StrRead == "1")
	             {
	             	Console.WriteLine("�I�����܂�");
	             	//�I������
	             	Environment.Exit(0);
	             }
	             else
	             {
	             	Console.WriteLine("�����܂�");
	             }
				}
		}
	}
}
