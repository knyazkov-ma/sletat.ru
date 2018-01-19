using System;

namespace sletat.ru
{
    public interface I
    {
        void Print1();
        void Print2();
    }

    public class A : I
    {
        public virtual void Print1()
        {
            Console.WriteLine("A: Print1");
        }

        public virtual void Print2()
        {
            Console.WriteLine("A: Print2");
        }
    }

    public class B : A
    {
        public override void Print1()
        {
            base.Print1();
            Console.WriteLine("B: Print1");
        }

    }
}
