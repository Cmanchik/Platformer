using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MainMenu.GameplayMenu
{
    public class GameplayMenu : MonoBehaviour
    {
        [SerializeField] private GameObject playMode;
        [SerializeField] private GameObject pauseMode;

        [SerializeField] private Button pauseButton;
        [SerializeField] private Button continueButton;
        [SerializeField] private Button mainMenuButton;

        private void Awake()
        {
            pauseButton.onClick.AddListener(() =>
            {
                Time.timeScale = 0;
                pauseMode.SetActive(true);
                playMode.SetActive(false);
            });
            
            continueButton.onClick.AddListener(() =>
            {
                Time.timeScale = 1;
                pauseMode.SetActive(false);
                playMode.SetActive(true);
            });
            
            mainMenuButton.onClick.AddListener(() =>
            {
                Time.timeScale = 1;
                SceneManager.LoadScene(0);
            });
        }
    }
}
