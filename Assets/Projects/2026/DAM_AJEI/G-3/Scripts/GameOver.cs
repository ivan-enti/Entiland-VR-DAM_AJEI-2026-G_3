using UnityEngine;
using UnityEngine.SceneManagement;

namespace EntilandVR.DosCinco.DAM_AJEI.G_Tres
{
    public class GameOver : MonoBehaviour
    {
        public void RetryGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void ExitGame()
        {
            Application.Quit();
        }
    }
}
