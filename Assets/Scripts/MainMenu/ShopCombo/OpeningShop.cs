using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace MainMenu.ShopCombo
{
    public class OpeningShop : MonoBehaviour
    {
        [SerializeField] private GameObject playMode;
        [SerializeField] private GameObject shop;
        [SerializeField] private GameObject openingImage;
        [SerializeField] private TMP_Text neededButton;

        private PlayerInput _playerInput;

        private void Start()
        {
            _playerInput = GameObject.FindWithTag("Player").GetComponent<PlayerInput>();
            int bindingIndex = _playerInput.actions["Interact"].GetBindingIndex();
            neededButton.text = _playerInput.actions["Interact"].GetBindingDisplayString(bindingIndex);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player")) openingImage.SetActive(true);
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (!other.CompareTag("Player") || !_playerInput.actions["Interact"].triggered) return;
            
            Time.timeScale = 0;
            shop.SetActive(true);
            playMode.SetActive(false);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player")) openingImage.SetActive(false);
        }
    }
}
