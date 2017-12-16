using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets
{
    public class Bullet
    {
        public Vector3 direction;
        public GameObject bulletPrefab;

        public Bullet(Vector3 _direction, GameObject _bulletPrefab)
        {
            direction = _direction;
            bulletPrefab = _bulletPrefab;
        }
    }
}
