using System;
using UnityEngine;

namespace GetNoodie
{
    [Serializable]
    public class Prototype
    {
        #region Variables
        [SerializeField] private GameObject m_prefab;
        [SerializeField] private Vector3 m_position = Vector3.zero;
        [SerializeField] private Vector3 m_scale = Vector3.one;
        [SerializeField] private Vector3 m_euler = Vector3.zero;
        #endregion
        #region Properties
        public GameObject Prefab
        {
            get => m_prefab;
            set => m_prefab = value;
        }
        public Vector3 Position
        {
            get => m_position;
            set => m_position = value;
        }
        public Vector3 Scale
        {
            get => m_scale;
            set => m_scale = value;
        }
        public Vector3 Euler
        {
            get => m_euler;
            set => m_euler = value;
        }
        #endregion
    }
}