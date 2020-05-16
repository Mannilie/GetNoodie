using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GetNoodie
{
    public class Obstacle : MonoBehaviour
    {
        #region Variables
        [SerializeField] private int m_damage = 1;
        #endregion
        #region Properties
        public int Damage => m_damage;
        #endregion
    }
}
