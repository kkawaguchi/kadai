using System; 

namespace kadai3
{

    class Keisan
    {

       public static void Main()
       {
            double answer;

            Console.WriteLine("��ڂ̐�������͂��Ă�������");
            double valueA;
            string readA = Console.ReadLine();
            if(!double.TryParse(readA,out valueA))
            {
                Console.WriteLine("�����ł͂���܂���");
                return;
            }

            Console.WriteLine("���Z�q����͂��Ă�������");
            string readE = Console.ReadLine();
            if (readE != "+" && readE != "-" && readE != "*" && readE != "/" )
            {
                Console.WriteLine("���Z�q����͂��Ă�������");
                return;
            }

            Console.WriteLine("��ڂ̐�������͂��Ă�������");
            double valueB;
            string readB = Console.ReadLine();
            if (!double.TryParse(readB,out valueB))
            {
                Console.WriteLine("�����ł͂���܂���");
                return;
            }


            switch (readE)
                {
                case "+":
                    answer = valueA + valueB;
                    Console.WriteLine(answer);
                    break;

                case "-":
                    answer = valueA - valueB;
                    Console.WriteLine(answer);
                    break;

                case "*":
                    answer = valueA * valueB;
                    Console.WriteLine(answer);
                    break;

                case"/":
                    if(valueB == 0)
                    {
                        Console.WriteLine("���ꂪ0�ł�");
                        return;
                    }
                    else
                    {
                        answer = valueA / valueB;
                        Console.WriteLine(answer);
                        break;
                    }   
                }   
        }
	}
}
