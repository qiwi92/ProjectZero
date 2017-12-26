using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets
{


    public class EnemyController : MonoBehaviour {

        
        public int enemyCount;


        public EnemyPrefabController EnemyPrefab;

        public Enemy[] enemies;

        public float width;
        public float height;
        public float speed;

        public void SetUp()
        {
              enemies = new Enemy[enemyCount];

            for (int i = 0; i < enemyCount; i++)
            {
                enemies[i] = new Enemy(10,10, Instantiate(EnemyPrefab), 0f,false,false);
            }

            foreach (var enemy in enemies )
            {
                Reset(enemy);
                
            }
        }



        void Update()
        {
            foreach (var enemy in enemies)
            {
                if (enemy.enemyPrefab.Transform().position.y < -height)
                {                    
                    Reset(enemy);
                }
                enemy.enemyPrefab.Transform().position += Vector3.down * Time.deltaTime * speed;
            }
        }

        

        public void Reset(Enemy enemy)
        {
            float y = Random.Range(0, height / 2);
            float x = Random.Range(-width / 2, width / 2);

            enemy.enemyPrefab.Transform().position = new Vector3(x, height / 2 + y, 0);


            enemy.hp = 10;
            enemy.enemyPrefab.setHpBar(10, 10f);
            enemy.enemyPrefab.DisplayHpBar(enemy, true);

        }

    }
}