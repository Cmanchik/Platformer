using UnityEngine;
using UnityEngine.UI;

namespace MainMenu.SavingLoading
{
    public class SavingLoadingWindow : MonoBehaviour
    {
        [SerializeField] private SavingSlot[] savingSlots;
        [SerializeField] private Button closeButton;
        
        [Space]
        
        [SerializeField] private MainMenuWindow mainMenuWindow;

        private void Awake()
        {
            for (int i = 0; i < savingSlots.Length; i++)
            {
                savingSlots[i].Init(i + 1);
            }
            
            closeButton.onClick.AddListener(() =>
            {
                mainMenuWindow.gameObject.SetActive(true);
                gameObject.SetActive(false);
            });
        }
    }
}
