using System;
using System.Diagnostics.CodeAnalysis;

namespace GreedyMethod
{
    class _1_KnapsackProblem
    {
        public double fractionalKnapsack(int W, Item[] items, int n)
        {
            double sumOfWeights = 0;
            double valueOfWeights = 0;
            Array.Sort(items);// Time complexity: O(n)
            for (int index = n - 1; index >= 0; index--)
            {
                if (sumOfWeights + items[index].Weight <= W)
                {
                    sumOfWeights += items[index].Weight;
                    valueOfWeights += items[index].Value;
                }
                else
                {
                    int leftWeight = W - (int)sumOfWeights;
                    if (items[index].Weight - leftWeight >= 0)
                    {
                        sumOfWeights += leftWeight;
                        valueOfWeights += items[index].Value * ((double)leftWeight / items[index].Weight);
                    }
                }
                if (sumOfWeights >= W)
                    break;

            }
            return valueOfWeights;
        }


    }
    class Item : IComparable<Item>
    {
        public int Value { get; set; }
        public int Weight { get; set; }
        public double ValueWeightedAverage { get; set; }

        public Item() : this(0, 0)
        {

        }
        public Item(int value, int weight)
        {
            Value = value;
            Weight = weight;
            ValueWeightedAverage = value / weight;
        }

        public int CompareTo([AllowNull] Item other)
        {
            if (this.ValueWeightedAverage > other.ValueWeightedAverage)
                return 1;
            else if (this.ValueWeightedAverage < other.ValueWeightedAverage)
                return -1;
            else
                return 0;
        }
    }

}
