using UnityEngine;

namespace MainMenu.ShopCombo
{
    public class CurrencyManager : Singleton<CurrencyManager>
    {
        public int currency = 300;
        
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
