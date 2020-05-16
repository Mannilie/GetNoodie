using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

namespace GetNoodie
{
    [RequireComponent(typeof(SceneLoader))]
    public class Game : MonoBehaviour
    {
        #region Definition
        [Serializable]
        public class Wave
        {
            public int level = 1;
            public int count = 10;
            public Vector2 obstacleRate = new Vector2(0.5f, 1.5f);
            public Vector2 powerupRate = new Vector2(0.5f, 1.5f);
            public float globalSpeed = 1f;
        }
        #endregion
        #region Variables
        private static Game m_instance;
        [SerializeField] private bool m_paused = false;
        [SerializeField] private float m_globalSpeed = 1f;
        [SerializeField] private float m_globalTimer = 0f;
        [SerializeField] private int m_totalScore = 0;
        [SerializeField] private float m_wallSpacing = 2f;
        [SerializeField] private Transform m_leftWall = null;
        [SerializeField] private Transform m_rightWall = null;
        [SerializeField] private UnityEvent m_onGameOver = new UnityEvent();
        [SerializeField] private Spawner m_obstacles;
        [SerializeField] private Spawner m_powerups;
        [SerializeField] private Wave m_currentWave = null;
        [SerializeField] private float m_powerupTimer = 0f;
        #endregion
        #region Properties
        public static Wave CurrentWave => Instance.m_currentWave;
        public static Game Instance
        {
            get
            {
                if (m_instance == null)
                    m_instance = FindObjectOfType<Game>();
                return m_instance;
            }
        }
        public static bool IsPaused
        {
            get => Instance.m_paused;
            set => Instance.m_paused = value;
        }
        public static float WallSpacing
        {
            get => Instance.m_wallSpacing;
            set
            {
                Instance.m_leftWall.position = new Vector3(-value, 0f);
                Instance.m_rightWall.position = new Vector3(value, 0f);
                Instance.m_wallSpacing = value;
            }
        }
        public static float GlobalSpeed
        {
            get
            {
                if (Instance == null)
                    return 1;
                return Instance.m_globalSpeed;
            }
            set => Instance.m_globalSpeed = value;
        }

        public static float GlobalTimer
        {
            get => Instance.m_globalTimer;
            set => Instance.m_globalTimer = value;
        }
        public static int TotalScore
        {
            get => Instance.m_totalScore;
            set => Instance.m_totalScore = value;
        }
        public static UnityEvent OnGameOver => Instance.m_onGameOver;
        #endregion
        #region Methods
        public void Start()
        {
            StartNextWave();
        }
        private void Update()
        {
            if (IsPaused)
                return;
            WallSpacing = m_wallSpacing;
            GlobalTimer += Time.deltaTime;
            UI.UpdateTimerText(GlobalTimer);
            // Spawn Powerups
            m_powerupTimer += Time.deltaTime;
            var powerupRate = CurrentWave.powerupRate;
            var rate = Random.Range(powerupRate.x, powerupRate.y);
            if (m_powerupTimer >= rate)
            {
                m_powerups.Spawn();
                m_powerupTimer = 0f;
            }
        }
        public void AddScore(int value)
        {
            // Add the score to total
            TotalScore += value;
            UI.UpdateScoreText(TotalScore);
        }
        public void GameOver()
        {
            IsPaused = true;
            GlobalSpeed = 0f;
            OnGameOver.Invoke();
            StopAllCoroutines();
        }
        public void Restart()
        {
            SceneLoader.Instance.Restart();
        }
        private void WaveCompleted()
        {
            StartNextWave();
        }
        public void StartNextWave()
        {
            var wave = CreateNextWave();
            StartCoroutine(SpawnWave(wave));
        }
        private Wave CreateNextWave()
        {
            var nextWave = new Wave();
            if (CurrentWave != null)
            {
                nextWave.level = CurrentWave.level + 1;
                nextWave.count = CurrentWave.count + 2;
                nextWave.obstacleRate = CurrentWave.obstacleRate + new Vector2(.1f, .1f);
                nextWave.powerupRate = CurrentWave.powerupRate + new Vector2(.1f, .1f);
                nextWave.globalSpeed = CurrentWave.globalSpeed + .05f;
            }
            GlobalSpeed = nextWave.globalSpeed;
            m_currentWave = nextWave;
            UI.UpdateWaveText(nextWave.level);
            return nextWave;
        }
        private IEnumerator SpawnWave(Wave wave)
        {
            for (var i = 0; i < wave.count; i++)
            {
                m_obstacles.Spawn();
                var obstacleRate = wave.obstacleRate;
                var rate = Random.Range(obstacleRate.x, obstacleRate.y);
                yield return new WaitForSeconds(1f / rate);
            }
            WaveCompleted();
            yield return null;
        }
        #endregion
    }
}