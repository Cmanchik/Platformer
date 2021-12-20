using UnityEngine;

namespace MainMenu.SavingLoading
{
    [CreateAssetMenu(fileName = "New saving", menuName = "Saving")]
    public class Saving : ScriptableObject
    {
        public Vector2 playerPosition;
        public int playerCoin;
        public ComboAttack.ComboAttack[] comboAttacks;
        public EnemyState[] enemies;
    }
}
