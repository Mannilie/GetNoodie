using UnityEngine;

namespace GetNoodie
{
    public class Scroll : MonoBehaviour
    {
        public float scrollSpeed = -5f;

        // Update is called once per frame
        private void Update()
        {
            var position = transform.position;
            var speed = scrollSpeed * GameManager.Instance.GlobalSpeed;
            position.y += speed * Time.deltaTime;
            transform.position = position;
        }
    }
}