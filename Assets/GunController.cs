using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Assets
{
    public class GunController : MonoBehaviour {
    
        public GameObject BulletPrefab;
        public CoinReward Coins;

        public GameObject CanonTube;
        public GameObject Flare;

        public AudioSource laserSound;

        public Animator shielAnimator;

        public float GunRange;

        public float bulletMaxReach;

        public float speedFactor;
        public float offsetFactor;


        private float timer = 0;


        public EnemyController EnemyController;
        public PlayerMovementController Player;
        public LaserController LaserController;
        public Cash Cash;

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

            
            if (closestEnemyId >= 0 && timer >= Gun.FireRate())
            {
                Enemy closestEnemy = EnemyController.enemies[closestEnemyId];

                Vector3 r0 = closestEnemy.enemyPrefab.transform.position - transform.position;

                var ve = EnemyController.speed;
                var x0 =  r0.x;
                var y0 =  r0.y;
                var s = Vector3.Magnitude(r0);
                var v = speedFactor;

                var signY = 1;

                if (y0 > 0)
                {
                    signY = 1;
                }
                else
                {
                    signY = -1;
                }

                //var vx = (float)(-x0 * ((ve * y0 ) -  Math.Sqrt(-Math.Pow(ve * x0, 2)+ Math.Pow(v,2)*(Math.Pow(x0, 2)+ Math.Pow(y0, 2)) )/ (Math.Pow(x0, 2) + Math.Pow(y0, 2))));


                //Vector3 a = r0 + s / v *(new Vector3(0,-1,0))*Mathf.Abs(x0);

                var vx = (x0 / Mathf.Pow(s, 2)) * (y0 * ve + v * s - Mathf.Pow(ve*x0,2)/(2*v*s)) ;

                var arg = Mathf.Pow(v, 2) - Mathf.Pow(vx, 2);

                

                //var vy = (float) (sign * Math.Pow( (Math.Pow(v, 2) - Math.Pow(vx, 2)),0.5 ));
                //var vy = -(float) (Math.Sqrt(Math.Pow(v, 2) - Math.Pow(vx, 2)));




               

                if (arg >0)
                {
                    var vy = signY * Mathf.Sqrt(arg);
                    var amingDirection = 1/v*(new Vector3(vx, vy, 0));
                    bullets.Add(addBullet(amingDirection, BulletPrefab));
                    timer = 0;

                    laserSound.Play();


                    var angle = Vector3.Angle(new Vector3(1, 0, 0), amingDirection);
                    CanonTube.transform.rotation = Quaternion.Euler(0, 0, angle - 90);

                    //CanonTube.transform.DOPunchScale(new Vector3(0, 1, 0), 0.2f);
                    CanonTube.transform.DOPunchPosition(-0.05f*amingDirection, 0.1f);
                    Flare.transform.DOPunchScale(new Vector3(0, 0.2f, 0), 0.2f);


                    //var rot = Quaternion.Euler(0, 0, 90);
                }






            }
            timer += Time.deltaTime;


            if (bullets.Count > 0 )
            {

                
                    
                    //new Vector3(0,0, Vector3.Angle(EnemyController.enemies[closestEnemyId].enemyPrefab.transform.position,



                for (int i= 0;i < bullets.Count;i++)
                {
                    
                    var distanceFromPlayer = Vector3.Distance(bullets[i].bulletPrefab.transform.position, transform.position);

                    if (distanceFromPlayer > bulletMaxReach)
                    {
                        deadBullets.Add(bullets[i]);
                    }


                    bullets[i].bulletPrefab.transform.position += bullets[i].direction * speedFactor*Time.deltaTime;

                    foreach( var enemy in EnemyController.enemies)
                    {
                        var distance = Vector3.Distance(bullets[i].bulletPrefab.transform.position, enemy.enemyPrefab.transform.position);
      
                        if (distance < 0.3 && enemy.hp > 0)
                        {
                            deadBullets.Add(bullets[i]);
                            enemy.hp -= Gun.Damage();
                            
                        }
                    }
                }
            }


  




            foreach (var enemy in EnemyController.enemies)
            {
                var distanceToPlayer = Vector3.Distance(transform.position, enemy.enemyPrefab.transform.position);

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


        private Bullet addBullet (Vector3 direction, GameObject bulletPrefab)
        {
             return new Bullet(direction, Instantiate(bulletPrefab, transform.position, transform.rotation));
        }


        public int GetClosestEnemyId(Enemy[] enemies, float range)
        {
            float minDistance = float.MaxValue;
            int closestEnemyId;

            for (var enemyId = 0; enemyId < enemies.Length; enemyId++)
            {
                var enemyPosition = enemies[enemyId].enemyPrefab.Transform().position;
                var gunController = transform.position;
                var offset = Vector3.up * offsetFactor;

                var distance = Vector3.Distance(enemyPosition, gunController + offset);

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
