using System;

namespace sletat.ru
{
    public static class Config
    {
        private static Lazy<I> instance =
          new Lazy<I>(() =>
          {
              var instance = new B();
              return instance;
          });
        public static I Instance => instance.Value;
    }
}
