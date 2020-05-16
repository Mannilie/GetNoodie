using UnityEngine;

namespace GetNoodie
{
    public static class Utility
    {
        public static int LoopIndex(int current, int min, int max)
        {
            if (current < min)
                current = max;
            if (current > max)
                current = min;
            return current;
        }
        public static bool Approximately(Vector3 a, Vector3 b)
        {
            var x = Mathf.Approximately(a.x, b.x);
            var y = Mathf.Approximately(a.y, b.y);
            var z = Mathf.Approximately(a.z, b.z);
            if (x && z && y)
                return true;
            return false;
        }
    }
}