using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace ConsoleApp1
{
    class Solutions
    {
        int count = 0;
        int resultCount = 0;

        /// <summary>
        /// [ 문제 06 ] 최대공약수와 최소공배수
        /// 
        /// 해결 실패
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public int[] GetUnsignedLCMAndGCD(uint a, uint b)
        {
            int[] result = { 0, 0 };

            if (a + b > 1000001)
            {
                WriteLine("에러 : 두 수는 1 이상 1000000이하의 자연수여야 합니다.");
                return result;
            }

            return result;
        }

        /// <summary>
        /// [ 문제 7 ] x만큼 간격이 있는 n개의 숫자
        /// </summary>
        /// <param name="x"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public List<int> solution(int x, int n)
        {

            List<int> result = new List<int>();

            if (x < -10000000 || 10000000 < x)
            {
                WriteLine("에러 : x는 -10000000 이상, 10000000 이하인 정수입니다.");
                return result;
            }

            if (n < 0 || n > 1000)
            {
                WriteLine("n은 1000 이하인 자연수입니다.");
                return result;
            }

            for (int i = 0; i < x * n; i += x)
            {
                result.Add(i);
            }

            return result;
        }

        /// <summary>
        /// [ 문제 08 ] 콜라츠 추측
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public int solution(int num)
        {
            if (num == 1)
            {
                resultCount = count;
                count = 0;
                return resultCount;
            }

            if (num == 0 || count > 500)
            {
                WriteLine("예외 발생 : 500 번 이하만 실행됩니다.");
                count = 0;
                return -1; 
            };

            count++;

            return num % 2 == 0 ?  solution(num / 2) :  solution(num * 3 + 1);

        }

        /// <summary>
        /// [ 문제 09 ] 정수 내림차순으로 배치하기
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public long solution(long n)
        {
            if (n < 1 || 8000000000 < n)
            {
                WriteLine("에러 : n은 1 이상 8000000000 이하인 자연수입니다.");
                return 0;
            }

            List<int> list = new List<int>();
            foreach (var item in n.ToString())
            {
                list.Add(item - '0');
            }

            list.Sort();
            list.Reverse();

            string resultString = "";

            list.ForEach(x => resultString += x.ToString());

            return long.Parse(resultString);
        }

        /// <summary>
        /// [ 문제 10 ] 자연수 뒤집어 배열로 만들기
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int[] ToReverseArray(int n)
        {
            List<int> list = new List<int>();

            foreach (var item in n.ToString().Reverse().ToArray())
            {
                list.Add(item - '0');
            }

            return list.ToArray();
        }
    }

    class Class1
    {
        static void Main(string[] args)
        {
            Solutions solutions = new Solutions();
            foreach (var item in solutions.solution(5, 10) )
            {
                Write(item.ToString() + " ");
            }

            WriteLine();

            Write(solutions.solution(30));

            WriteLine();

            long num = 4324123;
            Write(solutions.solution(num));

            WriteLine();

            foreach (var item in solutions.ToReverseArray(12345))
            {
                Write(item + " ");
            }
        }
    }
}
