using UnityEngine;

namespace GetNoodie
{
    [RequireComponent(typeof(Collider2D))]
    public class Repeat : MonoBehaviour
    {
        public float padding = 0.01f;
        private Collider2D col; // Reference to BoxCollider Component

        private float height; // Width of the Sprite

        // Start is called before the first frame update
        private void Start()
        {
            // Get BoxCollider2D Component
            col = GetComponent<Collider2D>();
            // Store size of collider along Horizontal axis
            height = col.bounds.size.y * transform.localScale.y;
        }

        // Update is called once per frame
        private void Update()
        {
            // Get position
            var position = transform.position;
            // Is the position on the X outside the camera?
            if (position.y < -height)
            {
                // Repeat the object
                Loop();
            }
        }

        private void Loop()
        {
            // Get offset position outside the screen
            var offset = height - padding;
            // Move the position back 2 times the scale
            transform.position += new Vector3(0, offset * 2);
        }
    }
}