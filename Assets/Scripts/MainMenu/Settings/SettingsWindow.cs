using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace MainMenu.Settings
{
    public class SettingsWindow : MonoBehaviour
    {
        [SerializeField] private InputActionAsset inputActionAsset;
        
        [Space] 
        
        [SerializeField] private Button closeButton;
        [SerializeField] private MainMenuWindow mainMenuWindow;

        [Space] 
        
        [SerializeField] private RebindActionUI[] rebindActionUis;
        
        
        private const string RebindsNameKey = "rebinds";

        private void Awake()
        {
            closeButton.onClick.AddListener(() =>
            {
                mainMenuWindow.gameObject.SetActive(true);
                gameObject.SetActive(false);
            });
        }

        private void Start()
        {
            foreach (RebindActionUI rebindAction in rebindActionUis)
            {
                rebindAction.UpdateBindingDisplay();
            }
        }

        private void OnDisable()
        {
            string rebinds = inputActionAsset.SaveBindingOverridesAsJson();
            PlayerPrefs.SetString(RebindsNameKey, rebinds);
        }

        public void LoadSettings()
        {
            string rebinds = PlayerPrefs.GetString(RebindsNameKey);
            if (!string.IsNullOrEmpty(rebinds))
                inputActionAsset.LoadBindingOverridesFromJson(rebinds);
        }
    }
}
