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
        [SerializeField] private Transform m_leftWall = null;
        [SerializeField] private Transform m_rightWall = null;
        [SerializeField] private UnityEvent m_onGameOver = new UnityEvent();
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
            get => Instance.m_globalSpeed;
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