using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GetNoodie
{
    public class Spawner : MonoBehaviour
    {
        #region Variables
        [SerializeField] private List<Prototype> m_prototypes = new List<Prototype>();
        [SerializeField] private List<Transform> m_spawnPoints = new List<Transform>();
        #endregion
        #region Properties
        public List<Prototype> Prototypes => m_prototypes;
        public List<Transform> SpawnPoints => m_spawnPoints;
        #endregion
        #region Methods
        public GameObject Spawn()
        {
            var prototype = GetRandomPrototype();
            var prefab = prototype.Prefab;
            var euler = prototype.Euler;
            var position = prototype.Position;
            var scale = prototype.Scale;
            var rotation = Quaternion.Euler(euler);
            var point = GetRandomPoint();
            GameObject instance = Instantiate(prefab, transform);
            instance.transform.position = point.position + position;
            instance.transform.rotation *= rotation;
            instance.transform.localScale = scale;
            return instance;
        }
        public Prototype GetRandomPrototype()
        {
            var randomIndex = Random.Range(0, Prototypes.Count);
            return Prototypes[randomIndex];
        }
        public Transform GetRandomPoint()
        {
            var randomIndex = Random.Range(0, SpawnPoints.Count);
            return SpawnPoints[randomIndex];
        }
        #endregion
    }
}