using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace GreedyMethod
{
    class _2_JobSequencingProblem
    {
        public void SequenceOfJobs(Job[] jobs)
        {
            // Sort Jobs in descending order on the basis
            // of their profit
            Array.Sort(jobs);
            // Find the maximum deadline among all jobs and
            // create a disjoint set data structure with
            // maxDeadline disjoint sets initially.
            int maxDeadline = FindMaxDeadline(jobs);
            DisjointSet dsu = new DisjointSet(maxDeadline);
            for (int index = 0; index < jobs.Length; index++)
            {
                // Find the maximum available free slot for
                // this job (corresponding to its deadline)
                int availableSlot = dsu.find(jobs[index].Deadline);

                // If maximum available free slot is greater
                // than 0, then free slot available
                if (availableSlot > 0)
                {
                    // This slot is taken by this job 'i'
                    // so we need to update the greatest free
                    // slot. Note that, in merge, we make
                    // first parameter as parent of second
                    // parameter.  So future queries for
                    // availableSlot will return maximum slot
                    // from set of "availableSlot - 1"
                    dsu.merge(dsu.find(availableSlot - 1),
                                       availableSlot);
                    Console.WriteLine(jobs[index].JobId + " ");
                }
            }
        }

        private static int FindMaxDeadline(Job[] jobs)
        {
            int ans = jobs[0].Deadline;
            for (int index = 0; index < jobs.Length; index++)
                ans = Math.Max(jobs[index].Deadline, ans);
            return ans;
        }
    }

    class Job : IComparable<Job>
    {
        public int JobId { get; set; }
        public int Deadline { get; set; }
        public int Profit { get; set; }

        public Job()
        {

        }
        public Job(int jobId, int deadline, int profit)
        {
            JobId = jobId;
            Deadline = deadline;
            Profit = profit;
        }

        public int CompareTo([AllowNull] Job other)
        {
            if (this.Profit > other.Profit)
                return -1;
            else if (this.Profit < other.Profit)
                return 1;
            else
                return 0;
        }
    }

    class DisjointSet
    {
        int[] parent;
        public DisjointSet(int n)
        {
            parent = new int[n + 1];
            // Every node is a parent of itself
            for (int index = 0; index < n; index++)
            {
                parent[index] = index;
            }
        }

        //Path Compression
        public int find(int s)
        {
            /* Make the parent of the nodes in the path
               from u--> parent[u] point to parent[u] */
            if (s == parent[s])
                return s;
            return parent[s] = find(parent[s]);
        }

        // Makes u as parent of v.
        public void merge(int u, int v)
        {
            //update the greatest available
            //free slot to u
            parent[v] = u;
        }
    }
}



