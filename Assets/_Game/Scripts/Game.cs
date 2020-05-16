using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace GetNoodie
{
    public class Game : MonoBehaviour
    {
        #region Variables
        private static Game m_instance;
        [SerializeField] private bool m_paused = false;
        [SerializeField] private float m_globalSpeed = 1f;
        [SerializeField] private float m_globalTimer = 0f;
        [SerializeField] private int m_totalScore = 0;
        [SerializeField] private float m_wallSpacing = 2f;
        [SerializeField] private Transform m_leftWall;
        [SerializeField] private Transform m_rightWall;
        [SerializeField] private UnityEvent m_onGameOver;
        #endregion
        #region Properties
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
        public float WallSpacing
        {
            get => m_wallSpacing;
            set
            {
                m_leftWall.position = new Vector3(-value, 0f);
                m_rightWall.position = new Vector3(value, 0f);
                m_wallSpacing = value;
            }
        }
        public float GlobalSpeed
        {
            get => m_globalSpeed;
            set => m_globalSpeed = value;
        }
        public float GlobalTimer
        {
            get => m_globalTimer;
            set => m_globalTimer = value;
        }
        public int TotalScore
        {
            get => m_totalScore;
            set => m_totalScore = value;
        }
        public UnityEvent OnGameOver => m_onGameOver;
        #endregion
        #region Methods
        private void Update()
        {
            if (m_paused)
                return;
            WallSpacing = m_wallSpacing;
            GlobalTimer += Time.deltaTime;
            UI.UpdateTimerText(GlobalTimer);
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
        }
        public void Restart()
        {
            var scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.buildIndex);
        }
        #endregion
    }
}