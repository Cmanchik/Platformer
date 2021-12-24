using System.Collections;
using ComboAttack;
using Health;
using MainMenu.SavingLoading;
using Movement;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class TestSuite
    {
        [UnityTest]
        public IEnumerator LaunchingAttackAnimationAfterClickingOnTheAttackButton()
        {
            GameObject camera =  Object.Instantiate(Resources.Load<GameObject>("camera"));
            GameObject player = Object.Instantiate(Resources.Load<GameObject>("player"));
            
            player.GetComponent<TestAttack>().attack = true;
            player.GetComponent<Rigidbody2D>().gravityScale = 0;

            yield return new WaitForSeconds(3f);

            Assert.IsFalse(player.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Idle"));
            
            Object.Destroy(player.gameObject);
            Object.Destroy(camera.gameObject);
        }
        
        [UnityTest]
        public IEnumerator HealthDecreasesAfterGettingDamage()
        {
            GameObject camera =  Object.Instantiate(Resources.Load<GameObject>("camera"));
            GameObject player = Resources.Load<GameObject>("player");
            GameObject enemy = Resources.Load<GameObject>("enemy");
            
            player = Object.Instantiate(player);
            Vector3 position = player.transform.position;
            enemy = Object.Instantiate(enemy, new Vector3(position.x + 5, position.y), Quaternion.identity);

            player.GetComponent<TestAttack>().attack = true;
            player.GetComponent<Rigidbody2D>().gravityScale = 0;
            enemy.GetComponent<Rigidbody2D>().gravityScale = 0;

            float initialHeath = enemy.GetComponent<HealthScript>().healthPoint;

            yield return new WaitForSeconds(2f);
            
            Assert.Less(enemy.GetComponent<HealthScript>().healthPoint, initialHeath);
            
            Object.Destroy(player.gameObject);
            Object.Destroy(enemy.gameObject);
            Object.Destroy(camera.gameObject);
        }

        [UnityTest]
        public IEnumerator MovementPlayer()
        {
            GameObject camera =  Object.Instantiate(Resources.Load<GameObject>("camera"));
            GameObject player = Object.Instantiate(Resources.Load<GameObject>("player"));
            
            player.GetComponent<Rigidbody2D>().gravityScale = 0;
            float initialPosX = player.transform.position.x;
            
            yield return new WaitForSeconds(3f);
            player.GetComponent<SystemsManager.SystemsManager>().TurnOffCurrentSystem();
            
            Assert.Less(player.transform.position.x, initialPosX);
            
            Object.Destroy(player.gameObject);
            Object.Destroy(camera.gameObject);
        }
    }
}
