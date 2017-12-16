using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Assets
{
    public class LaserController : MonoBehaviour
    {

        public LineRenderer LineRenderer;

        [HideInInspector] public EnemyController EnemyController;
        [HideInInspector] public PlayerMovementController Player;


        private int closestEnemyId;
        private GameObject closestEnemy;

        public UnityEngine.UI.Text killScore;
        private int killCount;

        public GameObject LaserBall;

        public GameObject laserBallPrefab;

        public float range;
        private float laserTime = 0;
        public float laserDestroyTime;

        public float laserBallSpeed;

        private bool isLocked = false;

        private float timer = 0;

        private List<GameObject> bullets;





        void Start()
        {
            killCount = 0;
        }


        void Update()
        {
            int closestEnemyId = GetClosestEnemyId(EnemyController.enemies, range);



            if (closestEnemyId >= 0)
            {
                Enemy closestEnemy = EnemyController.enemies[closestEnemyId];

                Vector3 enemyPosition = closestEnemy.enemyPrefab.Transform().position;
                Vector3 playerPosition = Player.transform.position;

                Vector3 bulletDirection = Vector3.Normalize(enemyPosition - playerPosition);


                timer += Time.deltaTime;

                if (timer > 0.1f)
                {
                    EnemyController.enemies[closestEnemyId].hp -= 1;
                    timer = 0;
                }

                LineRenderer.SetWidth(0.2f, 0.2f);
                LineRenderer.SetPositions(new Vector3[] { playerPosition, enemyPosition });

                Debug.Log("Closest enemy ID:" + closestEnemyId);



                var hp = (float)EnemyController.enemies[closestEnemyId].hp;
                if (hp < 0)
                {
                    EnemyController.enemies[closestEnemyId].hp = 10;
                    hp = (float)EnemyController.enemies[closestEnemyId].hp;
                    //EnemyController.Reset(closestEnemyId);


                    killCount += 1;
                }



                EnemyController.enemies[closestEnemyId].enemyPrefab.setHpBar(hp, 10f);





            }
            else
            {
                LineRenderer.SetWidth(0, 0);
            }

            killScore.text = "Enemies killed: " + killCount;

        }


        public int GetClosestEnemyId(Enemy[] enemies, float range)
        {
            float minDistance = float.MaxValue;
            int closestEnemyId;

            for (var enemyId = 0; enemyId < enemies.Length; enemyId++)
            {
                var enemyPosition = enemies[enemyId].enemyPrefab.Transform().position;
                var playerPosition = Player.transform.position;

                var distance = Vector3.Distance(enemyPosition, playerPosition);

                if (distance < minDistance && distance < range)
                {
                    minDistance = distance;
                    closestEnemyId = enemyId;
                    return closestEnemyId;
                }
            }
            return -1;
        }



    }

    
}