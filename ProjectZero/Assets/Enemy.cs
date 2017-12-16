using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets
{
    public class Enemy
    {
        public int hp;
        public int maxHp;
        public EnemyPrefabController enemyPrefab;
        public float timer;
        public bool isDead;
        public bool hitPlayer;

        public Enemy(int _hp, int _maxHp, EnemyPrefabController _enemyPrefab, float _timer, bool _isDead, bool _hitPlayer)
        {
            hp = _hp;
            maxHp = _maxHp;
            enemyPrefab = _enemyPrefab;
            timer = _timer;
            isDead = _isDead;
            hitPlayer = _hitPlayer;
        }



    }
}