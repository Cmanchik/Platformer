using System;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MainMenu.ShopCombo
{
    public class ComboInfoPanel : MonoBehaviour
    {
        [SerializeField] private TMP_Text nameCombo;
        [SerializeField] private TMP_Text comboButtons;
        [SerializeField] private TMP_Text costCombo;

        [SerializeField] private Button buyButton;
        
        
        public void Init(int numberCombo, string currentName, IReadOnlyList<string> combo, string cost, bool isPurchased,
            Action<int> onPurchased)
        {
            nameCombo.text = $"Name: {currentName}";
            costCombo.text = $"Cost: {cost}";
            
            StringBuilder comboList = new StringBuilder($"{combo[0]} -> ");
            for (int i = 1; i < combo.Count - 1; i++)
            {
                comboList.Append($"{combo[i]} -> ");
            }
            comboList.Append(combo[combo.Count - 1]);
            comboButtons.text = comboList.ToString();

            buyButton.onClick.RemoveAllListeners();
            if (isPurchased)
            {
                buyButton.interactable = false;
                buyButton.GetComponentInChildren<TMP_Text>().text = "Куплено";
            }
            else
            {
                buyButton.interactable = true;
                buyButton.GetComponentInChildren<TMP_Text>().text = "Купить";
                buyButton.onClick.AddListener(() => onPurchased.Invoke(numberCombo));
            }
        }
    }
}
