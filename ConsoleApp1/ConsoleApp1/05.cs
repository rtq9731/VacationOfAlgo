using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    public class Solutions
    {
        /// <summary>
        /// [문제 21] 두 개 뽑아서 더하기
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public int[] PlusTwoInt(int[] numbers)
        {
            List<int> result = new List<int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = i; j < numbers.Length; j++)
                {
                    if (!result.Contains(numbers[i] + numbers[j]))
                        result.Add(numbers[i] + numbers[j]);
                }
            }

            result.Sort();

            return result.ToArray();
        }

        /// <summary>
        /// [문제 22] 이상한 문자 만들기
        /// </summary>
        /// <param name = "s" ></ param >
        /// < returns ></ returns >
        public string solution1(string s)
        {
            s = s.Replace(" ", "");
            string result = "";
            for (int i = 0; i < s.Length; i++)
            {
                result += ((i % 2 == 0) ? char.ToUpper(s[i]) : char.ToLower(s[i]));
                result += ' ';
            }

            return result;
        }

        /// <summary>
        /// [문제 23] 2024년
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public string WhatIsDayofWeek(int a, int b)
        {
            return DateTime.Parse($"{a}/{b}/2024")
                .DayOfWeek
                .ToString()
                .ToUpper()
                .Substring(0, 3);
        }

        /// <summary>
        /// [문제 24] 모의고사
        /// </summary>
        /// <returns></returns>
        public string[] MockExam(int[] answers)
        {
            if (Array.Exists<int>(answers, x => x < 0 || x > 5))
            {
                return new string[] { "에러 ! : 문제의 답은 1 ~ 5번 까지입니다." };
            }

            if (answers.Length > 10000)
            {
                return new string[] { " 에러 ! : 문제는 10000번 까지만 존재할 수 있습니다!" };
            }

            List<IHateMath> studentsList = new List<IHateMath> { 
                new IHateMath("1번 수험생", new int[] { 1, 2, 3, 4, 5 }, 0), 
                new IHateMath("2번 수험생", new int[] { 2, 1, 2, 3, 2, 4, 2, 5 }, 0), 
                new IHateMath("3번 수험생", new int[] { 3, 3, 1, 1, 2, 2, 4, 4, 5, 5 }, 0) 
            };

            for (int i = 0; i < answers.Length; i++)
            {
                for (int j = 0; j < studentsList.Count; j++)
                {
                    if (answers[i] == studentsList[j].answers[i % studentsList[0].answers.Length])
                    {
                        studentsList[j].score++;
                    }
                }
            }

            studentsList.Sort((x, y) => -x.score.CompareTo(y.score));

            return studentsList[0].score != studentsList[1].score ? new string[] { studentsList[0].name }
                    : studentsList[1].score != studentsList[2].score ? new string[] { studentsList[0].name, studentsList[1].name }
                    : new string[] { studentsList[0].name, studentsList[1].name, studentsList[2].name };

        }

        class IHateMath
        {
            public string name = "";
            public int[] answers = { };
            public int score = 0;

            public IHateMath(string name, int[] answers, int score)
            {
                this.name = name;
                this.answers = answers;
                this.score = score;
            }
        }

        /// <summary>
        /// [문제 25] 체육복
        /// </summary>
        /// <param name="n"></param>
        /// <param name="lost"></param>
        /// <param name="reserve"></param>
        /// <returns></returns>
        public int PEUniform(int n, int[] lost, int[] reserve)
        {
            if (n < 2 || 30 < n)
            {
                Console.WriteLine("에러 ! : 전체 학생의 수는 2명 이상 30명 이하입니다.");
                return 0;
            }

            if (lost.Length < 1 || lost.Length > n)
            {
                Console.WriteLine("에러 ! : 체육복을 도난당한 학생의 수는 1명 이상 n명 이하입니다.");
                return 0;
            }

            if (reserve.Length < 1 || reserve.Length > n)
            {
                Console.WriteLine("여벌의 체육복을 가져온 학생의 수는 1명 이상 n명 이하입니다.");
                return 0;
            }

            List<int> reserveList = reserve.ToList<int>();
            List<int> lostList = lost.ToList<int>();

            reserveList.Sort();
            lostList.Sort();

            int result = n - lost.Length;

            for (int i = 0; i < reserve.Length; i++)
            {
                if (lost.Contains(reserve[i]))
                {
                    result++;

                    reserveList.Remove(reserve[i]);
                    lostList.Remove(reserve[i]);
                }
            }


            for (int i = 0; i < lostList.Count; i++)
            {
                if (reserveList.Contains(lostList[i] - 1))
                {
                    result++;
                    reserveList.Remove(lostList[i] - 1);
                }
                else if(reserveList.Contains(lostList[i] + 1))
                {
                    result++;
                    reserveList.Remove(lostList[i] + 1);
                }
            }

            return result;
        }

        /// <summary>
        /// [문제 26] 2021 카카오 채용연계형 인턴쉽 기출문제
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int solution2(string s)
        {
            numbers nums = numbers.zero;

            for (int i = 0; i < Enum.GetValues(typeof(numbers)).Length; i++)
            {
                s = Regex.Replace(s, nums.ToString(), ((int)nums).ToString());
                nums++;
            }

            return int.Parse(s);
        }

        private enum numbers
        {
            zero,
            one,
            two,
            three,
            four,
            five,
            six,
            seven,
            eight,
            nine
        }

    }

    class _05
    {
        static void Main(string[] args)
        {
            Solutions solutions = new Solutions();

            foreach (var item in solutions.PlusTwoInt(new int[] { 1, 3, 5, 7, 11, 13, 17, 19, 23 }))
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            Console.WriteLine(solutions.solution1("H e l l o   W o r l d !"));

            Console.WriteLine(solutions.WhatIsDayofWeek(12, 25));

            foreach (var item in solutions.MockExam(new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }))
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            Console.WriteLine(solutions.PEUniform(30, new int[] { 2, 4, 6, 8, 10, 12, 14, 16 }, new int[] { 2, 4, 5, 15 }));

            Console.WriteLine(solutions.solution2("onezerotwo4seveneight"));
        }

    }
}
