using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Singleton instance1 = Singleton.GetInstance();
            Singleton instance2 = Singleton.GetInstance();

            if (instance1 == instance2)
            {
                Console.WriteLine("同じインスタンスです。");
            }
            else
            {
                Console.WriteLine("別のインスタンスです。");
            }
        }

        public class Singleton
        {
            private static Singleton singleton = new Singleton();

            private  Singleton()
            {
                Console.WriteLine("コンストラクタを呼び出しました。");
            }

            public static Singleton GetInstance()
            {
                return singleton;
            }
        }
    }
}
