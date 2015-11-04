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
                Console.WriteLine("�����C���X�^���X�ł��B");
            }
            else
            {
                Console.WriteLine("�ʂ̃C���X�^���X�ł��B");
            }
        }

        public class Singleton
        {
            private static Singleton singleton = new Singleton();

            private  Singleton()
            {
                Console.WriteLine("�R���X�g���N�^���Ăяo���܂����B");
            }

            public static Singleton GetInstance()
            {
                return singleton;
            }
        }
    }
}
