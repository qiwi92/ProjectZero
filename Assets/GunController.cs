using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets
{
    public class GunController : MonoBehaviour {
    
        public GameObject BulletPrefab;
        public CoinReward Coins;

        public AudioSource laserSound;

        public Animator shielAnimator;

        public float GunRange;

        public float bulletMaxReach;

        public float speedFactor;
        public float offsetFactor;


        private float timer = 0;


        [HideInInspector] public EnemyController EnemyController;
        [HideInInspector] public PlayerMovementController Player;
        [HideInInspector] public LaserController LaserController;
        [HideInInspector] public Cash Cash;

        private float enemySpeed;
        private Vector3 enemyVelocity;

        private float bulletSpeed;


        public UnityEngine.UI.Text killScore;

        private List<Bullet> deadBullets;

        private List<Bullet> bullets;

        private int enemyToKillId;
        private int closestEnemyId;

        private float killTimer = 0;
        private bool triggered = false;

        private NumberFormatter NumberFormtter = new NumberFormatter();

        void Start ()
        {
            bullets = new List<Bullet>();
            deadBullets = new List<Bullet>();

            enemySpeed = EnemyController.speed;
            bulletSpeed = speedFactor;

            //works for vertically moving enemies
            enemyVelocity = enemySpeed * Vector3.down;


            enemyToKillId = -1;

        }
    	
    	void Update ()
        {

             closestEnemyId = GetClosestEnemyId(EnemyController.enemies, GunRange);

            
            if (closestEnemyId >= 0 && timer >= 0.2f)
            {
                Enemy closestEnemy = EnemyController.enemies[closestEnemyId];

                Vector3 amingDirection = Vector3.Normalize(closestEnemy.enemyPrefab.transform.position - Player.transform.position);

                bullets.Add(addBullet(amingDirection, BulletPrefab,Player));
                
                timer = 0;

                laserSound.Play();

            }
            timer += Time.deltaTime;

            if (bullets.Count > 0 ) {


                for (int i= 0;i < bullets.Count;i++)
                {
                    
                    var distanceFromPlayer = Vector3.Distance(bullets[i].bulletPrefab.transform.position, Player.transform.position);

                    if (distanceFromPlayer > bulletMaxReach)
                    {
                        deadBullets.Add(bullets[i]);
                    }


                    bullets[i].bulletPrefab.transform.position += bullets[i].direction * speedFactor*Time.deltaTime;

                    foreach( var enemy in EnemyController.enemies)
                    {
                        var distance = Vector3.Distance(bullets[i].bulletPrefab.transform.position, enemy.enemyPrefab.transform.position);
      
                        if (distance < 0.5)
                        {
                            deadBullets.Add(bullets[i]);
                            enemy.hp -= 1;
                            
                        }
                    }
                }
            }


  




            foreach (var enemy in EnemyController.enemies)
            {
                var distanceToPlayer = Vector3.Distance(Player.transform.position, enemy.enemyPrefab.transform.position);

                if (distanceToPlayer < 1.5)
                {
                    enemy.hp = 0;
                }



                var hp = (float)enemy.hp;

                if (hp <= 0)
                {
                    enemy.enemyPrefab.DisplayHpBar(enemy, false);

                    if(enemy.isDead == false)
                    {
                        enemy.isDead = true;
                        GameControl.Data.Kills += 1;
                        enemy.enemyPrefab.killAnimation.SetTrigger("Explotion");

                        if(distanceToPlayer < 1.5)
                        {
                            shielAnimator.Play("ShieldHit",0,-1f);
                            
                        }
                        Coins.Spawn(enemy.enemyPrefab.transform.position,9);
                        enemy.enemyPrefab.explotionSound.Play();
                    }
                    
                    enemy.timer += 0.01f;
                    if(enemy.timer > 0.6f)
                    {
                        enemy.isDead = false;
                        EnemyController.Reset(enemy);
                        enemy.timer = 0;      
                    }
                    
                    
                    
                }
                enemy.enemyPrefab.setHpBar(hp, 10f);

            }

            destroyDeadBullets();



        }


        private void destroyDeadBullets()
        {       
            if (deadBullets.Count > 0)
            {
                foreach (var deadBullet in deadBullets)
                {
                    bullets.Remove(deadBullet);
                    Destroy(deadBullet.bulletPrefab);
                }
                
            }
        }


        private Bullet addBullet (Vector3 direction, GameObject bulletPrefab, PlayerMovementController player)
        {
             return new Bullet(direction, Instantiate(bulletPrefab, player.transform.position,player.transform.rotation));
        }


        public int GetClosestEnemyId(Enemy[] enemies, float range)
        {
            float minDistance = float.MaxValue;
            int closestEnemyId;

            for (var enemyId = 0; enemyId < enemies.Length; enemyId++)
            {
                var enemyPosition = enemies[enemyId].enemyPrefab.Transform().position;
                var playerPosition = Player.transform.position;
                var offset = Vector3.up * offsetFactor;

                var distance = Vector3.Distance(enemyPosition, playerPosition + offset);

                if (distance < minDistance && distance < range && EnemyController.enemies[enemyId].isDead == false)
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
