using UnityEngine;
using UnityEngine.SceneManagement;

namespace GetNoodie
{
    public class SceneLoader : MonoBehaviour
    {
        #region Variables
        public static SceneLoader m_instance;
        #endregion
        #region Properties
        public static SceneLoader Instance
        {
            get
            {
                if (m_instance == null)
                    m_instance = FindObjectOfType<SceneLoader>();
                return m_instance;
            }
        }
        #endregion
        #region Methods
        public void Restart()
        {
            var scene = SceneManager.GetActiveScene();
            LoadScene(scene.buildIndex);
        }
        public void LoadScene(int buildIndex)
        {
            SceneManager.LoadScene(buildIndex);
        }
        #endregion
    }
}