using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MainMenu.ShopCombo
{
    public class ComboInfoItem : MonoBehaviour
    {
        [SerializeField] private TMP_Text nameCombo;
        [SerializeField] private TMP_Text costCombo;

        [Space] 
        
        [SerializeField] private Button button;

        public bool purchased;

        public void Init(int number, string currentName, string cost, bool isPurchased,
            [CanBeNull] Action<int> onSelected = null)
        {
            nameCombo.text = currentName;
            costCombo.text = cost;
            
            purchased = isPurchased;
            
            button.onClick.AddListener(() => onSelected.Invoke(number));
        }
    }
}
