using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections;

namespace Algo_Extension
{
    public class Solutions
    {
        public List<Boxer> Solution1(short[] weights, char[][] head2head)
        {
            List<Boxer> boxers = new List<Boxer>();

            for (uint i = 0; i < weights.Length; i++)
            {

                uint curWins = 0;
                uint curWinWeightUpCount = 0;
                uint curMatchCount = 0;

                for (int j = 0; j < head2head[i].Length; j++)
                {
                    switch (head2head[i][j])
                    {
                        case 'W':

                            if (weights[i] < weights[j])
                            {
                                curWinWeightUpCount++;
                            }

                            curWins++;
                            break;

                        default:
                            break;
                    }

                    curMatchCount++;
                }

                boxers.Add(new Boxer(curMatchCount, weights[i], curWins, curWinWeightUpCount, i));
            }

            boxers.Sort();

            return boxers;
        }

        public class Boxer : IComparable
        {
            private uint number;
            public uint Number { get { return number; } }

            private uint matchCount = 0;
            public uint MatchCount { get { return matchCount; } }

            private short weight = 0;
            public short Weight { get { return weight; } }

            private uint wins = 0;
            public uint Wins { get { return wins; } }

            private uint winWeightUpBoxer = 0;
            public uint WinWeightUpBoxer { get { return winWeightUpBoxer; } }

            public Boxer(uint matchCount, short weight, uint wins, uint winWeightUpBoxer, uint number)
            {
                this.matchCount = matchCount;
                this.weight = weight;
                this.wins = wins;
                this.winWeightUpBoxer = winWeightUpBoxer;
                this.number = number;
            }

            public int CompareTo(object obj)
            {
                Boxer boxer2 = (obj as Boxer);

                int result = (wins / matchCount).CompareTo(boxer2.wins / boxer2.matchCount);

                if (result == 0)
                {
                    if (winWeightUpBoxer > boxer2.winWeightUpBoxer)
                    {
                        result = 1;
                    }
                    else if (winWeightUpBoxer < boxer2.winWeightUpBoxer)
                    {
                        result = -1;
                    }
                    else
                    {
                        if (weight > boxer2.weight)
                        {
                            result = -1;
                        }
                        else if (weight > boxer2.winWeightUpBoxer)
                        {
                            result = 1;
                        }
                        else
                        {
                            result = this.number.CompareTo(boxer2.number);
                        }
                    }
                }

                return -result;
            }
        }

        public decimal Solution2(int price, int money, int count)
        {
            return (money - (price * count)) > 0 ? 0 : -(money - (price * count));
        }

    }

    class _01
    {
        static void Main(string[] args)
        {

            Solutions solutions = new Solutions();

            float[] weights = { 45, 75, 143, 65 };

            char[][] head2head = new char[4][];

            head2head[0] = new char[] { 'N', 'W', 'W', 'W' };
            head2head[1] = new char[] { 'L', 'N', 'L', 'W' };
            head2head[2] = new char[] { 'L', 'W', 'N', 'L' };
            head2head[3] = new char[] { 'L', 'L', 'W', 'N' };

            foreach (var item in solutions.Solution1(weights, head2head))
            {
                Console.WriteLine(item.Wins + " " + item.Weight);
            }

            Console.WriteLine(solutions.Solution2(250, 100, 4) + "원이 부족합니다.");
        }

    }
}
