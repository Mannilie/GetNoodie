using UnityEngine;
using UnityEngine.UI;

namespace GetNoodie
{
    public class UI : MonoBehaviour
    {
        #region Variables
        private static UI m_instance;
        [SerializeField] private Text m_scoreText = null;
        [SerializeField] private Text m_timerText = null;
        #endregion
        #region Properties
        public static UI Instance
        {
            get
            {
                if (m_instance == null)
                    m_instance = FindObjectOfType<UI>();
                return m_instance;
            }
        }
        #endregion
        #region Methods
        public static void UpdateScoreText(int score)
        {
            Instance.m_scoreText.text = $"Score: {score}";
        }
        public static void UpdateTimerText(float timer)
        {
            var minutes = Mathf.Floor(timer / 60).ToString("00");
            var seconds = Mathf.Floor(timer % 60).ToString("00");
            Instance.m_timerText.text = $"Timer: {minutes}:{seconds}";
        }
        #endregion
    }
}