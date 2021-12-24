using System.Linq;
using Camera;
using ComboAttack;
using UnityEngine;

namespace MainMenu.SavingLoading
{
    public class LoadingLevel : MonoBehaviour
    {
        [SerializeField] private GameObject player;
        [SerializeField] private GameObject enemy;
        [SerializeField] private CameraMovementScript cameraMovement;

        private void Awake()
        {
            GameObject playerInst =
                Instantiate(player, SavingManager.Instance.currentSaving.playerPosition, Quaternion.identity);

            cameraMovement.target = playerInst.transform;
            
            playerInst.GetComponentInChildren<ComboLogic>().comboAttacks = 
                SavingManager.Instance.currentSaving.comboAttacks.ToList();

            foreach (Vector2 enemyPos in SavingManager.Instance.currentSaving.enemies)
            {
                Instantiate(enemy, enemyPos, Quaternion.identity);
            }
            
            SavingManager.Instance.Save();
        }
    }
}
