using UnityEngine;
using UnityEngine.UI;

namespace GetNoodie
{
    public class UIManager : MonoBehaviour
    {
        #region Variables
        private static UIManager m_instance;
        [SerializeField] private Text m_scoreText;
        [SerializeField] private Text m_timerText;
        #endregion
        #region Properties
        public static UIManager Instance
        {
            get
            {
                if (m_instance == null)
                    m_instance = FindObjectOfType<UIManager>();
                return m_instance;
            }
        }
        #endregion
        #region Methods
        public void UpdateScoreText(int score)
        {
            m_scoreText.text = $"Score: {score}";
        }
        public void UpdateTimerText(float timer)
        {
            var minutes = Mathf.Floor(timer / 60).ToString("00");
            var seconds = Mathf.Floor(timer % 60).ToString("00");
            m_timerText.text = $"Timer: {minutes}:{seconds}";
        }
        #endregion
    }
}