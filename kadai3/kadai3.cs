using System; 

namespace kadai3
{

    class Keisan
    {

       public static void Main()
       {
            double answer;

            Console.WriteLine("一つ目の数字を入力してください");
            double valueA;
            string readA = Console.ReadLine();
            if(!double.TryParse(readA,out valueA))
            {
                Console.WriteLine("数字ではありません");
                return;
            }

            Console.WriteLine("演算子を入力してください");
            string readE = Console.ReadLine();
            if (readE != "+" && readE != "-" && readE != "*" && readE != "/" )
            {
                Console.WriteLine("演算子を入力してください");
                return;
            }

            Console.WriteLine("二つ目の数字を入力してください");
            double valueB;
            string readB = Console.ReadLine();
            if (!double.TryParse(readB,out valueB))
            {
                Console.WriteLine("数字ではありません");
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
                        Console.WriteLine("分母が0です");
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
