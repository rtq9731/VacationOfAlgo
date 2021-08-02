using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ConsoleApp1
{
    class Class1
    {

        class Soulutions
        {
            public long soulution(decimal num)
            {
                long result = 0;

                foreach (var item in num.ToString())
                {
                    result += item - '0';
                }

                return result;
            }

            public long PlusAtoB(int a, int b)
            {
                long result = 0;

                for (int i = a; i <= b; i++)
                {
                    result += i;
                }

                return result;
            }

            public string CaesarPassword(string s, int n)
            {

                if(s.Length > 8000)
                {
                    return " 에러 ! : s는 8000자 이하여야 합니다.";
                }
                else if(n < 1 || 25 < n)
                {
                    return " 에러 ! : n은 1 이상, 25 이하인 자연수여야 합니다.";
                }

                StringBuilder stringBuilder = new StringBuilder();

                foreach (var item in s)
                {
                    int result = 0;

                    if ((item >= 'A' && item <= 'Z') || (item >= 'a' && item <= 'z'))
                    {
                        result = item <= 'Z' ? ClampForCaesar('A', 'Z', item + n) : ClampForCaesar('a', 'z', item + n);
                    }
                    else if (item == ' ')
                    {
                        result = 32;
                    }
                    else
                    {
                        return " 에러 ! : s는 알파벳 소문자, 대문자, 공백으로만 이루어져 있어야 합니다.";
                    }

                    stringBuilder.Append((char)result);
                }

                return stringBuilder.ToString();
            }

           public int ClampForCaesar(int min, int max, int value)
            {
                int result = 0;

                if(value <= max && value >= min)
                {
                    result = value;

                    return result;
                }
                else if (value > max)
                {
                    result = value;
                    while(result <= max)
                    {
                        result = 'a' + (result - max);
                    }

                    return result;
                }
                else
                {
                    return min;
                }
            }

            public int StringToInt(string s)
            {
                if (s.Length < 1 || s.Length > 5)
                {
                    Console.WriteLine(" 에러 ! : s의 길이는 1 이상 5 이하입니다.");
                    return 0;
                }

                int sign = 1;
                int result = 0;

                if(s[0] == '-')
                {
                    sign = -1;
                }
                else if (s[0] == '+')
                {
                    sign = 1;
                }
                else
                {
                    sign = 1;
                }

                return result * sign;
            }

        }

        static void Main(string[] args)
        {

        }

     }
}
