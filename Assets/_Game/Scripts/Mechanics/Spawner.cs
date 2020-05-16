using System.Collections.Generic;
using UnityEngine;

namespace GetNoodie
{
    public class Spawner : MonoBehaviour
    {
        #region Variables
        [SerializeField] private float m_minSpawnRate = 1f;
        [SerializeField] private float m_maxSpawnRate = 2f;
        [SerializeField] private List<GameObject> m_prefabs = new List<GameObject>(); // Object to Spawn
        [SerializeField] private List<Transform> m_spawnPoints = new List<Transform>();
        private float m_spawnTimer;
        private float m_spawnRate;
        #endregion
        #region Methods
        public void Start()
        {
            m_spawnRate = GetRandomSpawnRate();
        }
        public void Update()
        {
            if (Game.IsPaused)
                return;
            m_spawnTimer += Time.deltaTime;
            if (m_spawnTimer >= m_spawnRate)
            {
                Spawn();
                m_spawnRate = GetRandomSpawnRate();
                m_spawnTimer = 0f;
            }
        }
        public void Spawn()
        {
            var prefab = GetRandomPrefab();
            var point = GetRandomPoint();
            Instantiate(prefab, point.position, point.rotation, transform);
        }
        public float GetRandomSpawnRate()
        {
            return Random.Range(m_minSpawnRate, m_maxSpawnRate);
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
