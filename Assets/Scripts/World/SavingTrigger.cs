using MainMenu.SavingLoading;
using UnityEngine;

namespace World
{
    public class SavingTrigger : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
                SavingManager.Instance.Save();
        }
    }
}
