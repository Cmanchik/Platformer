using MainMenu.SavingLoading;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace World
{
    public class LoadingEndGame : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;
            SavingManager.Instance.EndGame();
            SceneManager.LoadScene(0);
        }
    }
}
