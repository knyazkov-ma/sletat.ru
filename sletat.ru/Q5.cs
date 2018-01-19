using System;

namespace sletat.ru
{
    public class StringInternedTest
    {
        public static void Run()
        {
            string s1 = "Hello, World";
            string s2 = "Hello, World";
            Console.WriteLine("Q5: {0}", String.ReferenceEquals(s1, s2));

            string s3 = String.IsInterned(s1);
            Console.WriteLine("Q5: {0}", String.ReferenceEquals(s2, s3));

            string s4 = (string)s3.Clone();
            Console.WriteLine("Q5: {0}", String.ReferenceEquals(s3, s4));


            unsafe
            {
                fixed (char* chars = s4)
                {
                    chars[0] = 'W';
                }
            }
            Console.WriteLine(s1);
            Console.WriteLine(s2);
            Console.WriteLine(s3);
            Console.WriteLine(s4);

            Console.WriteLine("Q5: {0}", String.ReferenceEquals(s3, s4));

            var s5 = s4.Replace("d", "W");
            Console.WriteLine(s5);
            Console.WriteLine("Q5: {0}", String.ReferenceEquals(s5, s4));
        }
    }
}
