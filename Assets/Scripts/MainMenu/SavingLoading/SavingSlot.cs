using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MainMenu.SavingLoading
{
    public class SavingSlot : MonoBehaviour
    {
        [SerializeField] private TMP_Text slotNumber;
        
        [Space]
        
        [SerializeField] private TMP_Text progress;
        [SerializeField] private TMP_Text level;
        [SerializeField] private Button clearSlot;
        
        [Space]

        [SerializeField] private GameObject hasSaving;
        [SerializeField] private GameObject hasNotSaving;
        
        [Space]    

        [SerializeField] private Saving saving;
        [SerializeField] private Button startGame;

        public void Init(int numberSlot)
        {
            if (saving.isSave)
            {
                hasSaving.SetActive(true);
                hasNotSaving.SetActive(false);

                slotNumber.text = numberSlot.ToString();

                level.text = level.text.Replace("[N]", saving.level.ToString());
                progress.text = progress.text
                    .Replace("[N]", saving.isEndGame ? "100%" : $"{((float)saving.level - 1) / 2 * 100}%");
            }
            else
            {
                hasSaving.SetActive(false);
                hasNotSaving.SetActive(true);
            }
            
            startGame.onClick.AddListener(() =>
            {
                SavingManager.Instance.currentSaving = saving;
                
                if (!saving.isSave) LoadNewGame();
                
                SceneManager.LoadScene(saving.level);
            });
            
            clearSlot.onClick.AddListener(() =>
            {
                hasSaving.SetActive(false);
                hasNotSaving.SetActive(true);
                
                ClearSaving();
            });
        }

        private void LoadNewGame()
        {
            saving.playerPosition = SavingManager.Instance.start.playerPosition;
            saving.playerCoin = SavingManager.Instance.start.playerCoin;
            saving.level = SavingManager.Instance.start.level;
            saving.comboAttacks = SavingManager.Instance.start.comboAttacks;
            saving.enemies = SavingManager.Instance.start.enemies;
            saving.isSave = SavingManager.Instance.start.isSave;
            saving.isEndGame = SavingManager.Instance.start.isEndGame;
        }

        private void ClearSaving()
        {
            saving.level = 0;
            saving.isSave = false;
        }
    }
}
