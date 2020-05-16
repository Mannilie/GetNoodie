using UnityEngine;

namespace GetNoodie
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Flip : MonoBehaviour
    {
        #region Variables
        [SerializeField] private bool m_inverse = false;
        [HideInInspector] [SerializeField] private SpriteRenderer m_spriteRenderer;
        #endregion
        #region Properties
        public bool Inverse
        {
            get => m_inverse;
            set => m_inverse = value;
        }
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
            float x = transform.position.x;
            SpriteRenderer.flipX = Inverse ? x > 0 : x < 0;
        }
        #endregion
    }
}
