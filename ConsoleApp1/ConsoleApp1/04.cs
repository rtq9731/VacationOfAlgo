using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ConsoleApp1
{
    public class Soulutions
    {
        StringBuilder stringBuilder = new StringBuilder();

        public int FindPrimeNumCount(int n)
        {
            int result = 0;

            for (int i = 0; i < n; i++)
            {

                if (isPrimeNum(n))
                {
                    result++;
                }

            }

            return result;
        }

        private bool isPrimeNum(int n)
        {
            // 0 과 1로 나눠지는 상황은 빼고 생각하기 위해 2부터 시작. -> 0으로는 나눌수 없고, 어차피 1로는 나눠진다.
            // 숫자 자체는 자신으로 나눠진다고 생각하여, 다른 수로 나눴을 때, 0이 아니라면 소수다.
            // 만약 1 / 2보다 숫자가 크다면, 절대로 나머지가 0 일 수 없음. ex ) 32 의 1 / 2 보다 큰 17 ~ 31 은 32를 나눴을 때 절대로 나머지가 0 이지 않음. 
            // 때문에 1 / 2 보다 큰 숫자는 아예 계산하지 않음
            for (int i = 2; i <= n / 2; i++) 
            {

                if (n % i == 0)
                {
                    return false;
                }

            }

            return true; // 조건문에서 빠져나왔다면 소수
        }

        public bool isRightString(string s)
        {

            if (int.TryParse(s, out int value))
            {

                if (s.Length == 6 || s.Length == 4)
                {
                    return true;
                }

            }

            return false;
        }

        public string middleString(string s)
        {
            stringBuilder.Clear();

            stringBuilder.Append(s[s.Length / 2]);

            if (s.Length % 2 == 0)
            {
                stringBuilder.Append(s[s.Length / 2]);
            }

            return stringBuilder.ToString();
        }

        public string SortString(string s)
        {
            for (int i = 0; i < s.Length; i++)
            {

                if((s[i] < 'a' || s[i] > 'z') && (s[i] < 'A' || s[i] > 'Z'))
                {
                    return " 에러 ! : 영문 대소문자로만 구성되어 있어야 합니다.";
                }

            }

            stringBuilder.Clear();

            List<char> temp = s.ToList();
            temp.Sort((x, y) => 
            {
                if (x >= 'a' && y <= 'Z')
                {
                    return -1;
                }

                return x > y ? 1 : -1;
            });

            for (int i = 0; i < temp.Count; i++)
            {
                stringBuilder.Append(temp[i]);
            }

            return stringBuilder.ToString();
        }

        public List<string> SortStringByMe(List<String> strings, int n)
        {
            strings.Sort((x, y) => x[n] > y[n] ? 1 : -1);
            return strings;
        }

    }

    class Class1z
    {
        static void Main(string[] args)
        {
            Soulutions soulutions = new Soulutions();

            Console.WriteLine(soulutions.FindPrimeNumCount(13));

            Console.WriteLine(soulutions.isRightString("a234"));

            Console.WriteLine(soulutions.middleString("Hello"));

            Console.WriteLine(soulutions.SortString("World"));

            List<string> strings = new List<string>();
            strings.Add("HAWAII");
            strings.Add("Apple");
            strings.Add("EBS");
            strings.Add("Cappsule");

            foreach (var item in soulutions.SortStringByMe(strings, 1))
            {
                Console.WriteLine(item);
            } 
            
        }
    }
}
