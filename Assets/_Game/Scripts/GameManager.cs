using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GetNoodie
{
    public class GameManager : MonoBehaviour
    {
        #region Variables
        private static GameManager m_instance;
        [SerializeField] private bool m_paused = false;
        [SerializeField] private float m_globalSpeed = 1f;
        [SerializeField] private float m_globalTimer = 0f;
        [SerializeField] private int m_totalScore = 0;
        [SerializeField] private float m_wallSpacing = 2f;
        [SerializeField] private Transform m_leftWall;
        [SerializeField] private Transform m_rightWall;
        #endregion
        #region Properties
        public static GameManager Instance
        {
            get
            {
                if (m_instance == null)
                    m_instance = FindObjectOfType<GameManager>();
                return m_instance;
            }
        }
        public UIManager UIManager => UIManager.Instance;
        public bool Paused
        {
            get => m_paused;
            set => m_paused = value;
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
        #endregion
        #region Methods
        private void Update()
        {
            if (m_paused)
                return;
            WallSpacing = m_wallSpacing;
            GlobalTimer += Time.deltaTime;
            UIManager.UpdateTimerText(GlobalTimer);
        }
        public void AddScore(int value)
        {
            // Add the score to total
            TotalScore += value;
            UIManager.UpdateScoreText(TotalScore);
        }
        public void GameOver()
        {
            Paused = true;
            GlobalSpeed = 0f;
        }
        public void Restart()
        {
            var scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.buildIndex);
        }
        #endregion
    }
}