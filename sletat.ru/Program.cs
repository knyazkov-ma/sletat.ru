using System;
using System.Collections.Generic;
using sletat.ru.HotelServiceReference;

namespace sletat.ru
{
    class Program
    {
        static void Main(string[] args)
        {
            //Q1
            IList<I> list = new List<I>() { new A(), new B() };
            foreach (var c in list)
            {
                c.Print1();
                Console.WriteLine();
                c.Print2();
                Console.WriteLine("--");
            }
            Console.WriteLine("------------------");

            //Q2
            string[] phones = new string[] { "+7 (921) 123-45-67", "+7 921 123-45-67", "+7 921 1234567" };
            foreach (var p in phones)
            {
                var s = p.GetClearPhone();
                Console.WriteLine(s);
            }
            Console.WriteLine("------------------");

            //Q3
            Config.Instance.Print1();
            Console.WriteLine("------------------");

            //Q4
            #region node
            Node node = new Node
            {
                Name = "1",
                Children = new List<Node>
                {
                    new Node
                    {
                        Name = "11",
                        Children = new List<Node>
                        {
                            new Node
                            {
                                Name = "111",
                                Children = new List<Node>
                                {
                                    new Node
                                    {
                                        Name = "1111",
                                        Children = new List<Node>
                                        {
                                            new Node
                                            {
                                                Name = "11111"
                                            },
                                            new Node
                                            {
                                                Name = "11112"
                                            }
                                        }
                                    }
                                }
                            },
                            new Node
                            {
                                Name = "112"
                            },
                            new Node
                            {
                                Name = "113"
                            }
                        }
                    },
                    new Node
                    {
                        Name = "12",
                        Children = new List<Node>
                        {
                            new Node
                            {
                                Name = "121"
                            },
                            new Node
                            {
                                Name = "122",
                                Children = new List<Node>
                                {
                                    new Node
                                    {
                                        Name = "1221"
                                    },
                                    new Node
                                    {
                                        Name = "1222"
                                    }
                                }
                            }
                        }
                    },
                    new Node
                    {
                        Name = "13",
                        Children = new List<Node>
                        {
                            new Node
                            {
                                Name = "131"
                            },
                            new Node
                            {
                                Name = "132",
                                Children = new List<Node>
                                {
                                    new Node
                                    {
                                        Name = "1321"
                                    },
                                    new Node
                                    {
                                        Name = "1322"
                                    }
                                }
                            }
                        }
                    }
                }
            };
            #endregion node

            var n = node.Children[0];
            Console.WriteLine(n.Name);
            Console.WriteLine("--");

            IEnumerable<Node> leafs = n.GetLeafs();
            foreach (var f in leafs)
            {
                Console.WriteLine(f.Name);
            }
            Console.WriteLine("------------------");

            //Q5
            StringInternedTest.Run();
            Console.WriteLine("------------------");

            //Q6
            UshastijDog dog = null;
            try
            {
                dog.BeHappy();
                Console.Write("I`m happy!");
            }
            catch { Console.Write("I`m sad"); }
            Console.WriteLine("------------------");

            //Q7
            IHotelService hotelServiceClient = new HotelServiceClient();
            HotelDataService srs = new HotelDataService(hotelServiceClient);
                       
            
            var task = srs.GetHotels(new int[] { 1, 2, 3, 4, 5, 6 });
            task.Wait();                         
            var hotels = task.Result;
            foreach (var h in hotels)
                Console.WriteLine(h.Name);
            Console.WriteLine("------------------");

            //Q8
            new AccountService().AddMeMoney(1000);

            //Q9
            //Deadlock
        }
    }
}
