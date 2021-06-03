using System;

namespace GreedyMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            //ActivitySelectionProblem();

            //Item[] items = new Item[] {
            //    new Item(60,10),
            //    new Item(100,20),
            //    new Item(120,30) };
            //var knapsackProblem = new _1_KnapsackProblem();
            //var maxValue = knapsackProblem.fractionalKnapsack(50, items, 3);
            //Console.WriteLine($"Max Value: {maxValue}");
            JobSequencingProblem();

        }

        public static void JobSequencingProblem()
        {
            var job1 = new Job(1, 2, 100);
            var job2 = new Job(2, 1, 19);
            var job3 = new Job(3, 2, 27);
            var job4 = new Job(4, 1, 25);
            var job5 = new Job(4, 3, 15);
            var jobs = new Job[] { job1, job2, job3, job4, job5 };
            var jobSequencing = new _2_JobSequencingProblem();
            jobSequencing.SequenceOfJobs(jobs);
        }

        public static void ActivitySelectionProblem()
        {
            int n = 6;
            int[] S = { 1, 3, 0, 5, 8, 5 };
            int[] F = { 2, 4, 6, 7, 9, 9 };
            var activitySelection = new _3_ActivitySelectionProblem();
            activitySelection.SelectActivity(S, F, 6);
        }
    }


}
