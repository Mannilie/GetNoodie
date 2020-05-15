using UnityEngine;

namespace GetNoodie
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Flip : MonoBehaviour
    {
        #region Variables
        [SerializeField] private SpriteRenderer m_spriteRenderer;
        #endregion
        #region Properties
        public SpriteRenderer SpriteRenderer => m_spriteRenderer;
        #endregion
        #region Methods
        // Start is called before the first frame update
        private void Start()
        {
            m_spriteRenderer = GetComponent<SpriteRenderer>();
        }
        // Update is called once per frame
        private void Update()
        {
            SpriteRenderer.flipX = transform.position.x < 0;
        }
        #endregion
    }
}
