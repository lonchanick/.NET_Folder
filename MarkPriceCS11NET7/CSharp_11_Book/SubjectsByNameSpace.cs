namespace SubjectsByNameSpace
{
    namespace SetAndGetMethods
    {
        public class ClassForTest
        {
            private string? _privateField;
            public string? privateField
            {
                get { return _privateField; }
                set
                {
                    Console.Write("Making Some security cheking");
                    Thread.Sleep(200);
                    Console.Write(".");
                    Thread.Sleep(200);
                    Console.Write(".");
                    Thread.Sleep(200);
                    Console.Write(".");
                    Thread.Sleep(200);
                    Console.Write(".");
                    if (value is null)
                        throw new Exception($"Null values not allowed");
                    if (value.Length > 10)
                        throw new Exception($"Wrong string size");
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Well Done, the size of the string is right!");
                        Console.WriteLine($">>{nameof(_privateField)} = {value};");
                        _privateField = value;
                    }

                }
            }
        }
    }

    namespace sizeOfVariableTypes
    {
        public class exe
        {
            public static void VariableTypeSize()
            {
                WriteLine(new string('-', 100));
                WriteLine("{0,-10}{1,-25}{2,15}{3,30}", "Type", "Byte(s) in memory", "Min", "Max");
                WriteLine("{0,-10}{1,1}{2,39}{3,30}", "long",sizeof(long), long.MinValue, long.MaxValue);
                WriteLine("{0,-10}{1,1}{2,39}{3,30}", "byte",sizeof(byte), byte.MinValue, byte.MaxValue);
                WriteLine("{0,-10}{1,1}{2,39}{3,30}", "ushort", sizeof(ushort), ushort.MinValue, ushort.MaxValue);
                WriteLine("{0,-10}{1,1}{2,39}{3,30}", "short", sizeof(short), short.MinValue, short.MaxValue);
                WriteLine("{0,-10}{1,1}{2,39}{3,30}", "int", sizeof(int), int.MinValue, int.MaxValue);
                WriteLine("{0,-10}{1,1}{2,39}{3,30}", "uint", sizeof(uint), uint.MinValue, uint.MaxValue);
                WriteLine("{0,-10}{1,1}{2,39}{3,30}", "long", sizeof(long), long.MinValue, long.MaxValue);
                WriteLine("{0,-10}{1,1}{2,39}{3,30}", "ulong", sizeof(ulong), ulong.MinValue, ulong.MaxValue);
                WriteLine("{0,-10}{1,1}{2,39}{3,30}", "float", sizeof(float), float.MinValue, float.MaxValue);
                WriteLine("{0,-10}{1,1}{2,39}{3,30}", "double", sizeof(double), double.MinValue, double.MaxValue);
                WriteLine("{0,-10}{1,1}{2,39}{3,30}", "decimal", sizeof(decimal), decimal.MinValue, decimal.MaxValue);
                WriteLine(new string('-', 100));
                WriteLine(System.Half.MaxValue);

            }
        }

    }

    namespace Arrays
    {
        class Arrays
        {
            public static void jaggedArray()
            {
                //jagged array (matriz irregular)
                //here the difference is that the size of the different array can vary
                string[][] arr = new[]
                {
                    new [] {"Hola","mundo","Como estas","?"},
                    new [] {"Aqui","Son","Tres"},
                    new [] {"Aca","Solo","dos"},
                };

                int upperBound;
                WriteLine("UpperBound of array is ", upperBound = arr.GetUpperBound(0));


                for (int b = 0; b <= upperBound; b++)
                {
                    WriteLine("Sub-Array #1 upperBound is: {0}", arr[b].GetUpperBound(0));
                }

                WriteLine("\t Array Content:");

                for (int y = 0; y <= arr.GetUpperBound(0); y++)
                {
                    for (int x = 0; x <= arr[y].GetUpperBound(0); x++)
                    {
                        WriteLine(arr[y][x]);
                    }
                    WriteLine(">>>>>>>>>");
                }
            }
            public static void BidimencionalArray()
            {
                //bidimencional Array
                //string[,] arr = new string[2,7] ;
                string[,] arr = new[,]
                {
                    {"1","2","3","4","5","6","7","8","9","0" },
                    {"A","B","C","D","E","F","G","H","I","J" }
                };
                WriteLine($"Upperbound: {arr.GetUpperBound(0)} - Lowerbound: {arr.GetLowerBound(0)}");
                WriteLine($"Upperbound: {arr.GetUpperBound(1)} - Lowerbound: {arr.GetLowerBound(1)}");

                for (int y = 0; y <= arr.GetUpperBound(0); y++)
                {
                    for (int x = 0; x <= arr.GetUpperBound(1); x++)
                    {
                        WriteLine($"WriteLine(arr[{y},{x}]); >> {0}", arr[y, x]);
                    }
                }
            }
            public static void PatternMatching()
            {
                int[] sequentialNumbers = new int[] {1,2,3,4,5,6,7,8,9,10};
                int[] oneTwoNumbers = new int[] { 1, 2 };
                int[] oneTwoTenNumbers = new int[] {1,2,10 };
                int[] oneTwoThreeTenNumbers = new int[] {1,2,3,10};
                int[] primeNumbers = new int[] {2,3,5,7,11,13,17,19,23,29 };
                int[] fibonacciNumbers = new int[] { 0,1,1,2,3,5,8,13,21,34,55};
                int[] emptyNumbers = new int[] { };
                int[] threeNumbers = new[] { 1, 2, 3 };
                int[] sixNumber = new[] { 1, 31, 2, 54, 1, 55 };

                WriteLine($"{nameof(sequentialNumbers)} >> {caseSwitch(sequentialNumbers)} ");
                WriteLine($"{nameof(oneTwoNumbers)} >> {caseSwitch(oneTwoNumbers)} ");
                WriteLine($"{nameof(oneTwoTenNumbers)} >> {caseSwitch(oneTwoTenNumbers)} ");
                WriteLine($"{nameof(oneTwoThreeTenNumbers)} >> {caseSwitch(oneTwoThreeTenNumbers)} ");
                WriteLine($"{nameof(primeNumbers)} >> {caseSwitch(primeNumbers)} ");
                WriteLine($"{nameof(fibonacciNumbers)} >> {caseSwitch(fibonacciNumbers)} ");
                WriteLine($"{nameof(emptyNumbers)} >> {caseSwitch(emptyNumbers)} ");
                WriteLine($"{nameof(threeNumbers)} >> {caseSwitch(threeNumbers)} ");
                WriteLine($"{nameof(sixNumber)} >> {caseSwitch(sixNumber)} ");


                static string caseSwitch(int[] arr)
                => arr switch
                {
                    [] => "Empty Array",
                    [1, 2, _, 10] => "Contains 1,2 any single number, 10.",
                    [1, 2, .., 10] => "Contains 1,2 any range of numbers and 10",
                    [1, 2] => "Contains 1 then 2",
                    [int item1, int item2, int item3] => $"Contains {item1} and {item2} and {item3}",
                    [0,_] => "Contains a 0 then any number (included an empty one [I guess])",
                    [0,..] => "Include a 0 and any range of numbers",
                    [2, .. int[] others] => $"Contains 2 then {others.Length} more numbers",
                    [..] => "Contains any items in any order"
                };

            }
        }
    }

    namespace TryCatch
    {
        public class tryCatch
        {
            public static void exe()
            {
                /*WriteLine("What's your age?");
                var x = ReadLine()!;
                try
                {
                    *//*if(int.TryParse(x, out int age))
                    {
                        Write("Your age is {0}", age);
                    }*//*
                    var r = int.Parse(x);
                    Write("Your age is {0}", r);
                }
                catch (OverflowException)
                {
                    Write("Input either too long or to small");
                }
                catch (FormatException)
                {
                    Write("Wrong format");
                }
                catch (Exception ex)
                {
                    Write($"{ex.GetType()} <says> {ex.Message}");
                }*/

                WriteLine("Enter an amount of money!");
                string aux = ReadLine()!;
                if (string.IsNullOrEmpty(aux)) return;
                try
                {
                    decimal amount = decimal.Parse(aux);
                    WriteLine($"This is the amount formated as money {amount:C}");
                }
                catch (FormatException) when (aux.Contains('$'))
                {
                    WriteLine("Error: Dollar sign founded");
                }
                catch (FormatException) 
                {
                    WriteLine("Format error");
                }

            }
        }
    }


}
