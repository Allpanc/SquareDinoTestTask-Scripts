using System.Collections.Generic;

namespace SquareDinoTestTask.Way
{
    public class WayPointComparer : IComparer<WayPoint>
    {
        public int Compare(WayPoint x, WayPoint y)
        {
            return x._index.CompareTo(y._index);
        }
    }
}