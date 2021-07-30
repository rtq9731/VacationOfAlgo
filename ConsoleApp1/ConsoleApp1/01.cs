using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace ConsoleApp1
{
    class BoxClass
    {
        public void MakeBox(int col, int row)
        {
            for (int i = 0; i < col; i++)
            {
                for (int j = 0; j< row; j++)
                {
                    if (j == row - 1)
                    {
                        Write("*");
                        WriteLine();
                    }
                    else if (i == 0)
                    {
                        Write("*");
                        continue;
                    }
                    else if(j == 0)
                    {
                        Write("*");
                    }
                    else if(i == col - 1)
                    {
                        Write("*");
                    }
                    else
                    {
                        Write(" ");
                    }
                }
            }
        }
    }

    class ItisMath
    {
        public string OddOrEven(int num)
        {
            return num % 2 == 0 ? "Even" : "Odd";
        }

        public int avarage(int[] arr)
        {
            int allElements = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                allElements += arr[i];
            }

            return allElements / arr.Length;
        }

        public int[] removeMinimum(int[] arr)
        {
            if(arr.Length <= 1)
            {
                int[] resultArr = { -1 };
                return resultArr;
            }

            Array.Sort(arr);
            List<int> result = new List<int>();
            for (int i = 1; i < arr.Length; i++)
            {
                result.Add(arr[i]);
            }

            return result.ToArray();
        }
    }

    class PhoneNumber
    {
        public string CensorPhoneNum(string phoneNum)
        {
            string censoredPhoneNum = "";

            for (int i = 0; i < phoneNum.Length - 4; i++)
            {
                censoredPhoneNum += "*";
            }
            for (int i = phoneNum.Length - 4; i < phoneNum.Length; i++)
            {
                censoredPhoneNum += phoneNum[i];
            }

            return censoredPhoneNum;
        }
    }

    class First
    {
        static void Main(string[] args)
        {
            int col, row;

            WriteLine("직사각형의 가로");
            row = int.Parse(ReadLine());
            WriteLine("직사각형의 세로");
            col = int.Parse(ReadLine());

            BoxClass boxMaker = new BoxClass();
            boxMaker.MakeBox(col, row);

            ItisMath math = new ItisMath();
            WriteLine("수를 입력해주세요");
            int num = int.Parse(ReadLine());
            WriteLine(math.OddOrEven(num));

            PhoneNumber phoneNumber = new PhoneNumber();
            WriteLine("전화번호를 입력해주세요");
            string phoneNum = ReadLine();
            WriteLine(phoneNumber.CensorPhoneNum(phoneNum));

            int[] arr = { 30, 6, 7, 6, 4, 5, 6, 7, 8, 9, 10 };
            WriteLine( "평균 : " + math.avarage(arr));

            arr = math.removeMinimum(arr);
            WriteLine("가장 작은 수가 제거된 배열 : ");
            for (int i = 0; i < arr.Length; i++)
            {
                Write(arr[i] + " ");
            }

        }
    }
}
