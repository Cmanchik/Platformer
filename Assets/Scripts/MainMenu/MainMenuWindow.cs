using System;
using MainMenu.SavingLoading;
using MainMenu.Settings;
using UnityEngine;
using UnityEngine.UI;

namespace MainMenu
{
    public class MainMenuWindow : MonoBehaviour
    {
        [SerializeField] private Button startGameButton;
        [SerializeField] private Button settingsButton;
        [SerializeField] private Button exitButton;

        [SerializeField] private SavingLoadingWindow savingLoadingWindow;
        [SerializeField] private SettingsWindow settingsWindow;

        private void Awake()
        {
            startGameButton.onClick.AddListener(() =>
            {
                savingLoadingWindow.gameObject.SetActive(true);
                gameObject.SetActive(false);
            });
            
            settingsButton.onClick.AddListener(() =>
            {
                settingsWindow.gameObject.SetActive(true);
                gameObject.SetActive(false);
            });
            
            exitButton.onClick.AddListener(Application.Quit);
            
            settingsWindow.LoadSettings();
        }
    }
}
