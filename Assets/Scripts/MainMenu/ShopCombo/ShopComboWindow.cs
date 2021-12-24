using System;
using System.Collections.Generic;
using ComboAttack;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MainMenu.ShopCombo
{
    public class ShopComboWindow : MonoBehaviour
    {
        [SerializeField] private ComboAttack.ComboAttack[] comboAttacks;
        [SerializeField] private ComboInfoItem comboInfoItemPrefab;
        [SerializeField] private ComboInfoPanel comboInfoPanel;

        [SerializeField] private Transform containerComboInfoItems;
        [SerializeField] private TMP_Text playerCurrency;
        
        [Space]
        
        [SerializeField] private GameObject playMode;
        [SerializeField] private Button closeButton;

        private List<ComboInfoItem> _comboInfoItems = new List<ComboInfoItem>();
        private ComboLogic _playerCombos;

        private void Start()
        {
            FindPlayer();
            for (int i = 0; i < comboAttacks.Length; i++)
            {
                ComboInfoItem newComboInfo = Instantiate(comboInfoItemPrefab, containerComboInfoItems).GetComponent<ComboInfoItem>();
                _comboInfoItems.Add(newComboInfo);
                newComboInfo.Init(i, comboAttacks[i].nameCombo, comboAttacks[i].cost, 
                    _playerCombos.comboAttacks.Contains(comboAttacks[i]), SelectCombo);
            }
            
            SelectCombo(0);
            
            closeButton.onClick.AddListener(() =>
            {
                Time.timeScale = 1;
                playMode.SetActive(true);
                gameObject.SetActive(false);
            });
        }

        private void FindPlayer()
        {
            _playerCombos = GameObject.FindWithTag("Player").GetComponent<ComboLogic>();
            playerCurrency.text = CurrencyManager.Instance.currency.ToString();
        }

        private void SelectCombo(int index)
        {
            comboInfoPanel.Init(index, comboAttacks[index].nameCombo, comboAttacks[index].triggerAxis, 
                comboAttacks[index].cost, _playerCombos.comboAttacks.Contains(comboAttacks[index]), Buy);
        }

        private void Buy(int index)
        {
            _playerCombos.Add(comboAttacks[index]);
            
            _comboInfoItems[index].Init(index, comboAttacks[index].nameCombo, comboAttacks[index].cost, 
                _playerCombos.comboAttacks.Contains(comboAttacks[index]), SelectCombo);
            
            comboInfoPanel.Init(index, comboAttacks[index].nameCombo, comboAttacks[index].triggerAxis, 
                comboAttacks[index].cost, _playerCombos.comboAttacks.Contains(comboAttacks[index]), null);

            CurrencyManager.Instance.currency -= Convert.ToInt32(comboAttacks[index].cost);
            playerCurrency.text = CurrencyManager.Instance.currency.ToString();
        }
    }
}
