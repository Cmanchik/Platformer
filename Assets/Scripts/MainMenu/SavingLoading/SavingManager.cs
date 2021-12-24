using System.Linq;
using UnityEngine;

namespace MainMenu.SavingLoading
{
    public class SavingManager : Singleton<SavingManager>
    {
        public Saving currentSaving;
        public Saving start;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        public void Save()
        {
            GameObject player = GameObject.FindWithTag("Player");
            currentSaving.playerPosition = player.transform.position;

            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            currentSaving.enemies = enemies
                .Select(enemy => enemy.transform.position).Select(dummy => (Vector2) dummy).ToArray();
        }

        public void EndGame()
        {
            currentSaving.isEndGame = true;
        }
    }
}
