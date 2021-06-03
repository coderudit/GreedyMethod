using System;
using System.Diagnostics.CodeAnalysis;

namespace GreedyMethod
{
    class _3_ActivitySelectionProblem
    {
        public void SelectActivity(int[] start, int[] end, int n)
        {
            var activities = new Activity[n];
            for (int index = 0; index < n; index++)
            {
                activities[index] = new Activity(start[index], end[index]);
            }
            Array.Sort(activities);
            int prevEndTime = activities[0].EndTime;
            int count = 1;
            for (int index = 1; index < n; index++)
            {
                var activity = activities[index];
                if (activity.StartTime >= prevEndTime)
                {
                    count++;
                    prevEndTime = activity.EndTime;
                }
            }

        }
    }

    struct Activity : IComparable<Activity>
    {
        public int StartTime { get; set; }
        public int EndTime { get; set; }
        public Activity(int startTime, int endTime)
        {
            StartTime = startTime;
            EndTime = endTime;
        }

        public int CompareTo([AllowNull] Activity other)
        {
            if (this.EndTime < other.EndTime)
                return -1;
            else if (this.EndTime > other.EndTime)
                return 1;
            else
                return 0;
        }
    }
}
