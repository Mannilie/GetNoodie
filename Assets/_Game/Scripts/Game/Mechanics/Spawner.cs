using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GetNoodie
{
    public class Spawner : MonoBehaviour
    {
        #region Variables
        [SerializeField] private List<GameObject> m_prefabs = new List<GameObject>();
        [SerializeField] private List<Transform> m_spawnPoints = new List<Transform>();
        #endregion
        #region Methods
        public void Spawn()
        {
            var prefab = GetRandomPrefab();
            var point = GetRandomPoint();
            Instantiate(prefab, point.position, point.rotation, transform);
        }
        public GameObject GetRandomPrefab()
        {
            var randomIndex = Random.Range(0, m_prefabs.Count);
            return m_prefabs[randomIndex];
        }
        public Transform GetRandomPoint()
        {
            var randomIndex = Random.Range(0, m_spawnPoints.Count);
            return m_spawnPoints[randomIndex];
        }
        #endregion
    }
}