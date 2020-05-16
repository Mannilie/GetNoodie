using System;
using UnityEngine;

namespace GetNoodie
{
    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class KillBox : MonoBehaviour
    {
        [SerializeField] private BoxCollider2D m_boxCollider;
        [SerializeField] private Rigidbody2D m_rigidbody2D;

        #region Methods

        private void Awake()
        {
            m_boxCollider = GetComponent<BoxCollider2D>();
            m_rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            Destroy(other.gameObject);
        }

        #endregion
    }
}