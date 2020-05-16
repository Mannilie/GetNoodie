using UnityEngine;
using UnityEngine.UI;

namespace GetNoodie
{
    public class UI : MonoBehaviour
    {
        #region Variables
        private static UI m_instance;
        [SerializeField] private GameObject m_bonusTextPrefab = null;
        [SerializeField] private Transform m_bonusTextParent = null;
        [SerializeField] private Text m_scoreText = null;
        [SerializeField] private Text m_timerText = null;
        [SerializeField] private Text m_waveText = null;
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
        public static void AddBonusText(int bonus, Vector3 worldPosition)
        {
            var cam = Camera.main;
            if (cam == null)
                return;
            var prefab = Instance.m_bonusTextPrefab;
            var parent = Instance.m_bonusTextParent;
            var instance = Instantiate(prefab, parent);
            instance.transform.position = cam.WorldToScreenPoint(worldPosition);
            var bonusText = instance.GetComponentInChildren<Text>();
            bonusText.text = $"{bonus}";
        }
        public static void UpdateScoreText(int score)
        {
            Instance.m_scoreText.text = $"{score}";
        }
        public static void UpdateTimerText(float timer)
        {
            var minutes = Mathf.Floor(timer / 60).ToString("00");
            var seconds = Mathf.Floor(timer % 60).ToString("00");
            Instance.m_timerText.text = $"{minutes}:{seconds}";
        }
        public static void UpdateWaveText(int wave)
        {
            Instance.m_waveText.text = $"{wave}";
        }
        #endregion
    }
}