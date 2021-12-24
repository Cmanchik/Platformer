using System;
using ComboAttack;
using MainMenu.SavingLoading;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace World
{
    public class LoadingNextLevel : MonoBehaviour
    {
        [SerializeField] private int nextLevel = 1;
        [SerializeField] private Saving nextLevelSaving;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;
            LoadSaving();
            SceneManager.LoadScene(nextLevel);
        }

        private void LoadSaving()
        {
            SavingManager.Instance.currentSaving.playerPosition = nextLevelSaving.playerPosition;
            SavingManager.Instance.currentSaving.playerCoin = nextLevelSaving.playerCoin;
            SavingManager.Instance.currentSaving.level = nextLevelSaving.level;
            
            SavingManager.Instance.currentSaving.comboAttacks = 
                GameObject.FindWithTag("Player").GetComponent<ComboLogic>().comboAttacks.ToArray();
            
            SavingManager.Instance.currentSaving.enemies = nextLevelSaving.enemies;
            SavingManager.Instance.currentSaving.isSave = nextLevelSaving.isSave;
            SavingManager.Instance.currentSaving.isEndGame = nextLevelSaving.isEndGame;
        }
    }
}
