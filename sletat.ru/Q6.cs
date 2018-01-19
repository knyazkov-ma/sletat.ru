using System;

namespace sletat.ru
{
    public class UshastijDog
    {
        //если уже есть метод, то не получится
        //public void BeHappy()
        //{ }
    }

    public static class UshastijDogExtension
    {
        public static void BeHappy(this UshastijDog d)
        {
            Console.WriteLine("Happiness");
        }
    }
}
