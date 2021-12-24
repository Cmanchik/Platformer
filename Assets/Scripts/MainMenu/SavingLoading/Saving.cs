using UnityEngine;

namespace MainMenu.SavingLoading
{
    [CreateAssetMenu(fileName = "New saving", menuName = "Saving")]
    public class Saving : ScriptableObject
    {
        public Vector2 playerPosition;
        public int playerCoin;
        public int level;
        public ComboAttack.ComboAttack[] comboAttacks;
        public Vector2[] enemies;

        public bool isSave;
        public bool isEndGame;
        
        public bool Equals(Object obj)
        {
            //Check for null and compare run-time types.
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Saving s = (Saving) obj;
            return playerPosition == s.playerPosition &&
                   playerCoin == s.playerCoin &&
                   level == s.level &&
                   comboAttacks == s.comboAttacks &&
                   enemies == s.enemies &&
                   isSave == s.isSave &&
                   isEndGame == s.isEndGame;
        }
    }
}
