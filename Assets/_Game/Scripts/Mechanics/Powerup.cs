using UnityEngine;

namespace GetNoodie
{
    public class Powerup : MonoBehaviour
    {
        public int value = 1;
        public int Collect()
        {
            Destroy(gameObject);
            return value;
        }
    }
}