using UnityEngine;

namespace GetNoodie
{
    public class GameManager : MonoBehaviour
    {
        #region Variables
        private static GameManager m_instance;
        [SerializeField] private ScoreAddedEvent m_onScoreAdded = new ScoreAddedEvent();
        [SerializeField] private float m_globalSpeed = 1f;
        [SerializeField] private int m_totalScore = 0;
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
        public ScoreAddedEvent OnScoreAdded => m_onScoreAdded;
        public float GlobalSpeed
        {
            get => m_globalSpeed;
            set => m_globalSpeed = value;
        }
        public int TotalSpeed
        {
            get => m_totalScore;
            set => m_totalScore = value;
        }
        #endregion
        #region Methods
        public void AddScore(int scoreToAdd)
        {
            // Add the score to total
            m_totalScore += scoreToAdd;
            // Invoke onScoreAdded Event
            m_onScoreAdded.Invoke(m_totalScore);
        }
        public void GameOver()
        {
            m_globalSpeed = 0f;
        }
        #endregion
    }
}