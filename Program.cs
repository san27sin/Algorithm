using System;

namespace algorithm_hm_1
{
    class Program
    {
        /// <summary>
        /// Класс для проверки работы функции "Простое число"
        /// </summary>
        public class TestCaseForSimpleNumber
        {
            //диапазон
            private int passedNumber;
            private string expectedAnswer;
            
            public int PassedNumber
            {
                get
                {
                    return passedNumber;
                }
                set
                {
                    if(value<0)
                    {
                        passedNumber = 0;
                        return;
                    }
                    if(value>101)
                    {
                        passedNumber = 101;
                        return;
                    }
                    passedNumber = value;
                }
            }

            public string ExpectedAnswer
            {
                get
                {
                    return expectedAnswer;
                }
                set
                {
                    expectedAnswer = value;
                }
            }

        }

        /// <summary>
        /// Проверочный метод для простого числа
        /// </summary>
        /// <param name="testCase1"></param>
        static public void TestSimpleNumber(TestCaseForSimpleNumber testCase1)
        {
            if(CheckNumber(testCase1.PassedNumber, 0, 2)==testCase1.ExpectedAnswer)
            {
                Console.WriteLine("correct");                
            }
            else
            {
                Console.WriteLine("incorrect");
            }
        }


        /// <summary>
        /// решение с рекурсией
        /// </summary>
        /// <param name="number">выбранное число</param>
        /// <param name="d">заложенное число в коде</param>
        /// <param name="i">заложенное число в коде</param>
        /// <returns></returns>
        static public string CheckNumber(int number, int d, int i)
        {
            
            if(i < number)
            {
                if (number % i == 0)
                    d++;
                i++;
                
                return CheckNumber(number, d, i);
            }
            else
            {
                if(d==0)
                {
                    return "простое";
                }
                else
                {
                    return "не простое";
                }
            }      
        }


        /// <summary>
        /// Проверочный класс для фибоначи
        /// </summary>
        public class TestCaseForFib
        {
            private int passedNumber;
            private int expectedNumber;

            public int PassedNumber
            {
                get { return passedNumber;  }
                set { passedNumber = value;  }
            }

            public int ExpectedNumber
            {
                get { return expectedNumber; }
                set { expectedNumber = value; }
            }
        }

        /// <summary>
        /// Проверочный метод
        /// </summary>
        /// <param name="test">Вставляем проверочный тест</param>
        public static void TestFib(TestCaseForFib test)
        {
            string fibCycle = FibCycle(test.PassedNumber) == test.ExpectedNumber ? "correct" : "incorrect";
            string fibRec = FibRecursion(test.PassedNumber) == test.ExpectedNumber ? "correct" : "incorrect";
            Console.WriteLine($"Методы: \"Фибоначи через цикл\": {fibCycle}\t\"Фибоначи через рекурсию\": {fibRec}\t ");
        }


        /// <summary>
        /// Поиск числа фибоначи через рекурсию
        /// </summary>
        /// <param name="n">Ввод номера числа</param>
        /// <returns></returns>
        static public int FibRecursion(int n)
        {
            if (n == 0 || n == 1)
                return n;

            return FibRecursion(n - 1) + FibRecursion(n - 2);
        }


        /// <summary>
        /// Поиск числа фибоначи через цикл
        /// </summary>
        /// <param name="n">Ввод номера числа</param>
        /// <returns></returns>
        static public int FibCycle(int n)
        {
            if (n == 0)
                return 0;
            if (n == 1|| n==2)
                return 1;

            int fb1 = 1, fb2 = 1, fbSum = 0, count = 0;

            while(count++<n-2)
            {
                fbSum = fb1 + fb2;
                fb1 = fb2;
                fb2 = fbSum;
            }
            return fbSum;
        }


        public static void Task1()
        {
            //Задание 1
            //================================================================================
            
            //3 положительных
            TestCaseForSimpleNumber[] testCasePositive = new TestCaseForSimpleNumber[]
            {
                new TestCaseForSimpleNumber()
                {
                    PassedNumber = 10,
                ExpectedAnswer = "не простое"
                },

                new TestCaseForSimpleNumber()
                {
                    PassedNumber = 11,
                ExpectedAnswer = "простое"
                },

                new TestCaseForSimpleNumber()
                {
                    PassedNumber = 12,
                ExpectedAnswer = "не простое"
                }
            };

            Console.WriteLine("3 положительных теста:");
            foreach(var test in testCasePositive)
            {
                TestSimpleNumber(test);
            }

            //2 отрицательных
            TestCaseForSimpleNumber[] testCaseNegative = new TestCaseForSimpleNumber[]
            {
                new TestCaseForSimpleNumber()
                {
                    PassedNumber = 10,
                ExpectedAnswer = "простое"
                },

                new TestCaseForSimpleNumber()
                {
                    PassedNumber = 3,
                ExpectedAnswer = "не простое"
                },
            };

            Console.WriteLine("\n2 отрицательных теста:");
            foreach (var test in testCaseNegative)
            {
                TestSimpleNumber(test);
            }

            //================================================================================
        }

        public static void Task2()
        {

            //Задание 2
            //================================================================================
            Console.WriteLine("Асимптотическая сложность O(N^3)");
            //================================================================================
        }

        public static void Task3()
        {
            //Задание 3

            //3 положительных теста
            Console.WriteLine("3 положительных теста");
            TestCaseForFib[] positiveTest = new TestCaseForFib[]
            {
                new TestCaseForFib()
                {
                    PassedNumber = 6,
                    ExpectedNumber = 8
                },
                new TestCaseForFib()
                {
                    PassedNumber = 8,
                    ExpectedNumber = 21
                },

                new TestCaseForFib()
                {
                    PassedNumber = 10,
                    ExpectedNumber = 55
                }
            };

            foreach(var test in positiveTest)
            {
                TestFib(test);
            }

            //2 отрицательных теста
            TestCaseForFib[] negativeTest = new TestCaseForFib[]
            {
                new TestCaseForFib()
                {
                    PassedNumber = 8,
                    ExpectedNumber = 4
                },
                new TestCaseForFib()
                {
                    PassedNumber = 4,
                    ExpectedNumber = 1
                }                
            };


            Console.WriteLine("2 отрицательных теста");
            foreach (var test in negativeTest)
            {
                TestFib(test);
            }
            //================================================================================
        }



        static void Main(string[] args)
        {
            

            string task = null;
            string answer = null;
            do
            {
                Console.WriteLine("Выберите задачу:");
                for (int i = 1; i <= 3; i++)
                {
                    Console.WriteLine($"Task №{i}");
                }

                task = Console.ReadLine();


                if (int.TryParse(task, out int numberOfTask))
                {
                    switch (numberOfTask)
                    {
                        case 1:
                            Console.WriteLine();
                            Task1();
                            break;
                        case 2:
                            Console.WriteLine();
                            Task2();
                            break;
                        case 3:
                            Console.WriteLine();
                            Task3();
                            break;
                        default:
                            Console.WriteLine("Неккоректный ввод!");
                            break;
                    }
                }

                Console.Write("Вернуться в главное меню: ");
                answer = Console.ReadLine();
                Console.WriteLine("\n\n");
            } while (answer == "yes" || answer == "да");                     

        }
    }
}
